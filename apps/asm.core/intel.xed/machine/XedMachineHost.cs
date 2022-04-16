//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedMachine
    {
        public class MachineHost : AppService<MachineHost>
        {
            XedRules Rules => Service(Wf.XedRules);

            void EmitClassForms(XedMachine machine, Index<InstPattern> src)
                => machine.Transition(src, () => machine.Emitter.EmitClassForms());

            void EmitClassGroups(XedMachine machine, Index<InstPattern> src)
                => machine.Transition(src, () => machine.Emitter.EmitClassGroups());

            void Transition(XedMachine machine, Index<InstPattern> src)
            {
                EmitClassForms(machine, src);
                EmitClassGroups(machine, src);
            }

            public void Run()
            {
                var patterns = Rules.CalcInstPatterns();
                var selected = patterns.Where(x => x.Classifier == IClass.AND);

                using var machine = XedMachine.allocate(Wf);
                Transition(machine, selected);
            }
        }
    }
}