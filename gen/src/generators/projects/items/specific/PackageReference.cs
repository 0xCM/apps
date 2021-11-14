//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Gen.Projects
{
    public sealed class PackageReference : ProjectItem
    {
        const string Pattern = "<PackageReference Include=\"{0}\" Version=\"{1}\"/>";

        public string Version {get;}

        public PackageReference(string name, string version)
            : base(nameof(PackageReference))
        {
            Version = version;
        }

        public override string Format()
            => string.Format(Pattern, Name, Version);
    }
}
