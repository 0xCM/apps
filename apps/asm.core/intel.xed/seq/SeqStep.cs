//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial struct XedModels
    {
        public readonly struct SeqStep
        {
            public readonly RuleName Data;

            public readonly SeqEffect Effect;

            [MethodImpl(Inline)]
            public SeqStep(RuleName nt, SeqEffect effect)
            {
                Data = nt;
                Effect = effect;
            }

            [MethodImpl(Inline)]
            public static implicit operator SeqStep((RuleName kind, SeqEffect effect) src)
                => new SeqStep(src.kind,src.effect);

            public string Format()
                => string.Format("{0}_{1}", (RuleName)Data, Effect);

            public override string ToString()
                => Format();
        }
    }
}
