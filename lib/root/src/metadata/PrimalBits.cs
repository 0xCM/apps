//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static minicore;

    using W = PrimalBits.SegWidth;
    using M = PrimalBits.SegMask;
    using P = PrimalBits.SegPos;
    using I = PrimalBits.Field;

    [ApiHost]
    public readonly struct PrimalBits
    {
        [MethodImpl(Inline), Op]
        public static PrimalKind filter(byte src, SegMask mask)
            => (PrimalKind)(src & (byte)mask);

        /// <summary>
        /// Isolates an identified bitfield segment
        /// </summary>
        /// <param name="src">The source bitfield</param>
        /// <param name="i">The segment identifier</param>
        [MethodImpl(Inline), Op]
        public static PrimalKind filter(PrimalKind src, Field i)
            => filter((byte)src, filter(i));

        /// <summary>
        /// Gets the value of an identified bitfield segment
        /// </summary>
        /// <param name="src">The source bitfield</param>
        /// <param name="i">The segment identifier</param>
        [MethodImpl(Inline), Op]
        public static byte select(PrimalKind src, Field i)
            => (byte)view(filter(src,i), index(i));

        /// <summary>
        /// Returns the type-code identified primal kind
        /// </summary>
        /// <param name="src">The type code</param>
        [MethodImpl(Inline), Op]
        public static PrimalKind kind(TypeCode src)
            => skip(Kinds, (uint)src);

        [MethodImpl(Inline), Op]
        public static PrimalCode code(PrimalKind f)
            => (PrimalCode)select(f, Field.KindId);

        [Op]
        public static PrimalKind kind(Type src)
            => kind(sys.typecode(src));

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static PrimalKind kind<T>()
            => kind(sys.typecode<T>());

        public static ReadOnlySpan<PrimalKind> Kinds
        {
            [MethodImpl(Inline), Op]
            get => recover<PrimalKind>(PrimalKindData);
        }

        [MethodImpl(Inline), Op]
        static ref readonly SegMask filter(Field i)
            => ref skip(Masks, (byte)i);

        [MethodImpl(Inline), Op]
        static ref readonly SegPos index(Field i)
            => ref skip(Positions, (byte)i);

        [MethodImpl(Inline), Op]
        static PrimalKind view(PrimalKind src, SegPos offset)
            => (PrimalKind)((byte)src >> (byte)offset);

        static ReadOnlySpan<byte> PrimalKindData => new byte[19]{
            (byte)PrimalKind.None, //0:Empty/null
            (byte)PrimalKind.Object, //1:Object
            (byte)PrimalKind.DBNull, //2:DbNull
            (byte)PrimalKind.U1, //3:Bool
            (byte)PrimalKind.C16, //4:char
            (byte)PrimalKind.I8, //5:int8
            (byte)PrimalKind.U8, //6:uint8
            (byte)PrimalKind.I16, //7:short
            (byte)PrimalKind.U16, //8:ushort
            (byte)PrimalKind.I32, //9:int32
            (byte)PrimalKind.U32, //10:uint32
            (byte)PrimalKind.I64, //11:int64
            (byte)PrimalKind.U64, //12:uint64
            (byte)PrimalKind.F32, //13:float32
            (byte)PrimalKind.F64, //14:float64
            (byte)PrimalKind.F128, //15:decimal
            (byte)PrimalKind.DateTime, //16:datetime
            (byte)PrimalKind.None, // 17:empty
            (byte)PrimalKind.String //18:string
        };

        /// <summary>
        /// Defines positional identifiers for each bitfield segment
        /// </summary>
        public enum Field : byte
        {
            /// <summary>
            /// Identifies the bitfield segment that specifies a primitive width
            /// </summary>
            Width = 0,

            /// <summary>
            /// Identifies the bitfield segment that specifies a primitive kind identifier
            /// </summary>
            KindId = 1,

            /// <summary>
            /// Identifies the bitfield segment that specifies a primitive sign classifier
            /// </summary>
            Sign = 2,
        }

        public enum SegMask : byte
        {
            /// <summary>
            /// The Size field mask
            /// </summary>
            Size = 0b0_0000_111,

            /// <summary>
            /// The KindId field mask
            /// </summary>
            KindId = 0b0_1111_000,

            /// <summary>
            /// The Sign field mask
            /// </summary>
            Sign = 0b1_0000_000,
        }

        /// <summary>
        /// Defines integers that correspond to the position of the first bit of each bitfield segment
        /// that implies the following segmentation: [s kkkk www] where s denotes the sign bit, k denotes
        /// a kind identity bit and w denotes a width bit expressed in log2-form
        /// </summary>
        public enum SegPos : byte
        {
            /// <summary>
            /// The starting index of the width field
            /// </summary>
            Width = 0,

            /// <summary>
            /// The starting index of the id field
            /// </summary>
            KindId = 3,

            /// <summary>
            /// The index of the sign flag
            /// </summary>
            Sign= 7,
        }

        /// <summary>
        /// Defines the widths of the primal kind bitfield segments
        /// </summary>
        public enum SegWidth : byte
        {
            /// <summary>
            /// The bit-width of the Size segment
            /// </summary>
            Width = 3,

            /// <summary>
            /// The bit-width of the KindId segment
            /// </summary>
            KindId = 4,

            /// <summary>
            /// The bit-width of the Sign segment
            /// </summary>
            Sign = 1,
        }

        /// <summary>
        /// The bitfield segment count
        /// </summary>
        public const byte SegCount = 3;

        /// <summary>
        /// The total bitfield width
        /// </summary>
        public const byte TotalWidth = (byte)W.KindId + (byte)W.Width + (byte)W.Sign;

        /// <summary>
        /// The defined fields
        /// </summary>
        public static ReadOnlySpan<I> Fields
            => new I[SegCount]{I.Width, I.KindId, I.Sign};

        /// <summary>
        /// Segment mask filters
        /// </summary>
        public static ReadOnlySpan<M> Masks
            => new M[SegCount]{M.Size, M.KindId, M.Sign};

        /// <summary>
        /// The segment starting positions
        /// </summary>
        public static ReadOnlySpan<P> Positions
            => new P[SegCount]{P.Width, P.KindId, P.Sign};

        /// <summary>
        /// Segment widths
        /// </summary>
        public static ReadOnlySpan<W> Widths
            => new W[SegCount]{W.Width, W.KindId, W.Sign};
    }
}