//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-state-bits.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed_state)]
        public enum RexKind : byte
        {
            [Symbol("no_rex","REX=0")]
            None=0,

            [Symbol("rex_reqd","REX=1")]
            Required,

            [Symbol("rexw_prefix","REXW=1")]
            RexW,

            [Symbol("norexw_prefix","REXW=0")]
            NoRexW,

            [Symbol("W0","REXW=0")]
            W0,

            [Symbol("W1","REXW=1")]
            W1,

            [Symbol("rexr_prefix","REXR=1")]
            RexR,

            [Symbol("norexr_prefix","REXR=0")]
            NoRexR,

            [Symbol("rexx_prefix","REXX=1")]
            RexX,

            [Symbol("norexx_prefix","REXX=0")]
            NoRexX,

            [Symbol("rexb_prefix","REXB=1")]
            RexB,

            [Symbol("norexb_prefix","REXB=0")]
            NoRexB,
        }
    }
}