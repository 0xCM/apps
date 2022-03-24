//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static LegacyMapKind? lmap(byte code)
            => code <= 4? (LegacyMapKind)code : null;

        public static LegacyMapKind lmap(AsmOcValue value)
        {
            var dst = default(LegacyMapKind);
            if(value[0] == 0x0F)
            {
                if(value[1] == 0x38)
                    dst = LegacyMapKind.LEGACY_MAP2;
                else if(value[1] == 0x3A)
                    dst = LegacyMapKind.LEGACY_MAP3;
                else
                    dst = LegacyMapKind.LEGACY_MAP1;
            }
            else
                dst = LegacyMapKind.LEGACY_MAP0;
            return dst;
        }
    }
}