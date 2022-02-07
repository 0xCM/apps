//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RegFacets;
    using static core;

    [ApiHost]
    public readonly partial struct AsmRegs
    {
        const NumericKind Closure = UnsignedInts;

        public enum RegFieldIndex : byte
        {
            /// <summary>
            /// RegisterCode: [0..5]
            /// </summary>
            C = IndexField,

            /// <summary>
            /// RegisterClass:[6..9]
            /// </summary>
            K = ClassField,

            /// <summary>
            /// Register width: [10..13]
            /// </summary>
            W = WidthField,

            /// <summary>
            /// Upper register selection: [15]
            /// </summary>
            H = 15,
        }

        public enum RegFieldWidth : byte
        {
            RegCode = 5,

            RegClass = 4,

            RegWidth = 3,
        }
    }
}