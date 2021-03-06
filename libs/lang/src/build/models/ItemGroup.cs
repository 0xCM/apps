//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;

    partial class MsBuild
    {
        public sealed class ItemGroup : ProjectGroup<IProjectItem>
        {
            public ItemGroup(params ProjectItem[] src)
                : base(GroupKind.ItemGroup, src)
            {

            }


            public ItemGroup()
                : base(GroupKind.ItemGroup)
            {

            }
        }
    }
}