//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedImport
    {
        public unsafe class InstBlockImporter : IDisposable
        {
            MemoryFile File;

            const uint Partition = 128;

            readonly uint FileSize;

            readonly uint BlockSize;

            readonly uint BlockCount;

            readonly uint Remainder;

            readonly uint Contiguous;

            readonly uint Parts;

            readonly uint PartRemainder;

            static W256 w => default;

            public InstBlockImporter(FS.FilePath src)
            {
                BlockSize = (uint)w.DataWidth/8;
                File = src.MemoryMap(true);
                FileSize = (uint)File.Size;
                BlockCount = FileSize/BlockSize;
                Remainder = FileSize%BlockSize;
                Contiguous = BlockCount*BlockSize;
                Parts = BlockCount/Partition;
                PartRemainder = BlockCount%Partition;
            }

            public void Run(IInstBlockReceiver dst)
            {
                process(File,dst);
                dst.Emit();
            }

            void IDisposable.Dispose()
                => File.Dispose();

            public void Emit(LineMap<InstForm> data, FS.FilePath dst)
            {
                const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
                var seq = 0u;

                using var writer = dst.AsciWriter();
                writer.AppendLineFormat(Pattern,"Seq", "Min", "Max", "Lines", "Form");
                for(var i=0u; i<data.IntervalCount; i++)
                {
                    ref readonly var seg = ref data[i];
                    writer.AppendLineFormat(Pattern, seq++, seg.MinLine, seg.MaxLine, seg.LineCount, seg.Id);
                }
            }
        }
    }
}