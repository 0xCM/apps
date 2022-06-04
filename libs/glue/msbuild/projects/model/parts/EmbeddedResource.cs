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
        public readonly struct EmbeddedResourceSpec : IProjectItem<EmbeddedResourceSpec>
        {
            public const string TagName = nameof(EmbeddedResourceSpec);

            const string DefaultFormat = OpenTagFence + TagName + Delimiter + nameof(Include) + AttribSetOpen + Arg0 + AttribSetClose;

            public string Include {get;}

            [MethodImpl(Inline)]
            public EmbeddedResourceSpec(string include)
            {
                Include = include;
            }

            public Identifier Name
                => TagName;

            [MethodImpl(Inline)]
            public string Format()
                => string.Format(DefaultFormat, Include);

            public override string ToString()
                => Format();
        }
    }
}