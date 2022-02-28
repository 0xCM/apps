//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
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
            IClass,

            IForm,

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