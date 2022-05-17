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
        public partial class InstBlockImporter
        {
            readonly AppServices AppSvc;

            XedPaths XedPaths;

            public InstBlockImporter(AppServices svc)
            {
                AppSvc = svc;
                XedPaths = XedPaths.Service;
            }

            MemoryFile InstDumpFile()
                => data(nameof(InstDumpFile), () => XedPaths.InstDumpSource().MemoryMap(true));

            public void Run()
            {
                var src = InstDumpFile();
                var data = BlockImportDatasets.calc(src);
                var stats = BlockImportDatasets.stats(src);
                Emit(data.Imports);
                Emit(stats);
                EmitBlockDetail(data);
                Emit(data.LineMap);

                // var datasets = BlockImportDatasets.datasets(src);
                //var records = CalcRecords(datasets);
                // var forms = CalcFormDatasets(datasets);
                // Emit(records);
                // Emit(stats);
                // EmitBlockDetail(forms);
                // Emit(datasets.MappedForms);
            }

            void Emit(LineMap<InstBlockLineSpec> src)
                => EmitLineMap(src, XedPaths.Imports().Table<InstBlockLineSpec>());

            void Emit(ReadOnlySpan<LineStats> src)
            {
                var dst = text.buffer();
                dst.AppendLine(Z0.LineStats.Header);
                for(var i=0; i<src.Length; i++)
                    dst.AppendLine(skip(src,i).Format());
                AppSvc.FileEmit(dst.Emit(), src.Length, XedPaths.Imports().Path(Z0.LineStats.TableId, FileKind.Csv));
            }

            void Emit(ReadOnlySpan<InstBlockImport> src)
                => AppSvc.TableEmit(src, XedPaths.Imports().Table<InstBlockImport>());

            // static Index<InstBlockImport> CalcRecords(BlockImportDatasets src)
            //     => src.BlockImports.Index().Sort().Resequence();

            static FormImportDatasets CalcFormDatasets(BlockImportDatasets src)
                => data(nameof(FormImportDatasets), ()=> FormImportDatasets.calc(src));

            void EmitBlockDetail(ImportedBlocks src)
            {
                var path = XedPaths.Imports().Path("xed.instblocks.detail", FileKind.Txt);
                var emitter = text.emitter();
                var forms = src.Forms.Keys;
                var count = forms.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var form = ref skip(forms,i);
                    if(form.IsEmpty)
                        continue;

                    emitter.AppendLine(src.Header(form));
                    emitter.WriteLine(RP.PageBreak120);
                    emitter.AppendLine(src.Description(form));
                    emitter.WriteLine();
                }
                AppSvc.FileEmit(emitter.Emit(), count, path);
            }

            void EmitLineMap(LineMap<InstBlockLineSpec> data, FS.FilePath dst)
            {
                const string Pattern = "{0,-6} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-6} | {6,-64} | {7}";
                var formatter = Tables.formatter<InstBlockLineSpec>();
                var emitting = AppSvc.EmittingTable<InstBlockLineSpec>(dst);
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
        }
    }
}