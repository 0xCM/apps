//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-state-bits.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(state)]
        public enum SegDefaultKind : byte
        {
            [Symbol("default_ds", "DEFAULT_SEG=0")]
            DefaultDS = 0,

            [Symbol("default_ss", "DEFAULT_SEG=1")]
            DefaultSS = 1,

            [Symbol("default_es","DEFAULT_SEG=2")]
            DefaultES = 2
        }
    }
}