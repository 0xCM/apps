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

    [StructLayout(LayoutKind.Sequential, Size=16, Pack =1), ApiHost]
    public readonly struct AsmText : IAsmText<AsmText>
    {
        [MethodImpl(Inline), Op]
        public static AsmText asmtext(StringAddress src, AsmPartKind kind = default)
            => new AsmText(src, kind);

        [MethodImpl(Inline), Op]
        public static AsmText asmtext(string src, AsmPartKind kind = default)
            => asmtext(strings.address(src), kind);

        public static string format(AsmText src)
        {
            Span<char> dst = stackalloc char[(int)src.Source.Length];
            var i=0u;
            var count = src.Render(ref i, dst);
            return text.format(slice(dst,0,count));
        }

        public static string format(in AsmSourceLine src)
        {
            if(src.Label.IsNonEmpty)
                return src.Label.Format();
            else if(src.Statement.IsNonEmpty)
            {
                if(src.Comment.IsNonEmpty)
                    return string.Format("{0,-46} {1}", src.Statement, src.Comment);
                else
                    return src.Statement.Format();
            }
            else if(src.Comment.IsNonEmpty)
            {
                return src.Comment.Format();
            }
            else
                return EmptyString;
        }

        [MethodImpl(Inline), Op]
        public static AsmText opcode(string src)
            => asmtext(src, AsmPartKind.OpCode);

        [MethodImpl(Inline), Op]
        public static AsmText sig(string src)
            => asmtext(src, AsmPartKind.Sig);

        // [MethodImpl(Inline), Op]
        // public static AsmText rule(string src)
        //     => asmtext(src, AsmPartKind.EncodingRule);

        [MethodImpl(Inline), Op]
        public static AsmText statement(string src)
            => asmtext(src, AsmPartKind.Statement);

        [MethodImpl(Inline), Op]
        public static AsmText hex(string src)
            => asmtext(src, AsmPartKind.HexCode);

        public StringAddress Source {get;}

        public AsmPartKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmText(StringAddress src, AsmPartKind kind = default)
        {
            Source = src;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public uint Render(ref uint i, Span<char> dst)
            => Source.Render(ref i, dst);

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmText(ReadOnlySpan<char> src)
            => new AsmText(strings.address(src));

        [MethodImpl(Inline)]
        public static implicit operator AsmText(ReadOnlySpan<byte> src)
            => new AsmText(strings.address(src));
    }
}