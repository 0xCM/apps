//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct BitfieldSpecs
    {
        [MethodImpl(Inline), Op]
        public static bool bitvector(in BitfieldModel src)
            => src.SegCount == src.TotalWidth;

        public static string format<K>(in BitfieldSegModel<K> src)
            where K : unmanaged
        {
            var i = Bitfields.endpos(src.Offset,src.Width);
            if(i == 0)
                return string.Format("{0}[{1}]", src.SegName, src.Offset);
            else
                return string.Format("{0}[{1}:{2}]", src.SegName, src.Offset, i);
        }

        [MethodImpl(Inline), Op]
        public static string typename(in BitfieldModel src)
            => src.IsBitvector ? "bitvector" : "bitfield";

        public static string typename(in BitfieldSegModel src)
            => src.Width == 1 ? nameof(bit) : string.Format("bits<{0}>", src.Width);

        static string decl(in BitfieldModel src)
            => string.Format("{0} : {1}<{2}> " , src.Name, typename(src), src.TotalWidth);

        public static string format(in BitfieldModel src)
        {
            var dst = text.buffer();
            dst.AppendLine(decl(src) + Chars.LBrace);
            var indent = 2u;
            for(var i=0; i<src.SegCount; i++)
            {
                if(i != src.SegCount - 1)
                    dst.IndentLineFormat(indent, "{0},", format(skip(src.Segments,i)));
                else
                    dst.IndentLineFormat(indent, "{0}", format(skip(src.Segments,i)));
            }
            indent -= 2;
            dst.IndentLine(indent,Chars.RBrace);
            return dst.Emit();
        }

        public static string format(in BitfieldSegModel src)
        {
            if(src.Width == 1)
            {
                return string.Format("{0}[{1}]:{2}",
                    src.Name,
                    src.Offset,
                    src.Width
                    );
            }
            else
                return string.Format("{0}[{1}:{2}]:{3}",
                    src.Name,
                    Bitfields.endpos(src.Offset, src.Width),
                    src.Offset,
                    src.Width
                    );
        }
    }
}