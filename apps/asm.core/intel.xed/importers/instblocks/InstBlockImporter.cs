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

            public InstImportBlocks CalcImports()
                => CalcImports(InstDumpFile());

            public InstImportBlocks CalcImports(MemoryFile src)
                => BlockImportDatasets.calc(src);

            public ReadOnlySpan<LineStats> CalcStats(MemoryFile src)
                => BlockImportDatasets.stats(src);

            public void EmitStats(ReadOnlySpan<LineStats> src)
                => Emit(src);

            // public void Run()
            // {
            //     var imports = CalcImports(InstDumpFile());
            //     var stats = BlockImportDatasets.stats(InstDumpFile());
            //     Emit(imports.Imports);
            //     Emit(stats);
            //     EmitBlockDetail(imports);
            //     Emit(imports.LineMap);
            // }

            public void Import(InstImportBlocks src)
            {
                Emit(src.Imports);
                EmitBlockDetail(src);
                Emit(src.LineMap);
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

            void EmitBlockDetail(InstImportBlocks src)
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