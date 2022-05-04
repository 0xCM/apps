//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedOperands;

    partial class XedRules
    {
        partial struct CellParser
        {
            public static void parse(string data, out CellTypeInfo dst)
            {
                Require.invariant(data.Length < 48);
                var kind = FieldParser.kind(data);
                var field = kind != 0 ? XedFields.field(kind) : ReflectedField.Empty;
                CellParser.ruleop(data, out RuleOperator op);
                dst = new (kind, CellParser.@class(field.Field, data), op, field.DataType, field.Size);
            }
        }
    }
}