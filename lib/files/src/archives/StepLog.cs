//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    public class StepLog : IDisposable
    {
        public static StepLog create(IEnvPaths paths, WfStepId step, FS.FileExt ext)
            => new StepLog(paths.StepLogPath(step, ext));

        public static StepLog create<T>(IEnvPaths paths, WfStepId step, T subject, FS.FileExt ext)
            => new StepLog(paths.StepLogPath(step, subject, ext));

        public static StepLog create(StreamWriter writer)
            => new StepLog(writer);

        public static StepLog create(FS.FilePath dst)
            => new StepLog(dst);

        StreamWriter Writer;

        public StepLog(FS.FilePath dst)
        {
            Writer = dst.Writer();
        }

        public StepLog(StreamWriter writer)
        {
            Writer = writer;
        }

        public void Dispose()
        {
            Writer?.Flush();
            Writer?.Dispose();
        }

        public void WriteLine()
        {
            Writer.WriteLine();
        }

        public void WriteLine(object content)
        {
            Writer.WriteLine(content);
        }

        public void WritteLineFormat(string pattern, params object[] args)
        {
            Writer.WriteLine(string.Format(pattern,args));
        }
    }
}