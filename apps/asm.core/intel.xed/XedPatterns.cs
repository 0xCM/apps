//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedRules.InstRulePartNames;

    public partial class XedPatterns : AppService<XedPatterns>
    {
        XedPaths XedPaths => Service(Wf.XedPaths);

        ConstLookup<OpWidthCode,OpWidthInfo> OpWidthsLookup;

        Index<OpWidthInfo> OpWidths;

        protected override void Initialized()
        {
            InitializeWidths();
        }

        void InitializeWidths()
        {
            OpWidths = LoadOpWidths();
            OpWidthsLookup = CalcOpWidthLookup(OpWidths);
        }

        static Index<InstRulePart,string> PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET,COMMENT};
    }
}