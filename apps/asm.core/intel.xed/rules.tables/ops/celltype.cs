//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial struct TableCalcs
        {
            public static CellType celltype(in CellSpec src)
            {
                var field = XedLookups.Service.FieldSpec(src.Field);
                CellParser.parse(src.Data, out RuleOperator op);
                return new (field.FieldKind, CellParser.@class(src.Data), op,
                    field.DeclaredType.Text, (byte)field.DataWidth,
                    field.EffectiveType.Text, (byte)field.EffectiveWidth
                    );
            }
        }
    }
}