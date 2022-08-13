//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Settings;

    using Names = SettingNames;

    public sealed class NugetArchive : DbArchive<NugetArchive>
    {
        static IDbArchive NUGET_PACKAGES()
            => Datasets.archive(setting(ProjectSettings.Default.Path(Names.NUGET_PACKAGES), FS.dir));

        public NugetArchive(IDbArchive home)
            : base(home)
        {
        }

        public NugetArchive()
            : base(NUGET_PACKAGES())
        {
        }
    }   
}