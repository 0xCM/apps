//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [MethodImpl(Inline)]
        public static bool reglit(in PatternOp src, out Register dst)
        {
            var result = XedPatterns.first(src.Attribs, OpAttribClass.RegLiteral, out var attrib);
            if(result)
                dst = attrib.ToRegLiteral();
            else
                dst = Register.Empty;
            return result;
        }
    }
}