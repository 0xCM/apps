//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct FieldAssignment
        {
            public readonly FieldKind Field;

            readonly ulong Data;

            [MethodImpl(Inline)]
            public FieldAssignment(FieldKind field, ulong data)
            {
                Field = field;
                Data = data;
            }
        }

        public readonly struct FieldAssignment<T>
            where T : unmanaged
        {
            public readonly FieldKind Field;

            public readonly T Value;

            [MethodImpl(Inline)]
            public FieldAssignment(FieldKind field, T value)
            {
                Field = field;
                Value = value;
            }

            [MethodImpl(Inline)]
            public static implicit operator FieldAssignment<T>((FieldKind kind, T value) src)
                => new FieldAssignment<T>(src.kind, src.value);
        }
    }
}