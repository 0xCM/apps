//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedFields
    {
        public readonly struct ModKind
        {
            [MethodImpl(Inline)]
            public static ModKind specific(uint2 src)
                => new ModKind((ModIndicator)(byte)src + 1);

            [MethodImpl(Inline)]
            public static ModKind any()
                => new ModKind(ModIndicator.ANY);

            [MethodImpl(Inline)]
            public static ModKind constrain()
                => new ModKind(ModIndicator.NE3);

            [MethodImpl(Inline)]
            public static ModKind none()
                => default;
            readonly ModIndicator Indicator;

            [MethodImpl(Inline)]
            public ModKind(ModIndicator indicator)
            {
                Indicator = indicator;
            }

            public string Format()
            {
                var dst = EmptyString;
                switch(Indicator)
                {
                    case ModIndicator.MOD0:
                    case ModIndicator.MOD1:
                    case ModIndicator.MOD2:
                    case ModIndicator.MOD3:
                        dst = ((byte)Indicator).ToString();
                    break;
                    case ModIndicator.NE3:
                        dst = "!3";
                    break;
                    case ModIndicator.ANY:
                        dst = "mm";
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator ModKind(ModIndicator src)
                => new ModKind(src);
        }
    }
}