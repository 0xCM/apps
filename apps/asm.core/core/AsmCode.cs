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

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AsmCode : IComparable<AsmCode>, IEquatable<AsmCode>, ITextual
    {
        [MethodImpl(Inline), Op]
        public static AsmCode define(MemoryAddress offset, SourceText src, AsmHexCode hex)
            => new AsmCode(offset, src, hex);

        public MemoryAddress Offset {get;}

        public SourceText Asm {get;}

        public AsmHexCode Code {get;}

        [MethodImpl(Inline)]
        public AsmCode(MemoryAddress offset, SourceText asm, AsmHexCode code)
        {
            Offset = offset;
            Asm = asm;
            Code = code;
        }

        [MethodImpl(Inline)]
        public bool Equals(AsmCode src)
            => Code.Equals(src);

        public int CompareTo(AsmCode src)
            => Asm.CompareTo(src.Asm);

        public override bool Equals(object src)
            => src is AsmCode x && Equals(x);

        public string ToAsmString()
        {
            const string RenderPattern = "{0,-80} {1} {2}";
            var dst = text.buffer();
            var marker = (char)AsmCommentMarker.Hash;
            if(AsmParser.comment(Asm.Cells, out var comment))
            {
                marker = (char)comment.Marker;
                var prior = comment.Content;
                var asm = text.trim(text.left(Asm.Format(), marker));
                dst.AppendFormat(RenderPattern, asm, marker, string.Format("{0,-42} | {1}", Code, prior));
            }
            else
                dst.AppendFormat(RenderPattern, Asm, marker, Code);

            return dst.Emit();
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendFormat("{0,-8}", Offset);
            dst.AppendFormat("{0,-80}", Asm);
            dst.AppendFormat("# {0}", Code.Format());

            return dst.Emit();
        }


        public override int GetHashCode()
            => Code.GetHashCode();

        public override string ToString()
            => Format();
    }
}