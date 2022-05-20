//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntelIntrinsicSvc
    {
        DbSources Sources()
            => AppDb.Sources("intel");

        DbTargets Targets()
            => AppDb.Targets("intrinsics");

        FS.FilePath XmlSource()
            => Sources().Path("intel.intrinsics", FileKind.Xml);

        FS.FilePath DeclPath()
            => Targets().Path(FS.file("intrinsics.declarations", FS.H));

        FS.FilePath AlgPath()
            => Targets().Path(FS.file("intrinsics.algorithms", FS.Txt));

        FS.FilePath TablePath()
            => Targets().Path(FS.file("intel.intrinsics", FS.Csv));

        FS.FilePath TablePath(string type)
            => Targets().Path(FS.file(string.Format("intel.intrinsics.{0}", type), FS.Csv));
    }
}