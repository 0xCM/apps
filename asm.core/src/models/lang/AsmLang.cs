//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines asm lanaguage artifacts and productions
    /// </summary>
    [ApiHost]
    public partial struct AsmLang
    {
        const NumericKind Closure = UnsignedInts;

        public static AsmLang create()
            => new AsmLang(new char[128]);

        readonly AsmSymbols S;


        readonly Index<char> Buffer;

        byte Position;

        AsmLang(Index<char> buffer)
        {
            Buffer = buffer;
            S = AsmSymbols.create();
            Position = 0;
        }

        [MethodImpl(Inline), Op]
        void Clear()
        {
            first(recover<char,CharBlock64>(Buffer)) = CharBlock64.Null;
            Position = 0;
        }

        byte Capacity
        {
            [MethodImpl(Inline)]
            get => (byte)Buffer.Length;
        }

        [MethodImpl(Inline)]
        AsmExpr Produce<A,B,C>(Sym<A> a, Sym<B> b, Sym<C> c)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
        {
            Clear();
            Render(a);
            Render(Chars.Space);
            Render(b);
            Render(Chars.Comma);
            Render(c);
            return Emit();
        }

        [MethodImpl(Inline)]
        AsmExpr Produce<A,B>(Sym<A> a, Sym<B> b, imm8 c)
            where A : unmanaged
            where B : unmanaged
                => Produce<A,B,byte>(a,b,c);

        [MethodImpl(Inline), Op]
        AsmExpr Produce<A,B>(Sym<A> a, Sym<B> b, imm16 c)
            where A : unmanaged
            where B : unmanaged
                => Produce<A,B,ushort>(a,b,c);

        [MethodImpl(Inline), Op]
        AsmExpr Produce<A,B>(Sym<A> a, Sym<B> b, imm32 c)
            where A : unmanaged
            where B : unmanaged
                => Produce<A,B,uint>(a,b,c);

        [MethodImpl(Inline), Op]
        AsmExpr Produce<A,B>(Sym<A> a, Sym<B> b, imm64 c)
            where A : unmanaged
            where B : unmanaged
                => Produce<A,B,ulong>(a,b,c);

        [MethodImpl(Inline), Op]
        AsmExpr Produce<A,B,T>(Sym<A> a, Sym<B> b, ImmOp<T> c)
            where A : unmanaged
            where B : unmanaged
            where T : unmanaged
        {
            Clear();
            Render(a);
            Render(Chars.Space);
            Render(b);
            Render(Chars.Comma);
            Render(c);
            return Emit();
        }

        [Op]
        AsmExpr Emit()
            => slice(Buffer.Edit, 0, Position);

        [Op]
        void Render<T>(ImmOp<T> src)
            where T : unmanaged
                => Render("0" + src.Format());

        [MethodImpl(Inline), Op]
        void Render(char src)
            => Buffer[Position++] = src;

        [MethodImpl(Inline), Op]
        void Render(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Buffer[Position++] = skip(src,i);
        }

        [MethodImpl(Inline), Op]
        void Render<K>(Sym<K> src)
            where K : unmanaged
        {
            var data = src.Expr.Data;
            var len = data.Length;
            for(var i=0; i<len; i++)
                Buffer[Position++] = skip(data,i);
        }

        // 3 bits
        internal enum ScaleFactor : byte
        {
            S0 = 1,

            S1 = 2,

            S3 = 3,

            S4 = 4
        }

        // 3 bits
        internal enum OpIndex : byte
        {
            S0 = 1,

            S1 = 2,

            S3 = 3,

            S4 = 4
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        internal readonly struct OpInfo
        {

        }

        [MethodImpl(Inline), Op]
        internal static OpInfo join(OpIndex index, ScaleFactor scale)
            => to(emath.or(index, emath.srl8(scale, 3)), out OpInfo _);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static ref Cell<T> cell<T>(ref Statement src, byte offset)
            where T : unmanaged
                => ref first(recover<Cell<T>>(slice(src.Bytes,offset)));

        [MethodImpl(Inline), Op]
        internal static ref AsmMnemonicCode mnemonic(ref Statement src)
            => ref mnemonic(src.Bytes);

        [MethodImpl(Inline), Op]
        internal static ref AsmMnemonicCode mnemonic(Span<byte> src)
            => ref first(recover<AsmMnemonicCode>(src));

        public struct Statement
        {
            internal Cell256 Data;

            internal Span<byte> Bytes
            {
                [MethodImpl(Inline)]
                get => Data.Bytes;
            }

            public ref AsmMnemonicCode Mnemonic
            {
                [MethodImpl(Inline)]
                get => ref mnemonic(Bytes);
            }
        }
    }
}