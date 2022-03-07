//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRules;
    using K = XedRules.FieldKind;

    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        Symbols<IFormType> Forms;

        Symbols<IClass> Classes;

        XedRules Rules => Service(Wf.XedRules);

        XedPaths XedPaths => Service(Wf.XedPaths);

        WsProjects Projects => Service(Wf.WsProjects);

        ConstLookup<OperandWidthKind,OperandWidth> OperandWidths;

        public XedDisasmSvc()
        {
            Forms = Symbols.index<IFormType>();
            Classes = Symbols.index<IClass>();
        }

        protected override void OnInit()
        {
            var dst = dict<OperandWidthKind,OperandWidth>();
            iter(Rules.LoadOperandWidths(), w => dst.TryAdd(w.Code, w));
            OperandWidths = dst;
        }

        OperandWidth OperandWidth(OperandWidthKind type)
            => OperandWidths[type];

        void UpdateState(RuleMachine machine, in FieldAssign src, ref DisasmState state)
        {
            var kind = src.Field;
            var result = Outcome.Success;
            machine.Update(src);
            switch(kind)
            {
                case K.DISP:
                    state.DISP = src.Value;
                break;
            }
        }
    }
}