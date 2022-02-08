//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataType(XedNames.reg)]
        public struct Register : IEnumCover<XedRegId>
        {
            public XedRegId Value {get;set;}

            [MethodImpl(Inline)]
            public Register(XedRegId src)
            {
                Value = src;
                Symbols.expr(src);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Value == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Value != 0;
            }

            public string Format()
                => Symbols.format(Value);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Register(XedRegId src)
                => new Register(src);

            [MethodImpl(Inline)]
            public static implicit operator XedRegId(Register src)
                => src.Value;
        }
    }
}