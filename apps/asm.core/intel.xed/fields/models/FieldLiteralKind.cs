//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum FieldLiteralKind : byte
        {
            None,

            HexLiteral = CellDataKind.HexLiteral,

            BinaryLiteral = CellDataKind.BinaryLiteral,

            DecimalLiteral = CellDataKind.DecimalLiteral,

            Wildcard = CellDataKind.Wildcard,

            Null = CellDataKind.Null,

            Default = CellDataKind.Default,

            Error = CellDataKind.Error,

            Text = CellDataKind.Text,
        }
    }
}