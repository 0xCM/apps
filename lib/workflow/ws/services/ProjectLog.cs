//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    public class ProjectLog : IDisposable
    {
        static ProjectLog create(FS.FilePath dst)
            => new ProjectLog(dst);

        public static ProjectLog open(IProjectWs project, string name)
            => create(project.Out() + FS.file(name, FS.Log));

        public static ProjectLog open(IProjectWs project, string scope, string name)
            => create(project.Out(scope) + FS.file(name, FS.Log));

        StreamWriter Writer;

        object Locker;

        public FS.FilePath Target {get;}

        ProjectLog(FS.FilePath dst)
        {
            Target = dst;
            Writer = dst.AsciWriter(true);
            Locker = new object();
        }

        public void WriteLine()
        {
            lock(Locker)
            {
                Writer.WriteLine();
            }
        }

        public void WriteLine(object content)
        {
            lock(Locker)
            {
                Writer.WriteLine(content);
            }
        }

        public void WriteLineFormat(string pattern, params object[] args)
        {
            lock(Locker)
            {
                Writer.WriteLine(string.Format(pattern,args));
            }
        }


        public void Dispose()
        {
            Writer?.Flush();
            Writer?.Dispose();
        }
    }
}