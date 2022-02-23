//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmEncoding : ITextual
    {
        AsmId Id {get;}

        ReadOnlySpan<byte> Encoded {get;}

        byte EncodingSize {get;}

        AsmHexCode ToAsmHex() => Encoded;
    }

    public interface IAsmEncoding<T> : IAsmEncoding
        where T : unmanaged
    {
        Span<byte> Buffer {get;}
    }

}