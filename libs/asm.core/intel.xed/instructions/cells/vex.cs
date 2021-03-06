//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedLiterals;

    partial class XedRules
    {
        partial struct InstCells
        {
            public static XedVexClass vex(in InstCells src)
            {
                var result = XedVexClass.None;
                if(src.Count != 0)
                {
                    var k = (XedVexClass)src.First.AsByte();
                    switch(k)
                    {
                        case XedVexClass.VV1:
                        case XedVexClass.EVV:
                        case XedVexClass.XOPV:
                        case XedVexClass.KVV:
                            result = k;
                        break;
                    }
                }
                return result;
            }
        }
    }
}