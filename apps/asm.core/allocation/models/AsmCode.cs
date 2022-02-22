//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct AsmCode
    {
        public readonly Hex64 Id;

        public readonly SourceText Asm;

        public readonly MemoryAddress IP;

        public readonly AsmHexRef Encoded;

        [MethodImpl(Inline)]
        public AsmCode(SourceText asm, MemoryAddress ip, AsmHexRef code)
        {
            Id = AsmBytes.encid(ip, code.View);
            IP = ip;
            Asm = asm;
            Encoded = code;
        }

        [MethodImpl(Inline)]
        public AsmCode(Hex64 id, SourceText asm, MemoryAddress ip, AsmHexRef code)
        {
            Id = id;
            IP = ip;
            Asm = asm;
            Encoded = code;
        }

        public byte EncodingSize
        {
            [MethodImpl(Inline)]
            get => Encoded.Size;
        }

        public ReadOnlySpan<byte> Encoding
        {
            [MethodImpl(Inline)]
            get => Encoded.View;
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendFormat("{0,-48} # {1,-18} | {2,-12} | {3,-8} | {4,-24}", Asm, Id, IP, EncodingSize, Encoded.Format());
            return dst.Emit();
        }


        public override string ToString()
            => Format();

        public static AsmCode Empty => default;
    }
}