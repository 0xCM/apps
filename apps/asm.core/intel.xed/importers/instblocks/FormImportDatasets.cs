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
                var keys = src.FormData.Keys.Index().Sort();
                var forms = dict<InstForm,uint>();
                for(var i=0u; i<keys.Count; i++)
                    forms[keys[i]] = i;
                dst.Sorted = forms;
                iter(keys, form => dst.Include(form, src), pll);
                return dst;
            }

            public ConcurrentDictionary<InstForm,string> Descriptions = new();

            public ConcurrentDictionary<InstForm,string> Headers = new();

            public SortedLookup<InstForm,uint> Sorted;

            void Include(InstForm form, BlockImportDatasets src)
            {
                if(form.IsNonEmpty)
                {
                    var line = src.BlockLines[form];
                    var dst = InstBlockImport.Empty;
                    var content = src.FormData[form];
                    var seq = Sorted[form];
                    Descriptions[form] = content;
                    Headers[form] = string.Format("{0,-64} | {1:D5} | {2:D2} | {3:D6} | {4:D6}", form, seq, line.Lines, line.MinLine, line.MaxLine);
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