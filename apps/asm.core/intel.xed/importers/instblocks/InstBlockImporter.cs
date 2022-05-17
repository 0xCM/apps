//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedImport
    {
        public partial class InstBlockImporter : IDisposable
        {
            readonly AppServices AppSvc;

            XedPaths XedPaths;

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

            public InstBlockImporter(AppServices svc)
            {
                AppSvc = svc;
                XedPaths = XedPaths.Service;
                File = XedPaths.InstDumpSource().MemoryMap(true);
                BlockSize = (uint)w.DataWidth/8;
                FileSize = (uint)File.Size;
                BlockCount = FileSize/BlockSize;
                Remainder = FileSize%BlockSize;
                Contiguous = BlockCount*BlockSize;
                Parts = BlockCount/Partition;
                PartRemainder = BlockCount%Partition;
            }

            public void Run()
            {
                var stats = EmitLineStats(File);
                var src = AsciLines.lines(File);
                var map = blockmap(src);
                var data = BlockImportDatasets.calc(map,src);
                var records = EmitRecords(data);
                var forms = CalcFormDatasets(data);
                Emit(forms);
                Emit(map);
            }

            ReadOnlySpan<LineStats> CalcLineStats(MemoryFile src)
                => AsciLines.stats(src.View());

            void Emit(LineMap<FormFields> src)
                => EmitLineMap(src, XedPaths.Imports().Path("xed.instblocks.linemap", FileKind.Csv));

            ReadOnlySpan<LineStats> EmitLineStats(MemoryFile src)
            {
                var stats = CalcLineStats(src);
                Emit(stats);
                return stats;
            }

            void Emit(ReadOnlySpan<LineStats> src)
            {
                var dst = text.buffer();
                dst.AppendLine(LineStats.Header);
                for(var i=0; i<src.Length; i++)
                    dst.AppendLine(skip(src,i).Format());
                AppSvc.FileEmit(dst.Emit(), src.Length, XedPaths.Imports().Path(LineStats.TableId, FileKind.Csv));
            }

            Index<InstBlockImport> EmitRecords(BlockImportDatasets src)
            {
                var records = src.Imports.Index().Sort().Resequence();
                AppSvc.TableEmit(records, XedPaths.Imports().Table<InstBlockImport>());
                return records;
            }

            static FormImportDatasets CalcFormDatasets(BlockImportDatasets src)
                => data(nameof(FormImportDatasets), ()=> FormImportDatasets.calc(src));

            void Emit(FormImportDatasets src)
            {
                var dst = XedPaths.Imports().Path("xed.instblocks.detail", FileKind.Txt).Delete();
                using var writer = dst.AsciWriter();
                var emitting = AppSvc.EmittingFile(dst);
                var forms = src.FormSeq().Keys;
                var count = forms.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var form = ref skip(forms,i);
                    if(form.IsEmpty)
                        continue;

                    writer.AppendLine(src.Header(form));
                    writer.WriteLine(RP.PageBreak120);
                    writer.AppendLine(src.Description(form));
                    writer.WriteLine();
                }
                AppSvc.EmittedFile(emitting, count);
            }

            public void EmitLineMap(LineMap<FormFields> data, FS.FilePath dst)
            {
                const string Pattern = "{0,-6} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-6} | {6,-64} | {7}";
                var formatter = Tables.formatter<FormFields>();
                var emitting = AppSvc.EmittingTable<FormFields>(dst);
                using var writer = dst.AsciWriter();
                writer.WriteLine(formatter.FormatHeader());
                for(var i=0u; i<data.IntervalCount; i++)
                {
                    ref readonly var seg = ref data[i];
                    ref readonly var content = ref seg.Id;
                    writer.WriteLine(formatter.Format(content));
                }
                AppSvc.EmittedTable(emitting, data.IntervalCount);
            }

            public void Dispose()
            {
                File.Dispose();
            }
        }
    }
}