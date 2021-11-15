//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Specifies a <see cref='RegClassCode'/>
    /// </summary>
    public readonly struct RegClass
    {
        [Op]
        public static string format(RegClass src)
        {
            var symbols = Symbols.index<RegClassCode>();
            var index = (byte)src.Code;
            var symbol = symbols[index];
            return symbol.Expr.Format();
        }


        public RegClassCode Code {get;}

        [MethodImpl(Inline)]
        public RegClass(RegClassCode code)
        {
            Code = code;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator RegClassCode(RegClass src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator RegClass(RegClassCode src)
            => new RegClass(src);
    }
}