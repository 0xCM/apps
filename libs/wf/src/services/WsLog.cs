//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WsLog : IDisposable
    {
        public static FS.FilePath target(IProjectWsObsolete project, string name, FileKind kind = FileKind.Log)
            => project.Out() + FS.file(name, kind.Ext());

        public static WsLog open(FS.FilePath dst, bool overwrite = true)
            => new (dst, overwrite);

        public static WsLog open(IProjectWsObsolete project, string name, FileKind kind = FileKind.Log, bool overwrite = true)
            => open(target(project,name,kind), overwrite);

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
    }
}