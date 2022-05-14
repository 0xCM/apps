//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedImport
    {
        public class InstBlockReceiver : IInstBlockReceiver
        {
            ConcurrentDictionary<InstForm,LineInterval<InstForm>> Received = new();

            ConcurrentDictionary<InstForm,string> Data = new();

            ConcurrentBag<InstBlockImport> Imports = new();

            SortedLookup<InstForm,uint> FormSeq;

            ConcurrentDictionary<InstForm,string> Descriptions = new();

            ConcurrentDictionary<InstForm,string> Headers = new();

            readonly AppServices AppSvc;

            XedPaths XedPaths;

            public InstBlockReceiver(AppServices svc)
            {
                AppSvc = svc;
                XedPaths = XedPaths.Service;
            }

            void Parse(InstBlock src)
            {
                var dst = InstBlockImport.Empty;
                if(src.Form.IsNonEmpty)
                {
                    var result = parse(src, out dst);
                    if(result)
                    {
                        Imports.Add(dst);
                        AppSvc.Write(string.Format("{0,-6} | {1}", dst.Seq, dst.Pattern.Format()));
                    }
                    else
                    {
                        //AppSvc.Warn(result.Message);
                    }
                }

            }

            public void Accept(InstBlock block)
            {
                Received.TryAdd(block.Range.Id, block.Range);
                var emitter = text.emitter();
                block.Render(emitter);
                var emitted = emitter.Emit();
                Data.TryAdd(block.Range.Id, emitted);
            }

            void Process(InstForm form)
            {
                if(form.IsNonEmpty)
                {
                    var dst = InstBlockImport.Empty;
                    var range = Received[form];
                    var content = Data[form];
                    var seq = FormSeq[form];
                    Descriptions[form] = content;
                    Headers[form] = string.Format("{0,-64} | {1:D5} | {2:D2} | {3:D6} | {4:D6}", form, seq, range.LineCount, (uint)range.MinLine, (uint)range.MaxLine);
                }
            }

            Index<InstForm> CalcFormSeq()
            {
                var keys = Data.Keys.Index().Sort();
                var dst = dict<InstForm,uint>();
                for(var i=0u; i<keys.Count; i++)
                    dst[keys[i]] = i;
                FormSeq = dst;
                return keys;
            }

            public void Emit()
            {
                var forms = CalcFormSeq();
                iter(forms,Process,true);
                var dst = XedPaths.Imports().Path("instblocks", FileKind.Txt);
                using var writer = dst.AsciWriter();
                var emitting = AppSvc.EmittingFile(dst);
                for(var i=0u; i<forms.Count; i++)
                {
                    ref readonly var key = ref forms[i];
                    if(key.IsEmpty)
                        continue;

                    writer.AppendLine(Headers[key]);
                    writer.WriteLine(RP.PageBreak120);
                    writer.AppendLine(Descriptions[key]);
                    writer.WriteLine();
                }

                AppSvc.EmittedFile(emitting, forms.Count);
            }
        }
    }
}