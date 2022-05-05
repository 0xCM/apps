//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct LayoutComponent
        {
            public readonly FieldKind Field;

            public readonly LayoutCellKind CellKind;

            public readonly ushort CellData;

            [MethodImpl(Inline)]
            public LayoutComponent(FieldKind field, LayoutCellKind kind, ushort data)
            {
                Field = field;
                CellKind = kind;
                CellData = data;
            }
        }
    }
}