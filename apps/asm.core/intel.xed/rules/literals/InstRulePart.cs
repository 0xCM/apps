//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        /// <summary>
        /// Classfies aspects that define an instruction rule
        /// </summary>
        public enum InstRulePart : byte
        {
            Class,

            Form,

            Attributes,

            Category,

            Extension,

            Flags,

            Pattern,

            Operands,

            Isa,

            Comment
        }
    }
}