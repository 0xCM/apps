//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Class<K,T>
        where K : unmanaged
    {
        public uint Ordinal {get;}

        public Label ClassName {get;}

        public Label KindName {get;}

        public Label Symbol {get;}

        public K Kind {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public Class(uint ordinal, Label @class, Label name, Label symbol, K kind, T value)
        {
            Ordinal = ordinal;
            ClassName = @class;
            KindName = name;
            Symbol = symbol;
            Kind = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator Class<T>(Class<K,T> src)
            => types.unkind(src);
    }
}