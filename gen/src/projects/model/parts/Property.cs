//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct ProjectModel
    {
        public readonly struct Property : IBuildProperty
        {
            public Identifier Name {get;}

            public dynamic Value {get;}

            [MethodImpl(Inline)]
            public Property(Identifier name, dynamic value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => string.Format("<{0}>{1}</{0}>", Name, Value);

            public override string ToString()
                => Format();

        }

        public readonly struct Property<T> : ITextual
        {
            public Identifier Name {get;}

            public T Value {get;}

            [MethodImpl(Inline)]
            public Property(Identifier name, T value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => string.Format("<{0}>{1}</{0}>", Name, Value);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Property(Property<T> src)
                => new Property(src.Name, src.Value);
        }
    }
}