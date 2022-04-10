//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        public static VexClass vex(in InstPatternBody src)
        {
            var result = default(VexClass);
            if(src.FieldCount != 0)
            {
                var k = (VexClass)src[0].AsIntLit();

                switch(k)
                {
                    case VexClass.VV1:
                    case VexClass.EVV:
                    case VexClass.XOPV:
                    case VexClass.KVV:
                        result = k;
                    break;
                    default:
                        result = VexClass.None;
                    break;
                }
            }
            return result;
        }
   }
}