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

        XedPaths XedPaths => Service(Wf.XedPaths);

        WsProjects Projects => Service(Wf.WsProjects);

        ConstLookup<OpWidthCode,OpWidth> OperandWidths;

        public XedDisasmSvc()
        {
            Forms = Symbols.index<IFormType>();
            Classes = Symbols.index<IClass>();
        }

        protected override void OnInit()
        {
            var dst = dict<OpWidthCode,OpWidth>();
            iter(Rules.LoadOperandWidths(), w => dst.TryAdd(w.Code, w));
            OperandWidths = dst;
        }

        OpWidth OperandWidth(OpWidthCode type)
            => OperandWidths[type];
    }
}