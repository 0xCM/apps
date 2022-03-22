//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct Register
        {
            public readonly XedRegId Value;

            [MethodImpl(Inline)]
            public Register(XedRegId src)
            {
                Value = src;
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
                => IsEmpty ? EmptyString : Value.ToString();

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