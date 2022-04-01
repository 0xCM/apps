//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public static uint modes(EOSZ src)
            => src switch
            {
                EOSZ.EOSZ8 => 0,
                EOSZ.EOSZ16 => 1,
                EOSZ.EOSZ32 => 2,
                EOSZ.EOSZ64 => 3,
                EOSZ.EOSZNot16 => 0 | (2 << 8) | (3 << 16),
                EOSZ.EOSZNot64 => 0 | (1 << 8) | (2 << 16),
                _ => 0,
            };
    }
}