//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("image")]
    public enum ImageSymType : ushort
    {
        None = 0,

        Void = 1,

        Char = 2,

        Short = 3,

        Int = 4,

        Long = 5,

        Float = 6,

        Double = 7,

        Struct = 8,

        Union = 9,

        Enum = 10,

        MOE = 11,

        Byte = 12,

        Word = 13,

        UInt = 14,

        DWord = 15
    }
}