//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static MinidumpRecords;

    public sealed partial class Minidump : IDisposable
    {
        public static Minidump open(FS.FilePath src)
            => new Minidump(src);

        readonly MemoryFile Source;

        Minidump(FS.FilePath src)
        {
            Source = MemoryFiles.map(src);
        }

        public ref readonly DumpFileHeader Header
        {
            [MethodImpl(Inline)]
            get => ref Source.Skip<DumpFileHeader>(0);
        }

        public void Dispose()
        {
            Source.Dispose();
        }
    }
}