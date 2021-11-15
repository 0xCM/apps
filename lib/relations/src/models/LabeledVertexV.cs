//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LabeledVertex<V> : ILabeledVertex<V>, IEquatable<LabeledVertex<V>>
    {
        public Label Name {get;}

        public V Value {get;}

        [MethodImpl(Inline)]
        public LabeledVertex(Label name, V value)
        {
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public bool Equals(LabeledVertex<V> src)
            => Name.Equals(src.Name);

        public override int GetHashCode()
            => (int)Name.Hash;

        public override bool Equals(object obj)
            => obj is LabeledVertex<V> v && Equals(v);

        public string Format()
            => string.Format("{0}({1})", Name, Value);

        public override string ToString()
            => Format();
    }
}