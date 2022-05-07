//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    public readonly struct BitConverters
    {
        // 65472 0xFFC0 0b1111111111000000
        const string RenderPattern = "{0:D5} 0x{0:X4} 0b{1}";

        public static N16 MaxWidth => default;

        static Index<asci32> rows<N>(N n = default)
            where N : unmanaged, ITypeNat
        {
            var width = (byte)n.NatValue;
            var count = num.count(n);
            var src = num.bitstrings(n);
            var dst = alloc<asci32>(count);

            for(var i=0; i<count; i++)
            {
                var offset = i*width;
                var seq = slice(src, offset, width);
                seek(dst,i) = string.Format(RenderPattern, i, text.format(seq));
            }

            return dst;
        }

        public static BitConverter<N> converter<N>(N n =default)
            where N : unmanaged, ITypeNat
        {
            Demand.lteq((byte)n.NatValue, (byte)MaxWidth);
            return new (rows(n));
        }
    }

    public readonly struct BitConverter<N>
        where N : unmanaged, ITypeNat
    {
        // 65472 0xFFC0 0b1111111111000000
        const string RenderPattern = "{0:D5} 0x{0:X4} 0b{1}";

        const byte SepLength = 1;

        const byte DecOffset = 0;

        const byte DecLength = 5;

        const byte HexSegOffset = DecOffset + DecLength + SepLength;

        const byte HexSpecLength = 2;

        const byte HexValLength = 4;

        const byte HexSegLength = HexSpecLength + HexValLength;

        const byte HexValOffset = HexSegOffset + HexSpecLength;

        const byte BinSegOffset =  HexSegOffset + HexSegLength + SepLength;

        const byte BinSpecLength = 2;

        const byte BinValOffset = BinSegOffset + BinSpecLength;

        const byte BinValLength = 16;

        readonly Index<asci32> Data;

        [MethodImpl(Inline)]
        internal BitConverter(Index<asci32> data)
        {
            Data = data;
        }

        public ushort EntryCount
        {
            [MethodImpl(Inline)]
            get => (ushort)Data.Count;
        }

        [MethodImpl(Inline)]
        ref readonly asci32 Entry(ushort value)
            => ref Data[value];

        [MethodImpl(Inline)]
        public ref readonly asci4 Chars(Base16 @base, ushort value)
        {
            ref readonly var entry = ref Data[value];
            ref readonly var seg = ref @as<asci4>(slice(entry.View, HexValOffset, HexValLength));
            return ref seg;
        }

        [MethodImpl(Inline)]
        public ref readonly asci16 Chars(Base2 @base, ushort value)
        {
            ref readonly var entry = ref Entry(value);
            ref readonly var seg = ref @as<asci16>(slice(entry.View, BinValOffset, BinValLength));
            return ref seg;
        }
    }

    partial class XedCmdProvider
    {
        [CmdOp("native/checks")]
        unsafe Outcome TestNativeCells(CmdArgs args)
        {
            var n = n16;
            var count = num.count(n);
            byte length = (byte)n;
            var result = Outcome.Success;
            using var native = NativeCells.alloc<string>(count, out var id);
            var bits = num.bitstrings(n);
            for(var i=0u; i<count; i++)
            {
                var offset = i*n;
                native.Content(i) = new string(slice(bits, offset, n));
            }


            var convert = BitConverters.converter(n);
            for(var i=0; i<count; i++)
            {
                ref readonly var hex = ref convert.Chars(base16,(ushort)i);
                ref readonly var bin = ref convert.Chars(base2,(ushort)i);
                Write(string.Format("{0} {1}", hex, bin));
            }

            // for(var i=0u; i<count; i++)
            //     Write(native.Content(i));

            //"02037 0x07F5 0b11111110101     "
            //GenBitLookup(n);

            return result;
        }

        Index<asci32> GenBitLookup<N>(N n)
            where N : unmanaged, ITypeNat
        {
            var width = (byte)n.NatValue;
            var count = num.count(n);
            var buffer = num.bitstrings(n);
            var rows = alloc<asci32>(count);

            for(var i=0; i<count; i++)
            {
                var offset = i*width;
                var seq = slice(buffer, offset, width);
                var row = string.Format("{0:D5} 0x{0:X4} 0b{1}", i, text.format(seq));
                seek(rows,i) = row;
                Write(skip(rows,i));
            }

            return rows;
        }
    }
}