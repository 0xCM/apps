//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static Pairings<InstPattern,InstSig> CalcInstSigs(Index<InstPattern> src)
            => data(XedRecord.InstSigs, () => XedSigs.sigs(src));
    }
}