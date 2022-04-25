//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using static XedFields;

    partial class XedGrids
    {
        public class LogicGrids
        {
            public static LogicGrids init(IWfRuntime wf)
                => new LogicGrids(wf);

            readonly FieldRender Render;

            readonly Index<LogicGrid> Enabled;

            readonly RuleTables Rules;

            LogicGrids(IWfRuntime wf)
            {
                Render = new();
                Rules = wf.XedRules().CalcRules();
                Enabled = sys.empty<LogicGrid>();
            }
        }
    }
}