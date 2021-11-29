//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ValueClass<T>
    {
        public uint Ordinal {get;}

        public Label ClassName {get;}

        public Label KindName {get;}

        public Label Symbol {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public ValueClass(uint ordinal, Label @class, Label kind, Label symbol, T value)
        {
            Ordinal = ordinal;
            ClassName = @class;
            KindName = kind;
            Symbol = symbol;
            Value = value;
        }
    }
}