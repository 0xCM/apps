//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public sealed class ItemGroup : ProjectGroup<IProjectItem>
        {
            public ItemGroup(params IProjectItem[] src)
                : base(GroupKind.ItemGroup, src)
            {

            }

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
}