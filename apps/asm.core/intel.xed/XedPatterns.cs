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

        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        static Index<InstDefPart,string> DefPartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET,COMMENT};
    }
}