//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RegFieldFacets;

    [ApiHost]
    public readonly partial struct AsmRegs
    {
        [Op]
        public static string format<T>(AsmRegValue<T> src)
            where T : unmanaged
                => string.Format("{0,-5}{1}", src.Name, HexFormatter.bytes(src.Value));

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