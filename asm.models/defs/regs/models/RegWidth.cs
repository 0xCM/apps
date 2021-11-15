//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RegWidth
    {
        [Op]
        public static string format(RegWidth src)
        {
            var symbols = Symbols.index<NativeSizeCode>();
            var index = (byte)src.Size.Code;
            var symbol = symbols[index];
            return symbol.Expr.Format();
        }

        public NativeSize Size {get;}

        [MethodImpl(Inline)]
        public RegWidth(NativeSizeCode code)
        {
            Size = code;
        }

        public string Format()
            => format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator RegWidth(NativeSizeCode src)
            => new RegWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator NativeSizeCode(RegWidth src)
            => src.Size;

        [MethodImpl(Inline)]
        public static implicit operator RegWidth(NativeSize src)
            => (NativeSizeCode)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator NativeSize(RegWidth src)
            => src.Size;
    }
}