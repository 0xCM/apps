//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public readonly struct Property : IProjectProperty
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

        public readonly struct Property<T> : IProjectProperty<T>
        {
            public readonly Identifier Name {get;}

            public readonly T Value {get;}

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