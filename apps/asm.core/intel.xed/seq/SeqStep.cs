//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct SeqStep
        {
            readonly ushort Data;

            public readonly SeqEffect Effect;

            [MethodImpl(Inline)]
            public SeqStep(NontermKind kind, SeqEffect effect)
            {
                Data = (ushort)kind;
                Effect = effect;
            }

            [MethodImpl(Inline)]
            public SeqStep(SeqKind kind, SeqEffect effect)
            {
                Data = (ushort)kind;
                Effect = effect;
            }

            [MethodImpl(Inline)]
            public static implicit operator SeqStep((SeqKind kind, SeqEffect effect) src)
                => new SeqStep(src.kind,src.effect);

            [MethodImpl(Inline)]
            public static implicit operator SeqStep((NontermKind kind, SeqEffect effect) src)
                => new SeqStep(src.kind,src.effect);

            public string Format()
                => string.Format("{0}_{1}",
                    Data < (ushort)SeqKind.ISA
                    ? (Nonterminal)Data
                    : (SeqKind)Data , Effect);

            public override string ToString()
                => Format();
        }
    }
}
