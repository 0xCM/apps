//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedSeq
    {
        public struct SeqType
        {
            public readonly SeqKind Kind;

            public readonly SeqEffect Effect;

            [MethodImpl(Inline)]
            public SeqType(SeqKind kind, SeqEffect effect)
            {
                Kind = kind;
                Effect = effect;
            }
        }
    }
}
