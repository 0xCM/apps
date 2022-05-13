//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedImport : AppService<XedImport>
    {
        XedPaths XedPaths => Service(Wf.XedPaths);

        AppServices AppSvc => Service(Wf.AppServices);

        AppDb AppDb => Service(Wf.AppDb);

        public void Run()
        {
            ImportInstBlocks();
        }

        public void ImportInstBlocks()
        {
            var src = AppDb.Sources("sources").Scoped("intel").Path("xed-dump",FileKind.Txt);
            var dst = new InstBlockReceiver(AppSvc);
            using var importer = new InstBlockImporter(src);
            importer.Run(dst);
        }
    }
}