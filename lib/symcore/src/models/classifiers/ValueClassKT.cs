//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a classification
    /// </summary>
    public readonly struct ValueClass<K,T>
        where K : unmanaged
    {
        public uint Ordinal {get;}

        public Label ClassName {get;}

        public Label KindName {get;}

        public Label Symbol {get;}

        public K Kind {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public ValueClass(uint ordinal, Label @class, Label name, Label symbol, K kind, T value)
        {
            Ordinal = ordinal;
            ClassName = @class;
            KindName = name;
            Symbol = symbol;
            Kind = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator ValueClass<T>(ValueClass<K,T> src)
            => src;
    }
}