//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmPrefixCodes;

    using Operands;

    public class X86Dispatcher : AppService<X86Dispatcher>
    {
        Index<MemoryRange> Trampolines;

        Index<Cell128> Payloads;

        Index<MemoryAddress> Receivers;

        const uint SlotCount = 256;

        public X86Dispatcher()
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
            Status($"Received {a0}");
        }

        // REX.W + B8+ rd io | MOV r64, imm64           | OI    | Valid       | N.E.            | Move imm64 to r64.                                             |
        [MethodImpl(Inline), Op]
        static byte mov(r64 r, imm64 imm, Span<byte> dst)
            => AsmBytes.encode(RexW, (Hex8)(0xb8 + (byte)r.Index), imm, dst);

        [Op]
        public ref readonly Cell128 EncodeDispatch(byte slot, MemoryAddress target)
        {
            var address = Trampolines[slot];
            ref var payload = ref Payloads[slot];
            var storage = Cell128.Empty;
            var buffer = storage.Bytes;
            var size = mov(AsmRegOps.rcx, target, buffer);
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