//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedDisasmSvc
    {
        static Outcome ParseOpInfo(string src, out DisasmOpInfo dst)
        {
            dst = default;
            if(text.length(src) < 3)
                return (false,RP.Empty);
            var result = Outcome.Success;
            var data = span(src);

            var idx = text.trim(text.left(src,2));
            result = DataParser.parse(idx, out dst.Index);
            if(result.Fail)
                return (false,AppMsg.ParseFailure.Format(nameof(dst.Index), idx));

            var aspects = text.trim(text.right(src,2));
            var parts = text.split(aspects, Chars.FSlash);
            if(parts.Length != 6)
                return (false, string.Format("Unexpected number of operand aspects in {0}", aspects));

            var i=0;
            result = DataParser.eparse(skip(parts,i++), out dst.Kind);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.Kind), skip(parts,i-1)));

            result = DataParser.eparse(skip(parts,i++), out dst.Action);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out dst.WidthType);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out dst.Visiblity);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out dst.Lookup);
            if(result.Fail)
                return result;

            result = DataParser.parse(skip(parts,i++), out dst.Prop2);
            if(result.Fail)
                return result;

            return result;
        }
    }
}