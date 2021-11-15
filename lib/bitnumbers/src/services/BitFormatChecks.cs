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
    using static BitNumbers;

    [ApiHost]
    public class BitFormatChecks
    {
        BitNumberFormatter Formatter;

        ITextBuffer Log;

        Index<byte> _Data;

        Index<char> _Buffer;

        ReadOnlySpan<byte> Source
        {
            [MethodImpl(Inline)]
            get => _Data.View;
        }

        [MethodImpl(Inline)]
        string FormatBuffer(uint offset, uint length)
            => text.format(slice(_Buffer.View, offset, length));

        Span<char> RentBuffer()
            => _Buffer.Clear();

        public static BitFormatChecks create()
            => new BitFormatChecks();

        public BitFormatChecks()
        {
            Formatter = new();
            _Buffer = alloc<char>(Pow2.T08);
            Log = text.buffer();
        }

        void CheckNibbleSpan()
        {
            var m0 =  Cells.cell64(BitMaskLiterals.Even64);
            var m1 = Cells.cell64(BitMaskLiterals.Lsb63x3x1);
            var storage = Cells.join(m0,m1);
            var bytes = storage.Bytes;
            var bits = BitRender.render8x8(bytes);
            Log.AppendLine(text.format(bits));

            var nibbles = NibbleSpan.from(bytes);
            var count = nibbles.Count;
            Log.AppendLine(string.Format("{0}:{1}", "Count", count));
            if(count != 32)
                return;

            Log.AppendLine(nibbles.Format());
        }

        void CheckJoin()
        {
            var c0 = Cells.cell64(BitMaskLiterals.Odd64);
            var c1 = Cells.cell64(BitMaskLiterals.Central64x16x8);
            var c2 = Cells.cell64(BitMaskLiterals.Lsb63x3x1);
            var c3 = Cells.cell64(BitMaskLiterals.Odd64);
            var c256 = Cells.join(c0,c1,c2,c3);
            Log.AppendLine(c256);
            var bytes = c256.Bytes;
            var nibbles = NibbleSpan.from(bytes);
            Log.AppendLine(nibbles.Format());
        }

        public ITextBuffer Run(IPolySource src)
        {
            _Data = src.Bytes(256).Array();
            CheckNibbleSpan();
            Check(w3);
            CheckJoin();
            return Log;
        }

        public void Show(HexVector8<N4> src)
        {
            Log.AppendLine(src.Format());

            var offset = 0u;
            var buffer = RentBuffer();
            offset += src.Bitstring(offset, buffer);

            seek(buffer, offset++) = Chars.Space;
            seek(buffer, offset++) = Chars.Eq;
            seek(buffer, offset++) = Chars.Space;

            offset += HexVector.bitstring(src, offset, buffer);

            Log.AppendLine(FormatBuffer(0, offset));
        }

        public Index<FormatCheck<W3,uint3>> Check(W3 w)
        {
            var buffer = alloc<FormatCheck<W3,uint3>>(_Data.Length);
            Check(w, buffer);
            return buffer;
        }

        [Op]
        void Check(W3 w, Index<FormatCheck<W3,uint3>> dst)
        {
            var target = dst.Edit;
            var count = _Data.Length;
            for(var i=0u; i<count; i++)
            {
                var a = skip(Source,i);
                var b = BitNumbers.uint3(a);
                seek(target,i) = result(w, i, b, Formatter.Format(b));
            }
        }

        [MethodImpl(Inline)]
        public static FormatCheck<W,T> result<W,T>(W w, uint seq, T input, string formatted)
            where T : unmanaged, IBitNumber
            where W : unmanaged, IDataWidth
        {
            var dst = new FormatCheck<W,T>();
            dst.Seq = seq;
            dst.Value = input;
            dst.Formatted = formatted;
            dst.LengthExpect = (uint)Widths.data(w);
            dst.LengthActual = (uint)formatted.Length;
            dst.LenthMatch = dst.LengthExpect == dst.LengthActual;
            return dst;
        }
    }
}