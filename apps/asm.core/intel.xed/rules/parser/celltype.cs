//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        partial struct CellParser
        {
            public static CellType celltype(string data)
            {
                Require.invariant(data.Length < 48);
                var kind = XedFields.kind(data);
                var field = kind != 0 ? XedFields.field(kind) : ReflectedField.Empty;
                CellParser.ruleop(data, out RuleOperator op);
                var wData = (byte)field.FieldSize.DataWidth;
                var wDom = (byte)field.FieldSize.DomainWidth;
                var tDom = field.DomainType;
                var tData = field.DataType;
                var @class = CellParser.@class(field.Field, data);
                if(@class.Kind == CK.Keyword)
                {
                    wDom = (byte)typeof(KeywordKind).Tag<DataWidthAttribute>().Require().ContentWidth;
                    wData = (byte)core.width<KeywordKind>();
                    tDom = new FieldTypeName(kind, nameof(CK.Keyword));
                    tData =new FieldTypeName(kind, nameof(CK.Keyword));
                }
                else if(@class.Kind == CK.BitLiteral)
                {
                    wDom = 8;
                    wData = 8;
                    tDom = new FieldTypeName(kind, nameof(uint8b));
                    tData =new FieldTypeName(kind, "byte");
                }
                else if(@class.Kind == CK.HexLiteral)
                {
                    wDom = 8;
                    wData = 8;
                    tDom = new FieldTypeName(kind, nameof(Hex8));
                    tData =new FieldTypeName(kind, "byte");
                }
                return new (field.Field, @class, op, tData, tDom, wData, wDom);
            }
        }
    }
}