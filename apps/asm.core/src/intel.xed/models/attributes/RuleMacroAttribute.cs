//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h/all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XedRules
    {
        public class RuleMacroAttribute : Attribute
        {
            public RuleMacroAttribute(RuleMacroName name)
            {
                Name = name;
            }

            public RuleMacroName Name {get;}
        }
    }
}