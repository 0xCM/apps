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

    partial class XedFields
    {
        public static VexClass vex(in InstFields src)
        {
            var result = VexClass.None;
            if(src.Count != 0)
            {
                var k = (VexClass)src.First.AsIntLit();
                switch(k)
                {
                    case VexClass.VV1:
                    case VexClass.EVV:
                    case VexClass.XOPV:
                    case VexClass.KVV:
                        result = k;
                    break;
                }
            }
            return result;
        }
   }
}