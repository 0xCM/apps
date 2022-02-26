//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.EASZ;
    using static XedModels.EOSZ;

    partial struct XedModels
    {
        public static uint width(EOSZ src)
            => src switch
            {
                EOSZ8 => 8,
                EOSZ16 => 16,
                EOSZ32 => 32,
                EOSZ64 => 64,
                _ => 0,
            };

        public static uint widths(EOSZ src)
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


        public static uint width(EASZ src)
            => src switch
            {
                EASZ16 => 16,
                EASZ32 => 32,
                EASZ64 => 64,
                _ => 0,
            };

        public static uint widths(EASZ src)
            => src switch
            {
                EASZ16 => 16,
                EASZ32 => 32,
                EASZ64 => 64,
                EASZNot16 => 32 | (64 << 8),
                _ => 0,
            };
    }
}