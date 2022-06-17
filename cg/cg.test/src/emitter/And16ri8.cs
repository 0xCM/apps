//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using static AsmHexEmitter;
    using static Hex8Kind;

    using Operands;

    public struct And16ri8 : IAsmEncoding<And16ri8>
    {
        /// <summary>
        /// and r16, imm8 | 83 /4 ib | r/m16 AND imm8 (sign-extended).
        /// AND | LEGACY_MAP0 | 0x83 MOD[0b11] REG[0b100] RM[nnn] SIMM8()
        /// </summary>
        public static And16ri8 and_r16_imm8(r16 r16, Imm8 imm8)
        {
            var dst = And16ri8.Empty;
            var kind = AsmFormKind.and_r16_imm8;
            var sz = AsmPrefix.opsz();
            var mrm = AsmBytes.modrm(0b11, 0b100, r16.Index);
            dst.EncodingSize = pack(x83, mrm,imm8,dst.Buffer);
            return dst;
        }

        ByteBlock8 Data;

        public AsmId Id => AsmId.AND16ri8;

        public Span<byte> Buffer
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        public ReadOnlySpan<byte> Encoded
        {
            [MethodImpl(Inline)]
            get => slice(Buffer,0,EncodingSize);
        }

        byte IAsmEncoding.EncodingSize
        {
            [MethodImpl(Inline)]
            get => EncodingSize;
        }

        public byte BufferSize
        {
            [MethodImpl(Inline)]
            get => (byte)Data.Bytes.Length;
        }

        public ref byte EncodingSize
        {
            [MethodImpl(Inline)]
            get => ref seek(Buffer, BufferSize - 1);
        }

        [MethodImpl(Inline)]
        public AsmHexCode ToAsmHex()
            => Encoded;
        public string Format()
            => ToAsmHex().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(And16ri8 src)
            => (ulong)Data == (ulong)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator AsmEncoding<AsmId,ByteBlock8>(And16ri8 src)
            => new AsmEncoding<AsmId,ByteBlock8>(src.Id, src.Data);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(And16ri8 src)
            => src.ToAsmHex();

        public static And16ri8 Empty => default;
    }
}