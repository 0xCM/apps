//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [SymSource(xed)]
        public enum DispExprKind : byte
        {
            [Symbol("d/8")]
            D8 = NativeSizeCode.W8,

            [Symbol("d/16")]
            D16 = NativeSizeCode.W16,

            [Symbol("d/32")]
            D32 = NativeSizeCode.W32,

            [Symbol("d/64")]
            D64 = NativeSizeCode.W64
        }
    }
}