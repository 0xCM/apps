//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmEncodingRecord : ISequential
    {
        Hex64 Id {get;}

        MemoryAddress IP {get;}

        AsmHexCode Encoded {get;}

        AsmExpr Asm {get;}

        byte Size
            => Encoded.Size;
    }
}