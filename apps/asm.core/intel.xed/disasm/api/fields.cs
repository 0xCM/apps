//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    using R = XedRules;

    partial class XedDisasm
    {
        public const string OpDetailRenderPattern = "{0,-4} | {1,-8} | {2,-24} | {3,-10} | {4,-12} | {5,-12} | {6,-12} | {7,-12}";

        static string[] OpColPatterns = new string[]{"Op{0}", "Op{0}Name", "Op{0}Val", "Op{0}Action", "Op{0}Vis", "Op{0}Width", "Op{0}WKind", "Op{0}Selector"};

        public static string OpDetailHeader(int index)
            => string.Format(OpDetailRenderPattern, OpColPatterns.Select(x => string.Format(x, index)));

        public static Index<R.FieldValue> fields(in DisasmLineBlock src)
        {
            var data = props(src);
            var count = data.Count;
            var dst = alloc<R.FieldValue>(count);
            var state = RuleState.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var prop = ref data[i];
                if(XedParsers.parse(prop.Key, out FieldKind kind))
                    seek(dst,i) = XedFields.update(prop.Value, kind, ref state);
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), prop.Key));
            }

            return dst;
        }
    }
}