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
        public readonly struct PropertyGroup
        {
            public const string TagName = nameof(PropertyGroup);

            public Index<Property> Properties {get;}

            [MethodImpl(Inline)]
            public PropertyGroup(Index<Property> src)
                => Properties = src;
        }
    }
}