//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedSeq
    {
        public readonly struct SeqStep
        {
            public readonly byte Index;

            public readonly SeqStepKind Kind;

            public readonly SeqEffect Effect;

            [MethodImpl(Inline)]
            public SeqStep(SeqStepKind kind, byte index, SeqEffect effect)
            {
                Kind = kind;
                Index = index;
                Effect = effect;
            }

            public string Format()
                => string.Format("{0:D2} {1}_{2}", Index, Kind, Effect);

            public override string ToString()
                => Format();

        }
    }
}
