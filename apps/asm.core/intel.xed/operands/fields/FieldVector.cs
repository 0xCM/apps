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
        public record struct FieldVector
        {
            [MethodImpl(Inline)]
            public static FieldVector init(byte n)
                => new FieldVector(n);

            [MethodImpl(Inline)]
            public static FieldVector from(ReadOnlySpan<FieldKind> src)
                => new FieldVector(src);

            const byte SegWidth = 4;

            const byte Capacity = 64;

            const byte MaxLength = (Capacity - 4)/SegWidth;

            const byte LengthOffset = 60;

            ulong Data;

            [MethodImpl(Inline)]
            public FieldVector(byte n)
            {
                Data = (ulong)n << LengthOffset;
            }

            [MethodImpl(Inline)]
            public FieldVector(FieldKind f0)
                : this(1)
            {
                Data |= sll(f0, 0);
            }

            [MethodImpl(Inline)]
            public FieldVector(FieldKind f0, FieldKind f1)
                : this(2)
            {
                Data |= sll(f0, 0) | sll(f1, 1);
            }

            [MethodImpl(Inline)]
            public FieldVector(FieldKind f0, FieldKind f1, FieldKind f2)
                : this(3)
            {
                Data |= sll(f0, 0) | sll(f1, 1) | sll(f2,2);
            }

            [MethodImpl(Inline)]
            public FieldVector(ReadOnlySpan<FieldKind> src)
            {
                var n = (byte)math.min(src.Length, MaxLength);
                Data =  ((ulong)n << LengthOffset);
                for(var i=z8; i<n; i++)
                    Data |= sll(skip(src,i), i);
            }

            public byte N
            {
                [MethodImpl(Inline)]
                get => (byte)(Data >> LengthOffset);
            }

            public FieldKind this[byte index]
            {
                [MethodImpl(Inline)]
                get => read(Data,index);
                set => Data = write(Data, index, value);
            }

            public string Format()
            {
                const string Slot0 = "{0}";
                const string SlotM = ", {0}";
                var dst = text.buffer();
                var n = N;
                for(var i=z8; i<n; i++)
                    dst.AppendFormat(i > 0 ? SlotM : Slot0, text.ifempty(XedRender.format(this[i]),"0"));
                return text.enclose(dst.Emit(), RenderFence.Angled);
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            static byte offset(byte index)
                => (byte)(index*SegWidth);

            [MethodImpl(Inline)]
            static ulong clear(ulong src, byte index)
                => bits.disable4(src, offset(index));

            static FieldKind read(ulong src, byte index)
                => (FieldKind)bits.slice(src, offset(index), SegWidth);

            [MethodImpl(Inline)]
            static ulong write(ulong src, byte i, FieldKind value)
                => clear(src, i) | sll(value,i);

            [MethodImpl(Inline)]
            static ulong sll(FieldKind f, byte i)
                => (ulong)f << offset(i);
        }
    }
}