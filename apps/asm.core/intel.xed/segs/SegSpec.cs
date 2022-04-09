//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct SegSpec
        {
            readonly ByteBlock16 Data;

            const byte NullIndex = 13;

            const byte KindIndex = 14;

            const byte RefinedIndex = 15;

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, ReadOnlySpan<char> pattern)
            {
                var data = ByteBlock16.Empty;
                Asci.encode(pattern, out asci16 a16);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[KindIndex] = (byte)kind;
                data[RefinedIndex] = 0;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(ImmSpec kind, ReadOnlySpan<char> pattern)
            {
                var data = ByteBlock16.Empty;
                Asci.encode(pattern, out asci16 a16);
                data[NullIndex] = 0;
                data[KindIndex] = (byte)SegSpecKind.Imm;
                data[RefinedIndex] = (byte)kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(DispSpec kind, ReadOnlySpan<char> pattern)
            {
                var data = ByteBlock16.Empty;
                Asci.encode(pattern, out asci16 a16);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[KindIndex] = (byte)SegSpecKind.Disp;
                data[RefinedIndex] = (byte)kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(AddressDispSpec kind, ReadOnlySpan<char> pattern)
            {
                var data = ByteBlock16.Empty;
                Asci.encode(pattern, out asci16 a16);
                Data = a16.Storage;
                data[NullIndex] = 0;
                data[KindIndex] = (byte)SegSpecKind.AddressDisp;
                data[RefinedIndex] = (byte)kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0)
            {
                var data = ByteBlock16.Empty;
                var a16 = new asci16(c0);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[KindIndex] = (byte)kind;
                data[RefinedIndex] = 0;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0, char c1)
            {
                var data = ByteBlock16.Empty;
                var a16 = new asci16(c0, c1);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[KindIndex] = (byte)kind;
                data[RefinedIndex] = 0;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0, char c1, char c2)
            {
                var data = ByteBlock16.Empty;
                var a16 = new asci16(c0, c1, c2);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[KindIndex] = (byte)kind;
                data[RefinedIndex] = 0;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecKind kind, char c0, char c1, char c2, char c3)
            {
                var data = ByteBlock16.Empty;
                var a16 = new asci16(c0, c1, c2, c3);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[KindIndex] = (byte)kind;
                data[RefinedIndex] = 0;
                Data = data;
            }

            public readonly SegSpecKind Kind
            {
                [MethodImpl(Inline)]
                get => (SegSpecKind)Data[KindIndex];
            }

            public byte KindRefined
            {
                [MethodImpl(Inline)]
                get => Data[RefinedIndex];
            }

            public ImmSpec ImmSpec
            {
                [MethodImpl(Inline)]
                get => (ImmSpec)Data[RefinedIndex];
            }

            public DispSpec Disp
            {
                [MethodImpl(Inline)]
                get => (DispSpec)Data[RefinedIndex];
            }

            public AddressDispSpec AddressDisp
            {
                [MethodImpl(Inline)]
                get => (AddressDispSpec)Data[RefinedIndex];
            }

            public bool IsImm
            {
                [MethodImpl(Inline)]
                get => Kind == SegSpecKind.Imm;
            }

            public bool IsDisp
            {
                [MethodImpl(Inline)]
                get => Kind == SegSpecKind.Disp;
            }

            public bool IsAddressDisp
            {
                [MethodImpl(Inline)]
                get => Kind == SegSpecKind.AddressDisp;
            }

            public bool IsBitfieldSpec
            {
                [MethodImpl(Inline)]
                get => Kind == SegSpecKind.Bitfield;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public string Format()
                => Data.Format();

            public override string ToString()
                => Format();

            public static SegSpec Empty => default;
        }
    }
}