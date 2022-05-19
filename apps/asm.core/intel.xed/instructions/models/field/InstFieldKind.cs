//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(InstField.KindWidth)]
        public enum InstFieldKind : byte
        {
            None,

            BitLit,

            HexLit,

            InstSeg,

            NeqExpr,

            ExExpr,

            NtCall,
        }
    }
}