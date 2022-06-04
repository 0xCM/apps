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

        public ItemGroup WithProjectReference(string name)
        {
            Members.Add(new ProjectReference(name));
            return this;
        }

        public ItemGroup WithReference(string name, FS.FilePath? hint = null)
        {
            Members.Add(new Reference(name, hint));
            return this;
        }
    }
}