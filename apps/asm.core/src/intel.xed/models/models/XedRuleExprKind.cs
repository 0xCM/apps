//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum XedRuleExprKind : byte
        {
            None,

            RuleDeclaration,

            SeqDeclaration,

            EncodeStep,

            DecodeStep,

            Invocation,
        }
    }
}