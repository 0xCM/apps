//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct ValueClass
    {
        public readonly uint Ordinal;

        public readonly Label ClassName;

        public readonly Label Identifier;

        public readonly Label Symbol;

        public readonly ulong Value;

        [MethodImpl(Inline)]
        public ValueClass(uint ordinal, Label @class, Label kind, Label symbol, ulong value)
        {
            Ordinal = ordinal;
            ClassName = @class;
            Identifier = kind;
            Symbol = symbol;
            Value = value;
        }
    }
}