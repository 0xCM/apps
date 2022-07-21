//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DbCmd : AppCmdService<DbCmd>
    {
        [CmdOp("jobs/types")]
        void ListJobTypes()
        {
            var db = AppDb.DbRoot();
            Write(db.Root);
            Write(RpOps.PageBreak80);
            var jobs = db.Sources("jobs");
            Write($"Jobs: {jobs.Root}");

            jobs.Root.Folders(true).Iter(f => Write(f.Format()));
        }

        [CmdOp("app/deps")]
        void Deps()
        {
            var src = JsonDeps.parse(ExecutingPart.Component);
            src.RuntimeLibs().Iter(x => Write(x));
        }

        [CmdOp("app/deploy")]
        void Deploy()
        {
            var dst = ApiPack.create().Context().Targets("bin");
            var src = ExecutingPart.Component.Path().FolderPath;
            Archives.robocopy(src,dst.Root);
        }
    }
}