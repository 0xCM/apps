//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;

    partial class XedRules
    {
        public OpCodeKinds CalcOpCodeKinds()
            => Data(nameof(CalcOpCodeKinds), () => new OpCodeKinds());
    }
}