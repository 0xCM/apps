//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Gen.Projects
{
    public sealed class ItemGroup : ProjectGroup<ProjectItem>
    {
        public ItemGroup(params ProjectItem[] src)
            : base(GroupKind.ItemGroup, src)
        {

        }

        public ItemGroup()
            : base(GroupKind.ItemGroup)
        {

        }

        public ItemGroup WithPackageReference(string name, string version)
        {
            Members.Add(new PackageReference(name,version));
            return this;
        }
    }
}