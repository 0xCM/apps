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

    using W = PrimalBits.SegWidth;
    using M = PrimalBits.SegMask;
    using P = PrimalBits.SegPos;
    using I = PrimalBits.Field;

    [ApiHost]
    public readonly struct PrimalBits
    {
        /// <summary>
        /// Computes the bit-width of the represented primitive
        /// </summary>
        /// <param name="f">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static NativeTypeWidth width(ClrPrimitiveKind f)
            => (NativeTypeWidth)Pow2.pow(select(f, Field.Width));

        /// <summary>
        /// Determines the numeric sign, if any, of the represented primitive
        /// </summary>
        /// <param name="f">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static PolarityKind sign(ClrPrimitiveKind f)
            => (PolarityKind)select(f, Field.Sign);

        [MethodImpl(Inline), Op]
        public static TypeCode typecode(ClrPrimitiveKind f)
            => (TypeCode)select(f, Field.KindId);

        /// <summary>
        /// Computes the bit-width of the represented primitive
        /// </summary>
        /// <param name="f">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static NativeTypeWidth width(ClrEnumKind kind)
            => width((ClrPrimitiveKind)kind);

        /// <summary>
        /// Computes the bit-width of the represented primitive
        /// </summary>
        /// <param name="f">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static PolarityKind sign(ClrEnumKind kind)
            => sign((ClrPrimitiveKind)kind);

        [MethodImpl(Inline), Op]
        public static TypeCode typecode(ClrEnumKind kind)
            => typecode(kind);

        [MethodImpl(Inline), Op]
        public static ClrPrimitiveInfo describe(ClrPrimitiveKind src)
            => new ClrPrimitiveInfo(src, width(src), sign(src), (PrimalCode)typecode(src));

        [MethodImpl(Inline), Op]
        public static ClrPrimitiveInfo describe(ClrEnumKind src)
            => new ClrPrimitiveInfo((ClrPrimitiveKind)src, width(src), sign(src), (PrimalCode)typecode(src));

        [MethodImpl(Inline), Op]
        public static ClrPrimitiveKind filter(byte src, SegMask mask)
            => (ClrPrimitiveKind)(src & (byte)mask);

        /// <summary>
        /// Isolates an identified bitfield segment
        /// </summary>
        /// <param name="src">The source bitfield</param>
        /// <param name="i">The segment identifier</param>
        [MethodImpl(Inline), Op]
        public static ClrPrimitiveKind filter(ClrPrimitiveKind src, Field i)
            => filter((byte)src, filter(i));

        /// <summary>
        /// Gets the value of an identified bitfield segment
        /// </summary>
        /// <param name="src">The source bitfield</param>
        /// <param name="i">The segment identifier</param>
        [MethodImpl(Inline), Op]
        public static byte select(ClrPrimitiveKind src, Field i)
            => (byte)view(filter(src,i), index(i));

        /// <summary>
        /// Returns the type-code identified primal kind
        /// </summary>
        /// <param name="src">The type code</param>
        [MethodImpl(Inline), Op]
        public static ClrPrimitiveKind kind(TypeCode src)
            => skip(Kinds, (uint)src);

        [MethodImpl(Inline), Op]
        public static PrimalCode code(ClrPrimitiveKind f)
            => (PrimalCode)select(f, Field.KindId);

        [Op]
        public static ClrPrimitiveKind kind(Type src)
            => kind(sys.typecode(src));

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ClrPrimitiveKind kind<T>()
            => kind(sys.typecode<T>());

        public static ReadOnlySpan<ClrPrimitiveKind> Kinds
        {
            [MethodImpl(Inline), Op]
            get => recover<ClrPrimitiveKind>(PrimalKindData);
        }

        [MethodImpl(Inline), Op]
        static ref readonly SegMask filter(Field i)
            => ref skip(Masks, (byte)i);

        [MethodImpl(Inline), Op]
        static ref readonly SegPos index(Field i)
            => ref skip(Positions, (byte)i);

        [MethodImpl(Inline), Op]
        static ClrPrimitiveKind view(ClrPrimitiveKind src, SegPos offset)
            => (ClrPrimitiveKind)((byte)src >> (byte)offset);

        static ReadOnlySpan<byte> PrimalKindData => new byte[19]{
            (byte)ClrPrimitiveKind.None, //0:Empty/null
            (byte)ClrPrimitiveKind.Object, //1:Object
            (byte)ClrPrimitiveKind.DBNull, //2:DbNull
            (byte)ClrPrimitiveKind.U1, //3:Bool
            (byte)ClrPrimitiveKind.C16, //4:char
            (byte)ClrPrimitiveKind.I8, //5:int8
            (byte)ClrPrimitiveKind.U8, //6:uint8
            (byte)ClrPrimitiveKind.I16, //7:short
            (byte)ClrPrimitiveKind.U16, //8:ushort
            (byte)ClrPrimitiveKind.I32, //9:int32
            (byte)ClrPrimitiveKind.U32, //10:uint32
            (byte)ClrPrimitiveKind.I64, //11:int64
            (byte)ClrPrimitiveKind.U64, //12:uint64
            (byte)ClrPrimitiveKind.F32, //13:float32
            (byte)ClrPrimitiveKind.F64, //14:float64
            (byte)ClrPrimitiveKind.F128, //15:decimal
            (byte)ClrPrimitiveKind.DateTime, //16:datetime
            (byte)ClrPrimitiveKind.None, // 17:empty
            (byte)ClrPrimitiveKind.String //18:string
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