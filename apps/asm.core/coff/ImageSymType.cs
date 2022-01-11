//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("image")]
    public enum ImageSymType : ushort
    {
        [Symbol("null")]
        NULL  = 0,

        [Symbol("void")]
        VOID  = 1,

        [Symbol("char")]
        CHAR  = 2,

        [Symbol("short")]
        SHORT = 3,

        [Symbol("int")]
        INT   = 4,

        [Symbol("long")]
        LONG  = 5,

        [Symbol("float")]
        FLOAT = 6,

        [Symbol("double")]
        DOUBLE= 7,

        [Symbol("struct")]
        STRUCT= 8,

        [Symbol("union")]
        UNION = 9,

        [Symbol("enum")]
        ENUM  = 10,

        [Symbol("moe")]
        MOE   = 11,

        [Symbol("byte")]
        BYTE  = 12,

        [Symbol("word")]
        WORD  = 13,

        [Symbol("uint")]
        UINT  = 14,

        [Symbol("dword")]
        DWORD = 15
    }
}