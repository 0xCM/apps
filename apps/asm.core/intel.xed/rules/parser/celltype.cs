//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial struct CellParser
        {
            public static CellTypeInfo celltype(string data)
            {
                Require.invariant(data.Length < 48);
                var kind = XedFields.kind(data);
                var field = kind != 0 ? XedFields.field(kind) : ReflectedField.Empty;
                CellParser.ruleop(data, out RuleOperator op);
                var @class = CellParser.@class(field.Field, data);
                return new (kind, @class, op, field.DataType, field.PackedWidth);
            }
        }
    }
}