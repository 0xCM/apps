//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(PackedWidth,NativeWidth)]
        public readonly record struct LocatedField : IComparable<LocatedField>
        {
            public const byte NativeWidth = Coordinate.NativeWidth + num7.NativeWidth;

            public const byte PackedWidth = Coordinate.PackedWidth + num7.PackedWidth;

            public readonly Coordinate Location;

            public readonly FieldKind Field;

            [MethodImpl(Inline)]
            public LocatedField(Coordinate loc, FieldKind field)
            {
                Location = loc;
                Field = field;
            }

            public bool Equals(LocatedField src)
                => Location == src.Location && Field == src.Field;

            public override int GetHashCode()
                => Location.GetHashCode() | ((int)Field << 24);

            public string Format()
                => string.Format("{0} | 0x{1:X2} | {2}", Location, (byte)Field, Field == 0 ? 0.ToString() : Field.ToString());

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

            [MethodImpl(Inline)]
            public static implicit operator LocatedField((Coordinate c, FieldKind f) src)
                => new LocatedField(src.c,src.f);

            [MethodImpl(Inline)]
            public static implicit operator LocatedField(Paired<Coordinate,FieldKind> src)
                => new LocatedField(src.Left, src.Right);

            public static LocatedField Empty => default;

        }
    }
}