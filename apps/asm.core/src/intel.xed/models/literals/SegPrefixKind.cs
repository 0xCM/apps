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
        public enum SegPrefixKind : byte
        {
            [Symbol("no_seg_prefix", "SEG_OVD=0")]
            None,

            [Symbol("cs_prefix", "SEG_OVD=1")]
            Cs,

            [Symbol("ds_prefix", "SEG_OVD=2")]
            Ds,

            [Symbol("es_prefix", "SEG_OVD=3")]
            Es,

            [Symbol("fs_prefix", "SEG_OVD=4")]
            Fs,

            [Symbol("gs_prefix", "SEG_OVD=5")]
            Gs,

            [Symbol("ss_prefix", "SEG_OVD=6")]
            Ss
        }
    }
}