//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmEncoding : ISequential, ICorrelated
    {
        AsmExpr Asm {get;}

        AsmHexCode Code {get;}

        MemoryAddress IP {get;}

        byte Size
            => Code.Size;
    }
}