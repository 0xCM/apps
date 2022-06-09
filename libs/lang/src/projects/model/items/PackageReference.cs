//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsProjects
    {
        public sealed class PackageReference : ProjectItem
        {
            const string Pattern = "<PackageReference Include=\"{0}\" Version=\"{1}\"/>";

            public string PackageName {get;}

            public string Version {get;}

            public PackageReference(string name, string version)
                : base(nameof(PackageReference))
            {
                PackageName = name;
                Version = version;
            }

            public override string Format()
                => string.Format(Pattern, PackageName, Version);

            public override string ToString()
                => Format();
        }
    }
}