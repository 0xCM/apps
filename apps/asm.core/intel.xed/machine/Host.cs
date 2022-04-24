//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedMachine;
    using static core;

    partial class XTend
    {
        public static MachineHost XedMachinHost(this IWfRuntime wf)
            => MachineHost.create(wf);
    }

    partial class XedMachine
    {
        public static XedMachine allocate(IAppService svc)
            => new XedMachine(svc);

        public class MachineHost : AppService<MachineHost>
        {
            uint6 Current = 0;

            int Counter = 0;

            ConcurrentDictionary<uint,XedMachine> Allocated = new();

            XedRules Rules => Service(Wf.XedRules);

            const byte Capacity = uint6.MaxValue + 1;

            protected override void Initialized()
            {
                for(var i=0; i<Capacity; i++)
                {
                    var machine = allocate(this);
                    Allocated[machine.Id] = machine;
                }
            }

            protected override void Disposing()
            {
                iter(Allocated.Values, machine => machine.Dispose());
            }

            static void EmitClassGroups(XedMachine machine, Index<InstPattern> src)
            {
                var classes = hashset<InstClass>();
                iter(src, EmitDistinct);

                void EmitDistinct(InstPattern src)
                {
                    if(!classes.Contains(src.Classifier))
                    {
                        classes.Add(src.Classifier);
                        transition(machine,src,() => machine.Emitter.EmitClassGroups());
                    }
                }
            }

            [MethodImpl(Inline)]
            static void transition(XedMachine machine, InstPattern src, Action f)
                => machine.Transition(src,f);

            public void Run()
            {
                var patterns = Rules.CalcInstPatterns();
                var selected = patterns.Where(x => x.Classifier == IClass.AND);
                using var machine = XedMachine.allocate(this);
                EmitClassGroups(machine, selected);
            }

            public void Reset()
            {
                iter(Allocated.Values, machine => machine.Reset());
            }


            public void Run(bool rent, Action<XedMachine> f)
            {
                var machine = default(XedMachine);
                if(rent)
                {
                    Current = (byte)inc(ref Counter);
                    machine = Allocated[Current];
                    if(Counter > Capacity)
                        machine.Reset();
                }
                else
                    machine = allocate(this);
                f(machine);
            }
        }
    }
}