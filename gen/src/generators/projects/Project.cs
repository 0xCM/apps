//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Gen.Projects
{
    public class Project
    {
        public string ProjectName {get;}

        public string AssemblyName {get;}

        DataList<PropertyGroup> PropertyGroups {get;}

        DataList<ItemGroup> ItemGroups {get;}

        public Project(string project, string ass)
        {
            PropertyGroups = new();
            PropertyGroups.Add(new PropertyGroup().WithAssemblyName(ass));
            ItemGroups = new();
            ItemGroups.Add(new ItemGroup());
            ProjectName = project;
            AssemblyName = ass;
        }

        public PropertyGroup Props => PropertyGroups[0];

        public ItemGroup Items => ItemGroups[0];

        public Project WithProp(ProjectProperty src)
        {
            Props.Members.Add(src);
            return this;
        }

        public Project WithItem(ProjectItem src)
        {
            Items.Members.Add(src);
            return this;
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendLine(ProjectOpen);

            foreach(var g in PropertyGroups)
                g.Render(2u,dst);

            foreach(var g in ItemGroups)
                g.Render(2u,dst);

            dst.AppendLine(ProjectClose);

            return dst.Emit();
        }

        const string ProjectOpen = "<Project Sdk=\"Microsoft.NET.Sdk\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">";

        const string ProjectClose = "</Project>";
    }
}
