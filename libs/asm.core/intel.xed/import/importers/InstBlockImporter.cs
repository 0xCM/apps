//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedImport
    {
        public class InstBlockImporter : AppService<InstBlockImporter>
        {
            XedPaths XedPaths => Wf.XedPaths();

            AppSvcOps AppSvc => Wf.AppSvc();

            public bool PllExec
            {
                [MethodImpl(Inline)]
                get => AppData.get().PllExec();
            }

            public static ReadOnlySpan<LineStats> stats(MemoryFile src)
                => AsciLines.stats(src.View(), 400000);

            public void EmitStats(ReadOnlySpan<LineStats> src)
                => Emit(src);

            public void Import(InstImportBlocks src)
            {
                XedPaths.Imports().Delete();
                exec(PllExec,
                    () => EmitRecords(src),
                    () => EmitBlockDetail(src),
                    () => EmitLineMap(src),
                    () => EmitStats(stats(src.DataSource))
                );
            }

            void EmitLineMap(InstImportBlocks src)
                => EmitLineMap(src.LineMap);

            void Emit(ReadOnlySpan<LineStats> src)
            {
                var dst = text.buffer();
                dst.AppendLine(Z0.LineStats.Header);
                for(var i=0; i<src.Length; i++)
                    dst.AppendLine(skip(src,i).Format());
                AppSvc.FileEmit(dst.Emit(), src.Length, XedPaths.Imports().Path(Z0.LineStats.TableId, FileKind.Csv));
            }

            void EmitRecords(InstImportBlocks src)
            {
                AppSvc.TableEmit(src.Imports, XedPaths.Imports().Table<InstBlockImport>());
                var file = FS.file($"{Tables.filename<InstBlockImport>().WithoutExtension.Format()}.duplicates", FS.Csv);
                AppSvc.TableEmit(src.Duplicates, XedPaths.Imports().Path(file));
            }

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

            void EmitLineMap(LineMap<InstBlockLineSpec> data)
            {
                const string Pattern = "{0,-6} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-6} | {6,-64} | {7}";
                var dst = XedPaths.Imports().Table<InstBlockLineSpec>();
                var formatter = Tables.formatter<InstBlockLineSpec>();
                var emitting = AppSvc.EmittingTable<InstBlockLineSpec>(dst);
                using var writer = dst.AsciWriter();
                writer.WriteLine(formatter.FormatHeader());
                for(var i=0u; i<data.IntervalCount; i++)
                    writer.WriteLine(formatter.Format(data[i].Id));
                AppSvc.EmittedTable(emitting, data.IntervalCount);
            }
        }
    }
}