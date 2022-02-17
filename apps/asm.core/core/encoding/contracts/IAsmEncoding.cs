//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmEncoding : ISequential
    {
        MemoryAddress IP {get;}

        AsmHexCode Encoded {get;}

        AsmExpr Asm {get;}

        byte Size
            => Encoded.Size;

        Hex64 Id  => AsmBytes.identify(IP, Encoded.Bytes);
    }
}