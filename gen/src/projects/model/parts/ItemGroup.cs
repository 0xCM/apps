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
        public readonly struct ItemGroup
        {
            public const string TagName = nameof(ItemGroup);

            public Index<ProjectItem> Data {get;}

            [MethodImpl(Inline)]
            public ItemGroup(ProjectItem[] src)
                => Data = src;
        }
    }
}