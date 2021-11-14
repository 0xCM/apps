//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Gen.Projects
{
    public sealed class PropertyGroup : ProjectGroup<ProjectProperty>
    {
        public PropertyGroup(params ProjectProperty[] src)
            : base(GroupKind.PropertyGroup, src)
        {

        }

        public PropertyGroup()
            : base(GroupKind.PropertyGroup)
        {

        }

        public PropertyGroup WithAssemblyName(string name)
        {
            Members.Add(new AssemblyName(name));
            return this;
        }

        public PropertyGroup WithOutputType(string name)
        {
            Members.Add(new OutputType(name));
            return this;
        }

        public PropertyGroup WithRuntimeIdentifier(string name)
        {
            Members.Add(new RuntimeIdentifier(name));
            return this;
        }
    }
}