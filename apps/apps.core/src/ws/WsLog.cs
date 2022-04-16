//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Datasets;

    public class WsLog : IDisposable
    {
        public static FS.FilePath target(IProjectWs project, string name, FileKind kind = FileKind.Log)
            => project.Out() + FS.file(name, kind.Ext());

        public static FS.FilePath target(IProjectWs project, string scope, string name, FileKind kind = FileKind.Log)
            => project.Out(scope) + FS.file(name, kind.Ext());

        public static WsLog open(FS.FilePath dst, bool overwrite = true)
            => new (dst, overwrite);

        public static WsLog open(IProjectWs project, string name, FileKind kind = FileKind.Log, bool overwrite = true)
            => open(target(project,name,kind), overwrite);

        public static WsLog open(IProjectWs project, string scope, string name, FileKind kind = FileKind.Log, bool overwrite = true)
            => open(target(project, scope, name, kind), overwrite);

        ITextEmitter Emitter;

        object Locker;

        public readonly FS.FilePath Path;

        WsLog(FS.FilePath dst, bool overwrite)
        {
            Locker = new object();
            Path = dst;
            Emitter = dst.AsciWriter(!overwrite).Emitter();
        }

        public void AppendLine()
        {
            lock(Locker)
                Emitter.WriteLine();
        }

        public void AppendLine(object content)
        {
            lock(Locker)
                Emitter.AppendLine(content);
        }

        public void AppendLineFormat(string pattern, params object[] args)
        {
            lock(Locker)
                Emitter.AppendLineFormat(pattern, args);
        }

        public void AppendLine(TableColumns cols, object[] args)
        {
            AppendLine(cols.Format(args));
        }

        public (Count count,FS.FileUri path) TableEmit<T>(TableColumns cols, T[] rows)
        {
            var count = rows.Length;
            if(count != 0)
            {
                AppendLine();
                if(text.nonempty(cols.TableName))
                    AppendLineFormat("# {0}", cols.TableName);
                AppendLine(RP.PageBreak160);
                AppendLine(cols.Header);
                var type = first(rows)?.GetType() ?? typeof(void);
                if(type.IsNonEmpty())
                {
                    var fields = type.InstanceFields().NonPublic();
                    iter(rows, d => AppendLine(cols, fields.Select(x => x.GetValue(d))));
                }
            }
            return (count,Path);
        }


        public void Dispose()
        {
            Emitter?.Flush();
            Emitter?.Dispose();
        }
    }
}