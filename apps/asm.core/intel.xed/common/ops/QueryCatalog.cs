//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;
    using static XedModels;

    partial class IntelXed
    {
        public ReadOnlySpan<XedQueryResult> QueryCatalog(string monic, bool emit = true)
        {
            const string RenderPattern = "class:{0,-24} form:{1,-32} category:{2,-16} isa:{3,-16} ext:{4,-16} attribs:{5}";
            var src = LoadFormImports();
            var types = Symbols.index<IFormType>();
            var cats = Symbols.index<CategoryKind>();
            var _isa = Symbols.index<IsaKind>();
            var classes = Symbols.index<IClass>();
            var extensions = Symbols.index<ExtensionKind>();
            var count = src.Length;
            var dst = list<XedQueryResult>();
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(src,i);
                if(form.InstForm.IsNonEmpty)
                    continue;

                ref readonly var isa = ref _isa[form.IsaKind];
                ref readonly var ext = ref extensions[form.Extension];
                ref readonly var cat = ref cats[form.Category];

                if(form.InstClass.Classifier.StartsWith(monic, StringComparison.InvariantCultureIgnoreCase))
                {
                    var result = XedQueryResult.Empty;
                    result.SearchPattern = monic;
                    result.InstClass = form.InstClass;
                    result.InstForm = form.InstForm;
                    result.Isa = isa.Kind;
                    result.Extension = ext.Kind;
                    result.Attributes = form.Attributes;
                    dst.Add(result);
                }
            }
            var path = ProjectDb.Subdir("xed/queries") + FS.file(monic, FS.Csv);
            var records = dst.ViewDeposited();
            if(emit)
                TableEmit(records, XedQueryResult.RenderWidths, path);
            return records;
        }
    }
}
