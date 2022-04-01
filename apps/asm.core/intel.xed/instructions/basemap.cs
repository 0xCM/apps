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
        public static BaseMapKind? basemap(byte code)
            => code <= 4? (BaseMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static BaseMapKind basemap(AsmOcValue value)
        {
            var dst = default(BaseMapKind);
            if(value[0] == 0x0F)
            {
                if(value[1] == 0x38)
                    dst = BaseMapKind.BaseMap2;
                else if(value[1] == 0x3A)
                    dst = BaseMapKind.BaseMap3;
                else
                    dst = BaseMapKind.BaseMap1;
            }
            else
                dst = BaseMapKind.BaseMap0;
            return dst;
        }
    }
}