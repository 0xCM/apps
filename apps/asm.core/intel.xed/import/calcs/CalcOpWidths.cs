//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedImport
    {
        public Index<OpWidthRecord> CalcOpWidths()
            => _OpWidths;

        static Outcome ParseWidthValue(string src, out ushort bits)
        {
            var result = Outcome.Success;
            bits = 0;
            var i = text.index(src, "bits");
            if(i > 0)
                result = DataParser.parse(text.left(src,i), out bits);
            else
            {
                result = DataParser.parse(src, out ushort bytes);
                if(result)
                    bits = (ushort)(bytes*8);
            }
            return result;
        }
    }
}