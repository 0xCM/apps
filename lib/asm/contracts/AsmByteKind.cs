//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum AsmByteKind : byte
    {
        None = 0,

        ModRm,

        Sib,

        OpCode,

        Prefix,
    }
}