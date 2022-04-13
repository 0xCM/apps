//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(8)]
        public enum LogicKind : byte
        {
            None = 0,

            Antecedant = (byte)Chars.A,

            Operator = (byte)Chars.f,

            Consequent = (byte)Chars.C,
        }
    }
}