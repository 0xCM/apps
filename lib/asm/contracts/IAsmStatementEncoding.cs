//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmStatementEncoding : ISequential
    {
        AsmExpr Asm {get;}

        AsmHexCode Encoding {get;}

        MemoryAddress Offset {get;}
    }
}