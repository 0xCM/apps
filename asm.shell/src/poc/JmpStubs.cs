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
        public static unsafe ReadOnlySpan<JmpStub> search(Type host)
        {
            var uri = host.ApiHostUri();
            var methods = host.DeclaredMethods();
            var count = methods.Length;
            var entries = alloc<MemoryAddress>(count);
            var located = span<JmpStub>(count);
            ClrJit.jit(methods, entries);
            var j=0;
            for(var i=0; i< count; i++)
            {
                var encoded = Cells.alloc(w64).Bytes;
                ref readonly var method = ref skip(methods,i);
                ref readonly var entry = ref skip(entries,i);
                ref var data = ref entry.Ref<byte>();
                ByteReader.read5(data, encoded);
                if(JmpRel32.test(encoded))
                {
                    var target = JmpRel32.target(entry, encoded);
                    ref var info = ref seek(located,j++);
                    info.Method = method.Identify();
                    info.StubAddress = entry;
                    info.TargetAddress = target;
                    info.StubCode =  AsmHexCode.load(slice(encoded,0,5));
                    info.Displacement = JmpRel32.dx(encoded);
                    info.Offset = JmpRel32.offset(entry,entry,encoded);
                }
            }
            return slice(located,0,j);
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

        void Receive64u(ulong a0)
        {
            Wf.Status($"Received {a0}");
        }

        public Index<ApiCodeBlock> SearchApi()
        {
            var jumpers = list<ApiCodeBlock>();
            var buffer = list<ApiCodeBlock>();
            var hex = Wf.ApiHex();
            var files = hex.Files().View;
            var flow = Wf.Running(string.Format("Searching {0} hex files", files.Length));
            for(var i=0; i<files.Length; i++)
            {
                var file = skip(files,i);
                Write(string.Format("Searching {0}", file.ToUri()));
                buffer.Clear();
                var count = hex.ReadBlocks(file, buffer);
                var k = 0;
                for(var j=0; j<count; j++)
                {
                    var block = buffer[j];
                    if(JmpRel32.test(block.Encoded))
                    {
                        jumpers.Add(block);
                        k++;
                    }
                }
                if(k != 0)
                    Status(string.Format("Collected {0} potential jump stubs from {1}", k, file.ToUri()));

            }
            Wf.Ran(flow, string.Format("Collected {0} potential jump stubs", jumpers.Count));
            return jumpers.ToArray();
        }

        [Op]
        public ref readonly Cell128 EncodeDispatch(byte slot, MemoryAddress target)
        {
            var address = Trampolines[slot];
            ref var payload = ref Payloads[slot];
            var mov = AsmSpecs.mov(rcx, target).Content.Bytes;
            var dst = payload.Bytes;
            var j=0;
            for(var i=0; i< mov.Length; i++)
                seek(dst,j++) = skip(mov,i);
            return ref payload;
        }

        [Op]
        public ref readonly Cell128 EncodeDispatch(byte slot)
            => ref EncodeDispatch(slot, Receivers[slot]);
    }
}