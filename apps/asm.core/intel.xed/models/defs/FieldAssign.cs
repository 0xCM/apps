//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct FieldAssign
        {
            public readonly FieldKind Field;

            public readonly CellValue Value;

            [MethodImpl(Inline)]
            public FieldAssign(CellValue value)
            {
                Field = value.Field;
                Value = value;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0;
            }

            [MethodImpl(Inline)]
            public CellExpr Expression()
                => expr(OperatorKind.Eq, Value);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator FieldAssign(CellValue src)
                => new FieldAssign(src);

            public static FieldAssign Empty => new FieldAssign(CellValue.Empty);
        }
    }
}