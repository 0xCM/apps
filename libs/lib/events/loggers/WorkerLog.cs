//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    struct WorkerLog : IWorkerLog
    {
        public FS.FilePath StatusPath {get;}

        public FS.FilePath ErrorPath {get;}

        readonly FileStream Status;

        internal WorkerLog(WfLogConfig config)
        {
            StatusPath = config.StatusPath;
            ErrorPath = config.ErrorPath;
            Status = StatusPath.Stream();
        }

        public void Dispose()
        {
            Status?.Flush();
            Status?.Dispose();
        }

        public void LogStatus(string content)
        {
            try
            {
                FS.write(content + Eol, Status);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }

        public void LogError(string content)
        {
            try
            {
                ErrorPath.AppendLines(content);
                FS.write("[error] ", Status);
                FS.write(RpOps.PageBreak40 + Eol, Status);
                FS.write(content + Eol, Status);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }
    }
}