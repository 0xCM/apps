//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResolvedVar : IValue<object>, ITerm
    {
        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public ResolvedVar(dynamic value)
        {
            Value = value;
        }

        object IValue<object>.Value
            => Value;

        public string Format()
            => Value != null ? Value.ToString() : EmptyString;

        public override string ToString()
            => Format();

    }
}