//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using E = Microsoft.Build.Evaluation;

    partial class MsBuild
    {
        public class NetCoreProject
        {
            public string ProjectName {get;}

            public string AssemblyName {get;}

            List<PropertyGroup> PropertyGroups {get;}

            List<ItemGroup> ItemGroups {get;}

            public NetCoreProject(string project, string ass)
            {
                PropertyGroups = new();
                ItemGroups = new();
                ItemGroups.Add(new ItemGroup());
                ProjectName = project;
                AssemblyName = ass;
            }

            public PropertyGroup Props => PropertyGroups[0];

            public ItemGroup Items => ItemGroups[0];


            const string ProjectOpen = "<Project Sdk=\"Microsoft.NET.Sdk\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">";

            const string ProjectClose = "</Project>";
        }
    }
}