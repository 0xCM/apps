//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        Symbols<IFormType> Forms;

        Symbols<IClass> Classes;

        XedRules Rules => Service(Wf.XedRules);

        XedPatterns Patterns => Service(Wf.XedPatterns);

        XedPaths XedPaths => Service(Wf.XedPaths);

        WsProjects Projects => Service(Wf.WsProjects);

        ConstLookup<OpWidthCode,OpWidthInfo> OperandWidths;

        public XedDisasmSvc()
        {
            Forms = Symbols.index<IFormType>();
            Classes = Symbols.index<IClass>();
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