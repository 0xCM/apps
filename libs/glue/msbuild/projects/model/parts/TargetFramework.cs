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
        public readonly struct TargetFramework : IBuildProperty
        {
            public const string TagName = nameof(TargetFramework);

            public dynamic Value {get;}

            public Identifier Name
                => TagName;

            [MethodImpl(Inline)]
            public TargetFramework(dynamic value)
                => Value = value;

            [MethodImpl(Inline)]
            public TargetFramework(dynamic value, Version ver)
                => Value = value.ToString() + ver.Format();

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static implicit operator Property(TargetFramework src)
                =>  property(src.Name, src.Value);
        }
    }
}