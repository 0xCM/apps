//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial class AsmCmdService
    {
        static ReadOnlySpan<byte> min64u_64u_64u
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x3b,0xca,0x72,0x04,0x48,0x8b,0xc2,0xc3,0x48,0x8b,0xc1,0xc3};

        [CmdOp(".load-code")]
        Outcome LoadCode(CmdArgs args)
        {
            var result = Outcome.Success;
            var id = arg(args,0).Value;
            var path = AsmWs.BinPath(id);
            var data = path.ReadBytes().ToReadOnlySpan();
            var size = data.Length;
            var msg = string.Format("Read {0} bytes from {1}", size, path.ToUri());
            Status(msg);
            result = LoadCodeBuffer(id, data);
            if(result)
                Write(string.Format("Injected data into execution buffer: {0}", data.FormatHex()));
            return result;
        }

        Outcome LoadCodeBuffer(string name, ReadOnlySpan<byte> src)
        {
            RoutineName = name;
            CodeBuffer.Clear();
            var size = src.Length;
            if(size > CodeBuffer.Size)
                return (false, CapacityExceeded.Format());

            var buffer = CodeBuffer.Edit;
            for(var i=0; i<size; i++)
                seek(buffer,i) = skip(src,i);
            CodeSize = size;
            return true;
        }

        [CmdOp(".exec")]
        unsafe Outcome Exec(CmdArgs args)
        {
            var name = "min64u";
            var a = 4ul;
            var b = 12ul;
            var block = DFx.load(min64u_64u_64u, 0, CodeBuffer);
            var f = DFx.binop<ulong>(name, block);
            DFx.specify(a, b, ref f);
            var result = DFx.invoke(f);
            Write(DFx.format(f, result));
            return true;
        }


        [CmdOp(".slots")]
        unsafe Outcome Slots(CmdArgs args)
        {
            var result = Outcome.Success;
            var slots = ClrDynamic.slots(typeof(SlotBox64)).View;
            var box = new SlotBox64();
            var code = GetArg;
            for(byte i=0; i<slots.Length; i++)
            {
                ref readonly var slot = ref skip(slots,i);
                var pDst = slot.Address.Pointer<byte>();
                var length = code.Length;
                for(var j=0; j<length; j++)
                    seek(pDst,j) = skip(code,j);

                ulong Dispatch(byte index, ulong a)
                    => index switch
                    {
                        0 => box.f0(a*2),
                        1 => box.f1(a*3),
                        2 => box.f2(a*4),
                        3 => box.f3(a*5),
                        _ => 0
                    };

                var @return = Dispatch(i,i);
                Write(string.Format("{0}: {1}", i, @return));
            }

            return result;
        }

        // mov rax,rcx -> ret
        static ReadOnlySpan<byte> GetThis => new byte[]{0x48, 0x8b, 0xc1, 0xc3};

        // mov rax,rdx -> ret
        static ReadOnlySpan<byte> GetArg => new byte[]{0x48, 0x8b, 0xc2, 0xc3};

        static ReadOnlySpan<byte> JmpRdx => new byte[]{0xff, 0xe2};
    }

    readonly struct SlotBox64
    {
        readonly ulong A;

        [MethodImpl(NotInline)]
        public ulong f0(ulong a)
            => ulong.MaxValue;

        [MethodImpl(NotInline)]
        public ulong f1(ulong a0)
            => ulong.MaxValue;

        [MethodImpl(NotInline)]
        public ulong f2(ulong a0)
            => ulong.MaxValue;

        [MethodImpl(NotInline)]
        public ulong f3(ulong a0)
            => ulong.MaxValue;
    }
}