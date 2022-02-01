//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;
    using static AsmRegOps;
    using static Root;

    public class JmpStubs : AppService<JmpStubs>
    {
        public static JmpStub rel32(MemoryAddress src, MemoryAddress dst)
            => new JmpStub(src,dst);

        public static unsafe Index<LiveMemberCode> search(SymbolDispenser symbols, Type host)
        {
            var uri = host.ApiHostUri();
            var methods = host.DeclaredMethods();
            var count = methods.Length;
            var entries = alloc<MemoryAddress>(count);
            var located = span<LiveMemberCode>(count);
            ClrJit.jit(methods, entries);
            var j=0;
            for(var i=0; i<count; i++)
            {
                var encoded = Cells.alloc(w64).Bytes;
                ref readonly var method = ref skip(methods,i);
                ref readonly var entry = ref skip(entries,i);
                ref var data = ref entry.Ref<byte>();
                ByteReader.read5(data, encoded);
                if(AsmRel32.isJmp(encoded))
                {
                    var target = AsmRel32.target(entry, encoded);
                    ref var stub = ref seek(located,j++);
                    stub.Entry = entry;
                    stub.Target = target;
                    stub.StubCode =  AsmHexCode.load(slice(encoded,0,5));
                    stub.Disp = AsmRel32.disp(encoded);
                }
            }
            return slice(located,0,j).ToArray();
        }

        Index<MemoryRange> Trampolines;

        Index<Cell128> Payloads;

        Index<MemoryAddress> Receivers;

        const uint SlotCount = 256;

        public JmpStubs()
        {
            Trampolines = alloc<MemoryRange>(SlotCount);
            Payloads = alloc<Cell128>(SlotCount);
            Receivers = alloc<MemoryAddress>(SlotCount);
            Receivers[0] = ClrJit.jit(GetType().Method(nameof(Receive64u)));
        }

        public bool Create<T>(byte slot)
            where T : unmanaged
        {
             var stub = new JmpStub<T>();
            Trampolines[slot] = stub.Init();
            return Trampolines[slot].IsNonEmpty;
        }

        ApiHex ApiHex => Service(Wf.ApiHex);

        ApiJit ApiJit => Service(Wf.ApiJit);

        void Receive64u(ulong a0)
        {
            Status($"Received {a0}");
        }

        public Index<LiveMemberCode> SearchLive(SymbolDispenser symbols, Type host)
            => search(symbols,host);

        static LiveMemberCode stub(in ApiCodeBlock block)
        {
            var encoding = slice(block.Encoded.View,0, JmpRel32.InstSize);
            var stub = new LiveMemberCode();
            var source = block.BaseAddress;
            stub.Entry = source;
            stub.Target = AsmRel32.target(source, encoding);
            stub.StubCode =  encoding;
            stub.Disp = AsmRel32.disp(encoding);
            return stub;
        }

        public Index<LiveMemberCode> SearchCaptured(SymbolDispenser symbols, ApiHostUri host)
        {
            var src = ApiHex.ParsedExtracts(host);
            if(!src.Exists)
            {
                Error(FS.missing(src));
                return sys.empty<LiveMemberCode>();
            }

            var dst = list<LiveMemberCode>();
            var blocks = ApiHex.ReadBlocks(src);
            var count = blocks.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref blocks[i];
                if(AsmRel32.isJmp(block.Encoded))
                    dst.Add(stub(block));
            }
            return dst.ToArray();
        }

        public Index<LiveMemberCode> SearchLive(SymbolDispenser symbols)
        {
            var entries = MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog));
            var count = entries.Count;
            var located = alloc<LiveMemberCode>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref entries[i];
                var buffer = Cells.alloc(w64).Bytes;
                ref var data = ref entry.Location.Ref<byte>();
                ByteReader.read5(data, buffer);
                ref var dst = ref seek(located,i);
                Collect(symbols, entry, out seek(located, i));
            }
            return located;
        }

        bool Collect(SymbolDispenser symbols, MethodEntryPoint entry, out LiveMemberCode dst)
        {
            dst = new LiveMemberCode();
            dst.Entry = entry.Location;
            dst.Uri = entry.Uri;
            var buffer = Cells.alloc(w64).Bytes;
            ref var data = ref entry.Location.Ref<byte>();
            ByteReader.read5(data, buffer);
            if(AsmRel32.isJmp(buffer))
            {
                var target = AsmRel32.target(entry.Location, buffer);
                var encoded = AsmHexCode.load(slice(buffer,0,5));
                dst.Target = target;
                dst.StubCode = encoded;
                dst.Disp = AsmRel32.disp(encoded.Bytes);
                dst.Stub = rel32(entry.Location, target);
                dst.Token = ApiToken.create(symbols, entry, target);
                return true;
            }
            else
            {
                dst.Token = ApiToken.create(symbols, entry);
            }

            return false;
        }

        public Index<LiveMemberCode> SearchCaptured(SymbolDispenser symbols)
        {
            var dst = list<LiveMemberCode>();
            var buffer = list<ApiCodeBlock>();
            var files = ApiHex.ParsedExtracts();
            var flow = Running(string.Format("Searching {0} hex files", files.Length));
            for(var i=0; i<files.Length; i++)
            {
                var file = files[i];
                Write(string.Format("Searching {0}", file.ToUri()));
                buffer.Clear();
                var count = ApiHex.ReadBlocks(file, buffer);
                var k = 0;
                for(var j=0; j<count; j++)
                {
                    var block = buffer[j];
                    if(AsmRel32.isJmp(block.Encoded))
                    {
                        dst.Add(stub(block));
                        k++;
                    }
                }
                if(k != 0)
                    Status(string.Format("Collected {0} jump stubs from {1}", k, file.ToUri()));

            }
            Ran(flow, string.Format("Collected {0} jump stubs", dst.Count));
            return dst.ToArray();
        }

        [Op]
        public ref readonly Cell128 EncodeDispatch(byte slot, MemoryAddress target)
        {
            var address = Trampolines[slot];
            ref var payload = ref Payloads[slot];
            var storage = Cell128.Empty;
            var buffer = storage.Bytes;
            var size = AsmHexSpecs.mov(rcx, target, ref first(buffer));
            //var mov = AsmHexSpecs.mov(rcx, target).Bytes;
            var dst = payload.Bytes;
            var j=0;
            for(var i=0; i<size; i++)
                seek(dst,j++) = skip(buffer,i);
            return ref payload;
        }

        [Op]
        public ref readonly Cell128 EncodeDispatch(byte slot)
            => ref EncodeDispatch(slot, Receivers[slot]);
    }
}