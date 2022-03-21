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
        public readonly RFlagBits Flag;

        public readonly FlagEffectKind Kind;

        [MethodImpl(Inline)]
        public FlagEffect(RFlagBits f, FlagEffectKind k)
        {
            Flag = f;
            Kind = k;
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
    }
}