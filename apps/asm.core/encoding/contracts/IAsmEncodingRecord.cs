//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmEncodingRecord : ISequential, IOriginated
    {
        EncodingId EncodingId {get;}

        MemoryAddress IP {get;}

        AsmHexCode Encoded {get;}

        AsmExpr Asm {get;}

        byte Size
            => Encoded.Size;
    }
}