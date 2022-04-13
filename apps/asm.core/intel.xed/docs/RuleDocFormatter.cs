//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDocs
    {
        public class RuleDocFormatter
        {
            readonly RuleTables Rules;

            XedPaths XedPaths;

            public RuleDocFormatter(RuleDoc doc)
            {
                Rules = doc.Rules;
                XedPaths = XedPaths.Service;
            }

            void Render(in TableSpec src, ITextBuffer dst)
            {
                dst.AppendLine(TableHeader(src.Sig));
                dst.AppendLine();
                dst.AppendLineFormat("{0}(){{", src.Sig.ShortName);
                for(var i=0; i<src.RowCount; i++)
                    dst.IndentLine(4, src[i].Format());
                dst.AppendLine("}");
                dst.AppendLine();
            }

            public string Format()
            {
                var dst = text.buffer();
                var sigs = Rules.Sigs();
                for(var i=0; i<sigs.Length; i++)
                    Render(Rules.Spec(sigs[i]), dst);
                return dst.Emit();
            }
        }
    }
}