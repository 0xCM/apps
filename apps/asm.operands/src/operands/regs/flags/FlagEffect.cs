//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public readonly struct FlagEffect
    {
        public readonly RFlagIndex Flag;

        public readonly FlagEffectKind Effect;

        [MethodImpl(Inline)]
        public FlagEffect(RFlagIndex f, FlagEffectKind k)
        {
            Flag = f;
            Effect = k;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Flag == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Flag != 0;
        }

        public string Format()
            => EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FlagEffect((RFlagIndex f, FlagEffectKind k) src)
            => new FlagEffect(src.f, src.k);
    }
}