//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum FieldDataType : byte
        {
            None,

            Bit,

            Byte,

            Word,

            Reg,

            BCast,

            Chip,

            InstClass,

            Operator,

            Keyword,

            Nonterminal,

            Text,

            Char,

            SegSpec,

            Seg,
        }
    }
}