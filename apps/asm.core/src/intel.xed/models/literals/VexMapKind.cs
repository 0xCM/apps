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
        public enum VexMapKind : byte
        {
            /// <summary>
            /// MAP=0
            /// </summary>
            [Symbol("VMAP0", "MAP=0")]
            VMAP0 = 0,

            /// <summary>
            /// MAP=1
            /// </summary>
            [Symbol("V0F", "MAP=1")]
            V0F = 1,

            /// <summary>
            /// MAP=2
            /// </summary>
            [Symbol("V0F38", "MAP=2")]
            V0F38 = 2,

            /// <summary>
            /// MAP=3
            /// </summary>
            [Symbol("V0F3A", "MAP=3")]
            V0F3A = 3
        }
    }
}