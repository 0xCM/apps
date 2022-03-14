//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum EnumFormatMode : byte
    {
        Default,

        Name = 1,

        Identifier = 2,

        Scalar = 4,

        EmptyZero = 8,
    }
}