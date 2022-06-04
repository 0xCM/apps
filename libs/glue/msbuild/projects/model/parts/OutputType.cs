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
        public readonly struct OutputType : IBuildProperty
        {
            public dynamic Value {get;}

            [MethodImpl(Inline)]
            public OutputType(string value)
                => Value = value;

            public Identifier Name
                => nameof(OutputType);

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Property(OutputType src)
                => property(src.Name, src.Value);
        }
    }
}