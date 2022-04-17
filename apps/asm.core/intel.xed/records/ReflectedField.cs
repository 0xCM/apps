//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct ReflectedFields
        {
            public static ReflectedFields init()
                => new ReflectedFields(sys.alloc<ReflectedField>(128));

            readonly Index<FieldKind,ReflectedField> Data;

            [MethodImpl(Inline)]
            ReflectedFields(Index<FieldKind,ReflectedField> src)
            {
                Data = src;
            }

            public byte Count
            {
                [MethodImpl(Inline)]
                get => (byte)Data.Count;
            }

            public ref ReflectedField this[FieldKind kind]
            {
                [MethodImpl(Inline)]
                get => ref Data[kind];
            }

            public ref ReflectedField this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[(FieldKind)i];
            }

            public ref ReflectedField this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[(FieldKind)i];
            }

            public ReadOnlySpan<ReflectedField> Valid
            {
                [MethodImpl(Inline)]
                get => core.slice(Data.View,1);
            }

            [MethodImpl(Inline)]
            public static implicit operator Index<ReflectedField> (ReflectedFields src)
                => src.Data.Storage;

        }
        [Record(TableName)]
        public struct ReflectedField
        {
            public const string TableName = "xed.fields.reflected";

            public const byte FieldCount = 7;

            public ushort Index;

            public FieldKind Field;

            public FieldSize FieldSize;

            public FieldSize TotalSize;

            public FieldTypeName DataKind;

            public FieldTypeName DomainType;

            public TextBlock Description;

            public static ReflectedField Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,20,20,16,16,1};
        }
    }
}