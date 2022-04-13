//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(128)]
        public readonly record struct FieldType
        {
            const byte ZeroIndex = 14;

            const byte FieldIndex = 15;

            readonly ByteBlock16 Storage;

            public FieldType(FieldKind kind, string name)
            {
                var data = ByteBlock16.Empty;
                asci16 type = name;
                data = type.Storage;
                data[ZeroIndex] = 0;
                data[FieldIndex] = (byte)kind;
                Storage = data;
            }

            public asci16 Type
            {
                [MethodImpl(Inline)]
                get
                {
                    var data = Storage;
                    data[FieldIndex] = 0;
                    return new (data.Bytes);
                }
            }

            public readonly FieldKind Field
            {
                [MethodImpl(Inline)]
                get => (FieldKind)Storage[15];
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Storage.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Storage.IsEmpty;
            }

            public string Format()
                => IsEmpty ? EmptyString : Type.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator asci16(FieldType src)
                => src.Type;
        }
    }
}