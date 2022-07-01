//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class DbCmd : AppCmdService<DbCmd>
    {
        IJobArchive Jobs() => new JobArchive(DbArchive().Root + FS.folder("jobs"));

        [CmdOp("jobs/types")]
        void ListJobTypes()
        {
            var db = AppDb.DbRoot();
            Write(db.Root);
            Write(RP.PageBreak80);
            var jobs = db.Sources("jobs");
            Write($"Jobs: {jobs.Root}");

            jobs.Root.Folders(true).Iter(f => Write(f.Format()));
            //iter(jobs.Files(),f => Write(f.ToUri()));

            // var db = (IDbArchive)DbArchive;
            // var jobs = db.Sources("jobs");
            // iter(jobs.Files(), file => Write(file.ToUri()));

            // iter(FS.dir("d:/views/db/jobs").Files(true), f => Write(f.ToUri()));
        }
    }
}