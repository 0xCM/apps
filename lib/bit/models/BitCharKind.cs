//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using CC = AsciCode;

    [SymSource]
    public enum BitCharKind : byte
    {
        [Symbol("0")]
        Off = CC.d0,

        [Symbol("1")]
        On = CC.d1,

        [Symbol("|")]
        SectionSep = CC.Pipe,

        [Symbol(" ")]
        SegSep = CC.Space,

        [Symbol("[")]
        LeftFence = CC.LBracket,

        [Symbol("]")]
        RightFence = CC.RBracket,

        [Symbol(" ")]
        Space = CC.Space,
    }

    public enum BitCharIndex : byte
    {
        Off = 0,

        On = 1,

        SectionSep = 2,

        SegSep = 3,

        LeftFence = 4,

        RightFence = 5,

        Space = 6,
    }
}