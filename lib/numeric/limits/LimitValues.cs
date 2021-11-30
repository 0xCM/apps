//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct LimitValues
    {
        /// <summary>
        /// The smallest representable uint8 value
        /// </summary>
        public const byte Min8u = (byte)Limits.Min8u;

        /// <summary>
        /// The smallest representable int8 value
        /// </summary>
        public const sbyte Min8i = (sbyte)Limits.Min8i;

        /// <summary>
        /// The smallest representable uint16 value
        /// </summary>
        public const ushort Min16u = (ushort)Limits.Min16u;

        /// <summary>
        /// The smallest representable int16 value
        /// </summary>
        public const short Min16i = (short)Limits.Min16i;

        /// <summary>
        /// The smallest representable uint16 value
        /// </summary>
        public const uint Min32u = (uint)Limits.Min32u;

        /// <summary>
        /// The minimum representable <see cref='int'/> value
        /// </summary>
        public const int Min32i = int.MinValue;

        /// <summary>
        /// The minimum representable <see cref='long'/> value
        /// </summary>
        public const long Min64i = long.MinValue;

        /// <summary>
        /// The minimum representable <see cref='ulong'/> value
        /// </summary>
        public const ulong Min64u = ulong.MinValue;

        /// <summary>
        /// The minimum representable <see cref='float'/> value
        /// </summary>
        public const float Min32f = float.MinValue;

        /// <summary>
        /// The minimum representable <see cref='double'/> value
        /// </summary>
        public const double Min64f = double.MinValue;

        /// <summary>
        /// The maximum representable <see cref='sbyte'/> value
        /// </summary>
        public const sbyte Max8i = (sbyte)Limits.Max8i;

        /// <summary>
        /// The maximum representable <see cref='byte'/> value
        /// </summary>
        public const byte Max8u = (byte)Limits.Max8u;

        /// <summary>
        /// The maximum representable <see cref='short'/> value
        /// </summary>
        public const short Max16i = (short)Limits.Max8i;

        /// <summary>
        /// The maximum representable <see cref='ushort'/> value
        /// </summary>
        public const ushort Max16u = (ushort)Limits.Max16u;

        /// <summary>
        /// The largest representable uint64 value
        /// </summary>
        public const uint Max24u = (uint)Max16u | ((uint)Max8u << 16);

        /// <summary>
        /// The largest representable uint32 value
        /// </summary>
        public const uint Max32u = (uint)Limits.Max32u;

        /// <summary>
        /// The largest representable value v where v:uint40
        /// </summary>
        public const ulong Max40u = (ulong)Max32u | ((ulong)Max8u << 32);

        /// <summary>
        /// The largest representable value v where v:uint48
        /// </summary>
        public const ulong Max48u = (ulong)Max40u | ((ulong)Max8u << 40);

        /// <summary>
        /// The largest representable value v where v:uint56
        /// </summary>
        public const ulong Max56u = (ulong)Max48u | ((ulong)Max8u << 48);

        /// <summary>
        /// The maximum representable <see cref='ulong'/> value
        /// </summary>
        public const ulong Max64u = ulong.MaxValue;

        /// <summary>
        /// The minimum representable <see cref='long'/> value
        /// </summary>
        public const int Max32i = int.MaxValue;

        /// <summary>
        /// The maximum representable <see cref='long'/> value
        /// </summary>
        public const long Max64i = long.MaxValue;

        /// <summary>
        /// The maximum representable <see cref='float'/> value
        /// </summary>
        public const float Max32f = float.MaxValue;

        /// <summary>
        /// The maximum representable <see cref='double'/> value
        /// </summary>
        public const double Max64f = double.MaxValue;

    }
}