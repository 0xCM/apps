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
        public static unsafe Index<LiveMemberCode> search(Type host)
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
                    stub.Name = method.Uri();
                    stub.Entry = entry;
                    stub.Target = target;
                    stub.StubEncoding =  AsmHexCode.load(slice(encoded,0,5));
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

        public Index<LiveMemberCode> SearchLive(Type host)
            => search(host);

        static LiveMemberCode stub(in ApiCodeBlock block)
        {
            var encoding = slice(block.Encoded.View,0, JmpRel32.InstSize);
            var stub = new LiveMemberCode();
            var source = block.BaseAddress;
            stub.Name = block.OpUri;
            stub.Entry = source;
            stub.Target = AsmRel32.target(source, encoding);
            stub.StubEncoding =  encoding;
            stub.Disp = AsmRel32.disp(encoding);
            return stub;
        }

        public Index<LiveMemberCode> SearchCaptured(ApiHostUri host)
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

        public Index<LiveMemberCode> SearchLive()
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
                SearchEntry(entry, out seek(located, i));
            }
            return located;
        }

        public bool SearchEntry(MethodEntryPoint entry, out LiveMemberCode dst)
        {
            dst = new LiveMemberCode();
            dst.Name = entry.Name;
            dst.Entry = entry.Location;

            var buffer = Cells.alloc(w64).Bytes;
            ref var data = ref entry.Location.Ref<byte>();
            ByteReader.read5(data, buffer);
            if(AsmRel32.isJmp(buffer))
            {
                var target = AsmRel32.target(entry.Location, buffer);
                var encoded = AsmHexCode.load(slice(buffer,0,5));
                dst.IsStub = 1;
                dst.Target = target;
                dst.StubEncoding = encoded;
                dst.Disp = AsmRel32.disp(encoded.Bytes);
                return true;
            }
            return false;
        }

        public Index<LiveMemberCode> SearchCaptured()
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
            var mov = AsmHexSpecs.mov(rcx, target).Bytes;
            var dst = payload.Bytes;
            var j=0;
            for(var i=0; i<mov.Length; i++)
                seek(dst,j++) = skip(mov,i);
            return ref payload;
        }

        [Op]
        public ref readonly Cell128 EncodeDispatch(byte slot)
            => ref EncodeDispatch(slot, Receivers[slot]);
    }
}