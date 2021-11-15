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
    using static core;

    /// <summary>
    /// Represents an operand expression of the form BaseReg + IndexReg*Scale + Displacement
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AsmAddress
    {
        public static string format(in AsmAddress src)
        {
            var dst = CharBlock32.Null.Data;
            var i=0u;
            var count = render(src, ref i, dst);
            return text.format(dst, count);
        }

        public static uint render(in AsmAddress src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var @base = src.Base.Format();
            var index = src.Index.Format();
            text.copy(@base, ref i, dst);
            var scale = src.Scale.Format();
            if(src.Scale.IsNonZero)
            {
                seek(dst,i++) = Chars.Plus;
                text.copy(index, ref i, dst);
                if(src.Scale.IsNonUnital)
                {
                    seek(dst,i++) = Chars.Star;
                    text.copy(scale,ref i, dst);
                }
            }

            if(src.Disp.Value != 0)
            {
                seek(dst,i++) = Chars.Plus;
                text.copy(src.Disp.Value.ToString("x") + "h", ref i, dst);
            }

            return i - i0;
        }

        public readonly RegOp Base;

        public readonly RegOp Index;

        public readonly MemoryScale Scale;

        public readonly Disp Disp;

        [MethodImpl(Inline)]
        public AsmAddress(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Base = @base;
            Index = index;
            Scale = scale;
            Disp = disp;
        }

        public NativeSize AddressSize
        {
            [MethodImpl(Inline)]
            get => Base.Size;
        }

        public bit HasBase
        {
            [MethodImpl(Inline)]
            get => Base.IsNonEmpty;
        }

        public bit HasIndex
        {
            [MethodImpl(Inline)]
            get => Index.IsNonEmpty;
        }

        public bit HasScale
        {
            [MethodImpl(Inline)]
            get => Scale.IsNonEmpty;
        }

        public bit HasDisp
        {
            [MethodImpl(Inline)]
            get => Disp.IsNonZero;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}