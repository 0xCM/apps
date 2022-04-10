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

            const byte NullIndex = 14;

            const byte IdIndex = 15;

            [MethodImpl(Inline)]
            public SegSpec(SegSpecType type, ReadOnlySpan<char> pattern)
            {
                var data = ByteBlock16.Empty;
                Asci.encode(pattern, out asci16 a16);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[IdIndex] = type.Id;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecType type, char c0)
            {
                var data = ByteBlock16.Empty;
                var a16 = new asci16(c0);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[IdIndex] = (byte)type.Id;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecType type, char c0, char c1)
            {
                var data = ByteBlock16.Empty;
                var a16 = new asci16(c0, c1);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[IdIndex] = (byte)type.Id;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecType type, char c0, char c1, char c2)
            {
                var data = ByteBlock16.Empty;
                var a16 = new asci16(c0, c1, c2);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[IdIndex] = (byte)type.Id;
                Data = data;
            }

            [MethodImpl(Inline)]
            public SegSpec(SegSpecType type, char c0, char c1, char c2, char c3)
            {
                var data = ByteBlock16.Empty;
                var a16 = new asci16(c0, c1, c2, c3);
                data = a16.Storage;
                data[NullIndex] = 0;
                data[IdIndex] = (byte)type.Id;
                Data = data;
            }

            public readonly byte Id
            {
                [MethodImpl(Inline)]
                get => Data[IdIndex];
            }

            public SegSpecType Type
            {
                [MethodImpl(Inline)]
                get => new (Id);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Id == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Id != 0;
            }

            public string Format()
                => Data.Format();

            public override string ToString()
                => Format();

            public static SegSpec Empty => default;
        }
    }
}