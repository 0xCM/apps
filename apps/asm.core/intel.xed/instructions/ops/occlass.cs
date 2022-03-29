//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedPatterns
    {
        [Op]
        public static OpCodeClass occlass(OpCodeIndex src)
            => occlass(ockind(src));

        [Op]
        public static OpCodeClass occlass(OpCodeKind src)
            => (OpCodeClass)(byte)src;
    }
}