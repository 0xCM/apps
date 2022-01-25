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
    public readonly struct AsmCode : IComparable<AsmCode>, IEquatable<AsmCode>, ITextual, ISourceCode<AsmCode,LocatedHex>
    {
        public SourceText Source {get;}

        public CorrelationToken CT {get;}

        public LocatedHex Descriptor {get;}

        public uint Hash {get;}

        [MethodImpl(Inline)]
        public AsmCode(MemoryAddress offset, SourceText asm, AsmHexCode code, CorrelationToken ct)
        {
            Source = asm;
            CT = ct;
            Hash = asm.Hash;
            Descriptor = (offset,code);
        }

        public MemoryAddress Location => Descriptor.Location;

        public AsmHexCode HexCode => Descriptor.Hex;


        [MethodImpl(Inline)]
        public bool Equals(AsmCode src)
            => CT.Equals(src.CT);

        [MethodImpl(Inline)]
        public int CompareTo(AsmCode src)
            => CT.CompareTo(src.CT);

        public override bool Equals(object src)
            => src is AsmCode x && Equals(x);

        public override int GetHashCode()
            => (int)Hash;

        public string ToAsmString()
        {
            const string RenderPattern = "{0,-80} {1} {2}";
            var dst = text.buffer();
            var marker = (char)AsmCommentMarker.Hash;
            if(AsmParser.comment(Source.Cells, out var comment))
            {
                marker = (char)comment.Marker;
                var prior = comment.Content;
                var asm = text.trim(text.left(Source.Format(), marker));
                dst.AppendFormat(RenderPattern, asm, marker, string.Format("{0,-42} | {1}", HexCode, prior));
            }
            else
                dst.AppendFormat(RenderPattern, Source, marker, HexCode);

            return dst.Emit();
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendFormat("{0,-8}", Location.Format(4));
            dst.AppendFormat("{0,-80}", Source);
            dst.AppendFormat("# {0}", HexCode.Format());

            return dst.Emit();
        }


        public override string ToString()
            => Format();
    }
}