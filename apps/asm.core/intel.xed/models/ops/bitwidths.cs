//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.EASZ;
    using static XedModels.EOSZ;
    using static XedModels.ModeKind;

    partial struct XedModels
    {
        [Op]
        public static uint bitwidths(ModeKind src)
            => src switch
            {
                Mode16 => 16,
                Mode32 => 32,
                Mode64 => 64,
                Not64 => 16 | 32,
                _ => 0,
            };

        [Op]
        public static uint bitwidths(EASZ src)
            => src switch
            {
                EASZ16 => 16,
                EASZ32 => 32,
                EASZ64 => 64,
                EASZNot16 => 32 | (64 << 8),
                _ => 0,
            };

        [Op]
        public static uint bitwidths(EOSZ src)
            => src switch
            {
                EOSZ8 => 8,
                EOSZ16 => 16,
                EOSZ32 => 32,
                EOSZ64 => 64,
                EOSZNot16 => 8 | (32 << 8) | (64 << 16),
                EOSZNot64 => 8 | (16 << 8) | (32 << 16),
                _ => 0,
            };
    }
}