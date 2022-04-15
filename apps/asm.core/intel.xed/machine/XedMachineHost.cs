//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedMachine
    {
        public class MachineHost : AppService<MachineHost>
        {
            XedRules Rules => Service(Wf.XedRules);

            void Step(XedMachine machine, InstPattern pattern)
            {
                machine.Pattern() = pattern;
                machine.Emitter.EmitClassForms();
            }

            void Step(XedMachine machine, Index<InstPattern> src)
            {
                var ws = Ws.Project("xed.machine");
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var pattern =ref src[i];
                    if(pattern.InstClass.Classifier == IClass.AND)
                    {
                        Step(machine, pattern);
                    }
                }
            }

            public void Run()
            {
                var patterns = Rules.CalcInstPatterns();
                using var machine = XedMachine.allocate(Wf);
                Step(machine,patterns);
            }
        }
    }
}