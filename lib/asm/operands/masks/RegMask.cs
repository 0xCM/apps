//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct RegMask : IRegMask
    {
        [Op]
        public static string format(in RegMask src)
        {
            var dst = EmptyString;
            if(src.Kind == RegMaskKind.Merge)
                dst = string.Format("{0} {{1}}", src.Target, AsmRegs.rK(src.Mask));
            else if(src.Kind == RegMaskKind.Zero)
                dst = string.Format("{0} {{{1}}{{2}}", src.Target, AsmRegs.rK(src.Mask), Chars.z);
            return dst;
        }

        public RegOp Target {get;}

        public RegIndex Mask {get;}

        public RegMaskKind Kind {get;}

        [MethodImpl(Inline)]
        public RegMask(RegOp target, RegIndex mask, RegMaskKind kind)
        {
            Target = target;
            Mask = mask;
            Kind = kind;
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => NativeSizeCode.W64;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}