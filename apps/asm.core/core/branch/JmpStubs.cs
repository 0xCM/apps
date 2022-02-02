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

        [Op]
        public ref readonly Cell128 EncodeDispatch(byte slot, MemoryAddress target)
        {
            var address = Trampolines[slot];
            ref var payload = ref Payloads[slot];
            var storage = Cell128.Empty;
            var buffer = storage.Bytes;
            var size = AsmHexSpecs.mov(rcx, target, ref first(buffer));
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