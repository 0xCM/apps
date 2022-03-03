//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using static Hex8Kind;

    using Operands;

    public class AsmEmitter : AppService<AsmEmitter>
    {
        [MethodImpl(Inline)]
        public static AsmHexCode asmhex(ReadOnlySpan<byte> src)
            => src;

        /// <summary>
        /// and r16, imm8 | 83 /4 ib | r/m16 AND imm8 (sign-extended).
        /// AND | LEGACY_MAP0 | 0x83 MOD[0b11] REG[0b100] RM[nnn] SIMM8()
        /// </summary>
        public static And16ri8 and_r16_imm8(r16 r16, imm8 imm8)
        {
            var dst = And16ri8.Empty;
            var kind = AsmFormKind.and_r16_imm8;
            var sz = AsmPrefix.opsz();
            var oc = opcode(n0,kind);
            var mrm = AsmBytes.modrm(0b11, 0b100, r16.Index);
            dst.EncodingSize = pack(sz,opcode(n0,kind),mrm,imm8,dst.Buffer);
            return dst;
        }

        [MethodImpl(Inline), Op]
        static Hex8 opcode(N0 map0, AsmFormKind kind)
        {
            //AsmFormKind.and_r16_imm8;
            return x83;
        }

        /// <summary>
        /// (AND AL, imm8)[24 ib]
        /// </summary>
        /// <param name="r"></param>
        /// <param name="imm8"></param>
        [MethodImpl(Inline), Op]
        public static byte and(al r, imm8 imm8, AsmHexWriter dst)
        {
            return dst.Write(x24,imm8);
        }

        /// <summary>
        /// 20 /r | AND r/m8, r8 | 0x20 MOD[0b11] REG[rrr] RM[nnn]
        /// </summary>
        /// <param name="r0">REG0=GPR8_B():rw</param>
        /// <param name="r1">REG1=GPR8_R():r</param>
        public static byte and(r8 r0, r8 r1, AsmHexWriter dst)
        {
            var modrm = ModRm.init();
            modrm.Mod((uint2)0b11);
            modrm.Reg(r1);
            modrm.Rm(r0);
            return dst.Write(x20, modrm);
        }

        [MethodImpl(Inline), Op]
        public static byte jo(Hex8 cb, AsmHexWriter dst)
            => dst.Write(x70, cb);

        [MethodImpl(Inline), Op]
        public static byte jo(Hex32 cd, AsmHexWriter dst)
            => dst.Write(x70, x86, cd);

        [MethodImpl(Inline), Op]
        public static byte encode(Hex8 a0, imm8 a1, AsmHexWriter dst)
            => dst.Write(a0,a1);

        [MethodImpl(Inline), Op]
        public static byte encode(RexPrefix a0, Hex8 a1, imm64 a2, Span<byte> buffer)
        {
            var dst = writer(buffer);
            return dst.Write(a0,a1,a2);
        }

        [MethodImpl(Inline), Op]
        public static byte encode(Rip a0, Jcc8 a1, AsmHexWriter dst)
            => dst.Write(a1.JccCode, AsmRel8.target(a0, a1.Disp));

        [MethodImpl(Inline), Op]
        static AsmHexWriter writer(Span<byte> buffer)
            => new AsmHexWriter(buffer);

        [MethodImpl(Inline)]
        static byte pack<A>(A a, uint offset, Span<byte> dst)
            where A : unmanaged
        {
            var i0 = offset;
            var i = i0;
            @as<A>(seek(dst,offset)) = a;
            i += size<A>();
            return (byte)(i - i0);
        }

        [MethodImpl(Inline)]
        static byte pack<A,B>(A a, B b, uint offset, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
        {
            var i0 = offset;
            var i = i0;
            @as<A>(seek(dst,i)) = a;
            i += size<A>();
            @as<B>(seek(dst, i)) = b;
            i += size<B>();
            return (byte)(i - i0);
        }

        [MethodImpl(Inline)]
        static byte pack<A,B>(A a, B b, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
                => pack(a,b,0u,dst);

        [MethodImpl(Inline)]
        static byte pack<A,B,C>(A a, B b, C c, uint offset, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
        {
            var i0 = offset;
            var i = i0;
            @as<A>(seek(dst,i)) = a;
            i += size<A>();
            @as<B>(seek(dst, i)) = b;
            i += size<B>();
            @as<C>(seek(dst, i)) = c;
            i += size<C>();
            return (byte)(i - i0);
        }

        [MethodImpl(Inline)]
        static byte pack<A,B,C>(A a, B b, C c,  Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
                => pack(a,b,c,0u,dst);

        [MethodImpl(Inline)]
        static byte pack<A,B,C,D>(A a, B b, C c, D d, uint offset, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged
        {
            var i0 = offset;
            var i = i0;
            @as<A>(seek(dst,i)) = a;
            i += size<A>();
            @as<B>(seek(dst, i)) = b;
            i += size<B>();
            @as<C>(seek(dst, i)) = c;
            i += size<C>();
            @as<D>(seek(dst, i)) = d;
            i += size<D>();
            return (byte)(i - i0);
        }

        [MethodImpl(Inline)]
        static byte pack<A,B,C,D>(A a, B b, C c, D d, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged
                => pack(a,b,c,d,0u,dst);
    }

    public struct AsmEncoding<T> : IAsmEncoding<T>
        where T : unmanaged, IStorageBlock<T>
    {
        public AsmId Id {get;}

        T Data;

        [MethodImpl(Inline)]
        public AsmEncoding(AsmId id, T data)
        {
            Id = id;
            Data = data;
        }

        public byte BufferSize
        {
            [MethodImpl(Inline)]
            get => (byte)size<T>();
        }

        public Span<byte> Buffer
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        public ref byte EncodingSize
        {
            [MethodImpl(Inline)]
            get => ref seek(Buffer, BufferSize - 1);
        }

        byte IAsmEncoding.EncodingSize
        {
            [MethodImpl(Inline)]
            get => EncodingSize;
        }

        public ReadOnlySpan<byte> Encoded
        {
            [MethodImpl(Inline)]
            get => slice(Buffer,0,EncodingSize);
        }

        [MethodImpl(Inline)]
        public AsmHexCode ToAsmHex()
            => Encoded;

        public string Format()
            => ToAsmHex().Format();

        public override string ToString()
            => Format();

        public static AsmEncoding<T> Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(AsmEncoding<T> src)
            => src.ToAsmHex();
    }

    public struct And16ri8 : IAsmEncoding<And16ri8>
    {
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
        public static implicit operator AsmEncoding<ByteBlock8>(And16ri8 src)
            => new AsmEncoding<ByteBlock8>(src.Id, src.Data);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(And16ri8 src)
            => src.ToAsmHex();

        public static And16ri8 Empty => default;
    }
}