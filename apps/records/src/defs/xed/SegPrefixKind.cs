//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-state-bits.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedRecords
    {
        [SymSource(xed_state)]
        public enum SegPrefixKind : byte
        {
            [Symbol("no_seg_prefix", "SEG_OVD=0")]
            None = 0,

            [Symbol("cs_prefix", "SEG_OVD=1")]
            CS = 1,

            [Symbol("ds_prefix", "SEG_OVD=2")]
            DS = 2,

            [Symbol("es_prefix", "SEG_OVD=3")]
            ES = 3,

            [Symbol("fs_prefix", "SEG_OVD=4")]
            FS = 4,

            [Symbol("gs_prefix", "SEG_OVD=5")]
            GS = 5,

            [Symbol("ss_prefix", "SEG_OVD=6")]
            SS = 6
        }
    }
}