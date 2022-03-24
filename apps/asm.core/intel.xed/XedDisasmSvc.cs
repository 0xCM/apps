//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        XedRules Rules => Service(Wf.XedRules);

        XedPatterns Patterns => Service(Wf.XedPatterns);

        XedPaths XedPaths => Service(Wf.XedPaths);

        WsProjects Projects => Service(Wf.WsProjects);

        ConstLookup<OpWidthCode,OpWidthInfo> OperandWidths;

        bool PllExec {get;} = true;

        public XedDisasmSvc()
        {
        }

        protected override void OnInit()
        {
            var dst = dict<OpWidthCode,OpWidthInfo>();
            iter(Patterns.CalcOpWidths(), w => dst.TryAdd(w.Code, w));
            OperandWidths = dst;
        }

        OpWidthInfo OperandWidth(OpWidthCode type)
            => OperandWidths[type];
    }
}