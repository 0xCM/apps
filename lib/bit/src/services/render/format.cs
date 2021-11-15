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

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static string format2(byte src)
        {
            var i=0u;
            var buffer = CharBlock2.Null;
            var dst = buffer.Data;
            render2(src, ref i, dst);
            return text.format(dst);
        }

        [Op]
        public static string format3(byte src)
        {
            var buffer = CharBlock3.Null.Data;
            var i=0u;
            var count = render3(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format4(byte src)
        {
            var buffer = CharBlock4.Null.Data;
            var i=0u;
            var count = render4(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format8x4(byte src)
            => text.format(render8x4(src));

        [Op]
        public static string format5(byte src)
        {
            var buffer = CharBlock5.Null.Data;
            var i=0u;
            var count = render5(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format6(byte src)
        {
            var buffer = CharBlock6.Null.Data;
            var i=0u;
            var count = render6(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format7(byte src)
        {
            var buffer = CharBlock7.Null.Data;
            var i=0u;
            var count = render7(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format8(byte src)
            => text.format(render8(src));

        [Op]
        public static string format16x8(ushort src, char sep = Chars.Space)
            => text.format(render16x8(src, sep));

        [Op]
        public static string format16(ushort src)
            => text.format(render16(src));

        [Op]
        public static string format32x8(uint src, char sep = Chars.Space)
            => new string(render32x8(src, sep));

        [Op]
        public static string format64x8(ulong src)
            => text.format(render64x8(src));

        public static string format(ReadOnlySpan<byte> src, in BitFormat config)
        {
            var count = src.Length*8;
            var dst = span<char>(count);
            dst.Fill(Chars.D0);
            Require.invariant(config.MaxBitCount > 0);

            render8x8(src, config.MaxBitCount, dst);

            dst.Reverse();

            var bs = new string(dst);

            if(config.TrimLeadingZeros)
                bs = bs.TrimStart(Chars.D0);

            if(config.ZPad != 0)
                bs = bs.PadLeft(config.ZPad, Chars.D0);

            if(config.BlockWidth != 0)
                bs = string.Join(config.BlockSep, bs.Partition(config.BlockWidth));

            return config.SpecifierPrefix ? "0b" + bs : bs;
        }

        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<bit> src, BitFormat options)
        {
            var bitcount = min((uint)options.MaxBitCount,(uint)src.Length);
            var blocked = options.BlockWidth != 0;
            var blocks = (uint)(blocked ? src.Length/options.BlockWidth : 0);
            bitcount += blocks; // space for block separators
            return bitcount;
        }

        public static string format(ReadOnlySpan<bit> src, BitFormat? fmt = null)
        {
            var options = fmt ?? BitFormat.configure();
            var blocked = options.BlockWidth != 0;
            var blocks = (uint)(blocked ? src.Length/options.BlockWidth : 0);
            var bitcount = length(src,options);

            Span<char> buffer = stackalloc char[(int)bitcount];
            ref var dst = ref first(buffer);
            var digits = 0;
            for(uint i = 0, j=bitcount-1; i<bitcount; i++, j--)
            {
                if(blocked && (digits % options.BlockWidth) == 0)
                    seek(dst, j--) = options.BlockSep;

                seek(dst, j) = skip(src,i).ToChar();
                digits++;
            }

            if(options.TrimLeadingZeros)
                return new string(buffer).TrimStart(bit.Zero);
            else
                return new string(buffer);
        }

        [Op]
        public static string format(object src, TypeCode type)
        {
            if(type == TypeCode.Byte || type == TypeCode.SByte)
                return format8(src);
            else if(type == TypeCode.UInt16 || type == TypeCode.Int16)
                return format16(src);
            else if(type == TypeCode.UInt32  || type == TypeCode.Int32 || type == TypeCode.Single)
                return format32(src);
            else if(type == TypeCode.UInt64 || type == TypeCode.Int64 || type == TypeCode.Double)
                return format64(src);
            else
                return EmptyString;
        }

        [Op]
        static string format8(object src)
            => BitRender.formatter<byte>().Format((byte)NumericBox.rebox(src, NumericKind.U8));

        [Op]
        static string format16(object src)
            => BitRender.formatter<ushort>().Format((ushort)NumericBox.rebox(src, NumericKind.U16));

        [Op]
        static string format32(object src)
            => BitRender.formatter<uint>().Format((uint)NumericBox.rebox(src, NumericKind.U32));

        [Op]
        static string format64(object src)
            => BitRender.formatter<ulong>().Format((ulong)NumericBox.rebox(src, NumericKind.U64));
    }
}