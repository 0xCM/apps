//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public sealed class ProjectReference : ProjectItem
        {
            const string Pattern = "<ProjectReference Include=\"{0}\"/>";

            public string ProjectName {get;}

            public ProjectReference(string name)
                : base(nameof(ProjectReference))
            {
                ProjectName = name;
            }

            public override string Format()
                => string.Format(Pattern, ProjectName);

            public override string ToString()
                => Format();
        }
    }
}