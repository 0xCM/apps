//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public struct FieldSet
        {
            [MethodImpl(Inline), Op]
            public static FieldSet create(params FieldKind[] src)
                => new FieldSet(src);

            public const byte Capacity = 128;

            BitVector128<ulong> Data;

            [MethodImpl(Inline)]
            public FieldSet(ReadOnlySpan<FieldKind> src)
            {
                Data = default;
                var count = src.Length;
                for(byte i=0; i<count; i++)
                {
                    ref readonly var kind = ref skip(src,i);
                    if(kind != 0)
                        Data = Data.Enable((byte)kind);
                }
            }

            [MethodImpl(Inline)]
            public bit Contains(FieldKind src)
                => Data.Test((byte)src);

            [MethodImpl(Inline)]
            public FieldSet Include(FieldKind src)
            {
                if(src != 0)
                    Data = Data.Enable((byte)src);
                return this;
            }

            [MethodImpl(Inline)]
            public FieldSet Clear(FieldKind src)
            {
                Data = Data.Disable((byte)src);
                return this;
            }

            [MethodImpl(Inline)]
            public FieldSet Include(params FieldKind[] src)
            {
                for(var i=0; i<src.Length; i++)
                    Data = Data.Enable((byte)skip(src,i));
                return this;
            }

            [MethodImpl(Inline)]
            public uint Members(Span<FieldKind> dst)
            {
                var counter = z8;
                var count = min(dst.Length,Capacity);
                for(byte i=1; i<count; i++)
                {
                    if(Data.Test(i))
                        seek(dst,counter++) = (FieldKind)i;
                }
                return counter;
            }

            [MethodImpl(Inline)]
            public uint Count()
            {
                var counter = z8;
                var count = Capacity;
                for(byte i=1; i<count; i++)
                {
                    if(Data.Test(i))
                        counter++;
                }
                return counter;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Data.GetHashCode();
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Count() == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Count() != 0;
            }

            public string Format()
                => XedRender.format(this);

            public string Format(char sep)
                => XedRender.format(this, sep);

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public bool Equals(FieldSet src)
                => Data.Equals(src.Data);

            public override bool Equals(object src)
                => src is FieldSet x && Equals(x);

            [MethodImpl(Inline)]
            public static implicit operator FieldSet(ReadOnlySpan<FieldKind> src)
                => new FieldSet(src);

            [MethodImpl(Inline)]
            public static implicit operator FieldSet(Span<FieldKind> src)
                => new FieldSet(src);

            [MethodImpl(Inline)]
            public static implicit operator FieldSet(FieldKind[] src)
                => new FieldSet(src);

            [MethodImpl(Inline)]
            public static implicit operator FieldSet(Index<FieldKind> src)
                => new FieldSet(src);

            [MethodImpl(Inline)]
            public static bool operator==(FieldSet a, FieldSet b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator!=(FieldSet a, FieldSet b)
                => !a.Equals(b);
        }
    }
}