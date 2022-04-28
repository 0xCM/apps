//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static MemDb;

    public partial class XedDb : AppService<XedDb>
    {
        public static DbSvc services(IWfRuntime wf)
            => service(DbSvc.create);

        new XedPaths Paths => Service(Wf.XedPaths);

        public DbSvc DbServices => Service(() => services(Wf));

        public DbObjects Objects => DbServices.Objects;

        public DbRender Render => DbServices.ObjRender;

        public DbSchema Schema => DbServices.Schema;

        public FS.FolderPath Location => Paths.Targets() + FS.folder("db");

        public FS.FilePath TargetPath(string name, FileKind kind)
            => Location + FS.file(string.Format("xed.db.{0}",name), kind.Ext());
    }
}