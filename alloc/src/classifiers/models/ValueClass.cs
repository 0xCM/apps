//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public readonly record struct ValueClass
    {
        const string TableId = "api.classes";
        [Render(8)]
        public readonly uint Ordinal;

        [Render(16)]
        public readonly Label ClassName;

        [Render(16)]
        public readonly Label Identifier;

        [Render(16)]
        public readonly Label Symbol;

        [Render(1)]
        public readonly ulong Value;

        [MethodImpl(Inline)]
        public ValueClass(uint ordinal, Label @class, Label name, Label symbol, ulong value)
        {
            Ordinal = ordinal;
            ClassName = @class;
            Identifier = name;
            Symbol = symbol;
            Value = value;
        }
    }
}