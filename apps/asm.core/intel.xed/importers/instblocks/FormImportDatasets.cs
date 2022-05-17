//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedImport
    {
        class FormImportDatasets
        {
            public static FormImportDatasets calc(BlockImportDatasets src, bool pll = true)
            {
                var dst = new FormImportDatasets();
                var keys = src.Data.Keys.Index().Sort();
                var forms = dict<InstForm,uint>();
                for(var i=0u; i<keys.Count; i++)
                    forms[keys[i]] = i;
                dst.Sorted = forms;
                iter(keys, form => dst.Include(form, src), pll);
                return dst;
            }

            ConcurrentDictionary<InstForm,string> Descriptions = new();

            ConcurrentDictionary<InstForm,string> Headers = new();

            SortedLookup<InstForm,uint> Sorted;

            void Include(InstForm form,BlockImportDatasets src)
            {
                if(form.IsNonEmpty)
                {
                    var dst = InstBlockImport.Empty;
                    var range = src.Received[form];
                    var content = src.Data[form];
                    var seq = Sorted[form];
                    Descriptions[form] = content;
                    Headers[form] = string.Format("{0,-64} | {1:D5} | {2:D2} | {3:D6} | {4:D6}", form, seq, range.LineCount, (uint)range.MinLine, (uint)range.MaxLine);
                }
            }

            public string Description(InstForm form)
                => Descriptions[form];

            public string Header(InstForm form)
                => Headers[form];

            public ref readonly SortedLookup<InstForm,uint> FormSeq()
                => ref Sorted;
        }
    }
}