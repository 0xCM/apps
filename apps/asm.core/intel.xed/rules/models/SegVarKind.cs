//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum SegVarKind : ulong
        {
            None = 0,

            ssss_dddd = SegVar.FirstKind,

            ss_iii_bbb = ssss_dddd + 1,

            ss_iii_bb = ss_iii_bbb + 1,
        }
    }
}