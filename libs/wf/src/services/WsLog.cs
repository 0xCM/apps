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

        ITextEmitter _Emitter;

        [MethodImpl(Inline)]
        ITextEmitter GetEmitter()
        {
            lock(CreateLock)
            {
                if(_Emitter == null)
                    _Emitter = Path.AsciWriter(!Overwrite).Emitter();
            }
            return _Emitter;
        }

        ITextEmitter Emitter
        {
            [MethodImpl(Inline)]
            get => GetEmitter();
        }

        public void Dispose()
        {
            if(_Emitter != null)
            {
                _Emitter.Flush();
                _Emitter.Dispose();
            }
        }

        object WriterLock = new();

        object CreateLock = new();

        public readonly FS.FilePath Path;

        readonly bool Overwrite;

        WsLog(FS.FilePath dst, bool overwrite)
        {
            Overwrite = overwrite;
            Path = dst;
            //_Emitter = dst.AsciWriter(!overwrite).Emitter();
        }

        public void Flush()
        {
            lock(WriterLock)
            {
                if(_Emitter != null)
                    _Emitter.Flush();
            }
        }

        public void AppendLine()
        {
            lock(WriterLock)
                Emitter.WriteLine();
        }

        public void AppendLine(object content)
        {
            lock(WriterLock)
                Emitter.AppendLine(content);
        }

        public void AppendLineFormat(string pattern, params object[] args)
        {
            lock(WriterLock)
                Emitter.AppendLineFormat(pattern, args);
        }

        public void AppendLine(TableColumns cols, object[] args)
        {
            lock(WriterLock)
                Emitter.AppendLine(cols.Format(args));
        }

        static void AppendLine(TableColumns cols, object[] args, ITextBuffer dst)
            => dst.AppendLine(cols.Format(args));

        public (Count count,FS.FileUri path) TableEmit<T>(TableColumns cols, T[] rows)
        {
            var count = rows.Length;
            if(count != 0)
            {
                var buffer = text.buffer();
                buffer.WriteLine();
                if(text.nonempty(cols.TableName))
                    buffer.AppendLineFormat("# {0}", cols.TableName);
                buffer.AppendLine(RpOps.PageBreak160);
                buffer.AppendLine(cols.Header);
                var type = first(rows)?.GetType() ?? typeof(void);
                if(type.IsNonEmpty())
                {
                    var fields = type.InstanceFields().NonPublic();
                    iter(rows, d => AppendLine(cols, fields.Select(x => x.GetValue(d)),buffer));
                }
                AppendLine(buffer.Emit());
            }
            return (count,Path);
        }
    }
}