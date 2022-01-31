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
        public static unsafe Index<JmpStub> search(Type host)
        {
            var uri = host.ApiHostUri();
            var methods = host.DeclaredMethods();
            var count = methods.Length;
            var entries = alloc<MemoryAddress>(count);
            var located = span<JmpStub>(count);
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
                    stub.Name = method.Identify();
                    stub.Stub = entry;
                    stub.Target = target;
                    stub.Encoding =  AsmHexCode.load(slice(encoded,0,5));
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

        void Receive64u(ulong a0)
        {
            Status($"Received {a0}");
        }

        public Index<JmpStub> SearchLive(Type host)
            => search(host);

        static JmpStub stub(in ApiCodeBlock block)
        {
            var encoding = slice(block.Encoded.View,0, JmpRel32.InstSize);
            var stub = new JmpStub();
            var source = block.BaseAddress;
            stub.Name = block.OpId;
            stub.Stub = source;
            stub.Target = AsmRel32.target(source, encoding);
            stub.Encoding =  encoding;
            stub.Disp = AsmRel32.disp(encoding);
            return stub;
        }

        public Index<JmpStub> SearchCaptured(ApiHostUri host)
        {
            var src = ApiHex.ParsedExtracts(host);
            if(!src.Exists)
            {
                Error(FS.missing(src));
                return sys.empty<JmpStub>();
            }

            var dst = list<JmpStub>();
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

        public Index<JmpStub> SearchCaptured()
        {
            var dst = list<JmpStub>();
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