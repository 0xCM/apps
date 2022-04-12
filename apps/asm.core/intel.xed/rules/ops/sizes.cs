//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.EOSZ;

    partial class XedRules
    {
        [Op]
        public static byte widths(EOSZ src)
        {
            var dst = z8;
            switch(src)
            {
                case EOSZ8:
                    dst |= 8;
                break;
                case EOSZ16:
                    dst |= 16;
                break;
                case EOSZ32:
                    dst |= 32;
                break;
                case EOSZ64:
                    dst |= 64;
                break;
                case EOSZNot16:
                    dst |= 8;
                    dst |= 32;
                    dst |= 64;
                break;
                case EOSZNot64:
                    dst |= 8;
                    dst |= 16;
                    dst |= 32;
                break;
            }

            return z8;
        }
    }
}