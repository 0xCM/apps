//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(Width)]
        public readonly record struct LocatedField : IComparable<LocatedField>
        {
            [MethodImpl(Inline)]
            public static uint pack(LocatedField src)
            {
                var result = 0u;
                result |= Coordinate.pack(src.Location) << LocationOffset;
                result |= ((uint)src.Field << FieldOffset);
                return result;
            }

            [MethodImpl(Inline)]
            public static LocatedField unpack(uint src)
            {
                var location = Coordinate.unpack(src);
                var field = (FieldKind)((src & FieldMask) >> FieldOffset);
                return new LocatedField(location,field);
            }

            const byte LocationWidth = Coordinate.Width;

            const byte LocationOffset = 0;

            const uint LocationMask = Coordinate.Mask;

            const byte FieldWidth = num7.Width;

            const byte FieldOffset = LocationOffset + LocationWidth;

            const uint FieldMask =  num7.MaxValue << FieldOffset;

            public const byte Width = Coordinate.Width + num7.Width;

            public const uint Mask = LocationMask | FieldMask;

            public readonly Coordinate Location;

            public readonly FieldKind Field;

            [MethodImpl(Inline)]
            public LocatedField(Coordinate loc, FieldKind field)
            {
                Location = loc;
                Field = field;
            }

            public static uint encode(LocatedField src, Span<char> dst)
            {
                var buffer = recover<num4>(ByteBlock8.Empty.Bytes);
                num.unpack8x4(pack(src),buffer);
                return (byte)num.render8x8(buffer, dst);
            }

            public bool Equals(LocatedField src)
                => Location == src.Location && Field == src.Field;

            public override int GetHashCode()
                => Location.GetHashCode() | ((int)Field << 24);

            public string Format()
            {
                var left = string.Format("{0} | 0x{1:X2} | {2,-26}",
                    Location,
                    (byte)Field,
                    Field == 0 ? 0.ToString() : Field.ToString()
                    );

                var packed = pack(this);
                var unpacked = unpack(packed);
                Require.equal(this,unpacked);

                Span<char> encoded = stackalloc char[24];
                var count = encode(this,encoded);
                var last = text.format(slice(encoded,0,count));
                return string.Format("{0} | {1}", left, last);
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(LocatedField src)
            {
                var result = Location.CompareTo(src.Location);
                if(result == 0)
                    result = cmp(Field,src.Field);
                return result;
            }

            public static LocatedField Empty => default;
        }
    }
}