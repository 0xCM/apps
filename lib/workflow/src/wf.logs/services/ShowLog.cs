//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;

    public readonly struct ShowLog : IDisposable
    {
        readonly IWfRuntime Wf;

        readonly Lazy<StreamWriter> _Writer;

        readonly Lazy<ITextBuffer> _Buffer;

        StreamWriter Writer => _Writer.Value;

        readonly FS.FilePath Target;

        [MethodImpl(Inline)]
        internal ShowLog(IWfRuntime wf, FS.FilePath dst)
        {
            Wf = wf;
            _Writer = core.lazy(() => dst.Writer());
            Target = dst;
            _Buffer = core.lazy(() => text.buffer());
        }

        public void Dispose()
        {
            if(_Writer.IsValueCreated)
            {
                Writer.Flush();
                Writer.Dispose();
            }
        }

        public ITextBuffer Buffer
        {
            [MethodImpl(Inline)]
            get => _Buffer.Value;
        }

        public void Show<T>(T src)
        {
            Writer.WriteLine(string.Format("{0}",src));
            Wf.Row(src);
        }

        public void Show(ReadOnlySpan<char> src)
        {
            Show(text.format(src));
        }

        public void Title<T>(T name)
        {
            Show(EmptyString);
            Show(name);
            Show(RP.PageBreak120);
        }

        public void Row<T>(int index, T data)
            => Show(string.Format("{0:D4}: {1}", index, data));

        public void Row<T>(uint index, T data)
            => Show(string.Format("{0:D4}: {1}", index, data));

        public void Row<K,T>(int index, K kind, T data)
            => Show(string.Format("{0:D4}: {1,-12} | {2}", index, kind, data));

        public void Row<K,T>(uint index, K kind, T data)
            => Show(string.Format("{0:D4}: {1,-12} | {2}", index, kind, data));

        public void Property<T>(string name, T value)
            => Show(string.Format("{0}:{1}", name, value));

        public void ShowBuffer()
        {
            var src = Buffer.Emit();
            Writer.WriteLine(string.Format("{0}", src));
            Wf.Row(src);
        }
    }
}