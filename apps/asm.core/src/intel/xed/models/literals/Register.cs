//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct Register : IEnumCover<RegId>
        {
            public RegId Value {get;}

            [MethodImpl(Inline)]
            public Register(RegId src)
            {
                Value = src;
                Symbols.expr(src);
            }

            public string Format()
                => Value != 0 ? Symbols.expr(Value).Format() : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Register(RegId src)
                => new Register(src);

            [MethodImpl(Inline)]
            public static implicit operator RegId(Register src)
                => src.Value;
        }
    }
}