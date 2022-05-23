//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct ValueClass<T>
    {
        public readonly uint Ordinal;

        public readonly Label ClassName;

        public readonly Label Identifier;

        public readonly Label Symbol;

        public readonly T Value;

        [MethodImpl(Inline)]
        public ValueClass(uint ordinal, Label @class, Label kind, Label symbol, T value)
        {
            Ordinal = ordinal;
            ClassName = @class;
            Identifier = kind;
            Symbol = symbol;
            Value = value;
        }
    }
}