//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static MinidumpRecords;

    public sealed partial class Minidump : IDisposable
    {
        readonly IWfRuntime Wf;

        readonly MemoryFile Source;

        public static Minidump open(IWfRuntime wf, FS.FilePath src)
            => new Minidump(wf,src);

        Minidump(IWfRuntime wf, FS.FilePath src)
        {
            Wf = wf;
            Source = MemoryFiles.map(src);
            Wf.Status($"Mapped file {Source.Path} to process memory based at {Source.BaseAddress}");
        }

        public ref readonly DumpFileHeader Header
        {
            [MethodImpl(Inline)]
            get => ref Source.One<DumpFileHeader>(0);
        }

        public void Dispose()
        {
            Source.Dispose();
        }

        public void Summarize()
        {
            var src = Wf.Db().DumpPath("capture");
            if(src.Exists)
            {
                var formatter = Tables.formatter<DumpFileHeader>();
                using var md = Minidump.open(Wf, src);
                var header = formatter.Format(md.Header, RecordFormatKind.KeyValuePairs);
                Wf.Row(header);
            }
            else
                Wf.Error($"The file {src} does not exist");
        }
    }
}