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
        public class Host : AppService<Host>
        {
            XedRuntime Xed;

            uint6 Current = 0;

            int Counter = 0;

            ConcurrentDictionary<uint,XedMachine> Allocations = new();

            const byte Capacity = uint6.MaxValue + 1;

            bool Allocated = false;

            void Allocate()
            {
                if(!Allocated)
                {
                    for(var i=0; i<Capacity; i++)
                    {
                        var machine = allocate(Xed);
                        Allocations[machine.Id] = machine;
                    }
                    Allocated = true;
                }

            }

            protected override void Disposing()
            {
                iter(Allocations.Values, machine => machine.Dispose());
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
                        transition(machine,src,() => machine.Emissions.EmitClassGroups());
                    }
                }
            }

            [MethodImpl(Inline)]
            static void transition(XedMachine machine, InstPattern src, Action f)
                => machine.Transition(src,f);

            public void Run(XedRuntime xed)
            {
                Xed = xed;
                Allocate();
                var patterns = xed.Rules.CalcInstPatterns();
                var selected = patterns.Where(x => x.Classifier == IClass.AND);
                using var machine = XedMachine.allocate(xed);
                EmitClassGroups(machine, selected);
            }

            public void Reset()
            {
                iter(Allocations.Values, machine => machine.Reset());
            }

            public void Run(bool rent, Action<XedMachine> f)
            {
                var machine = default(XedMachine);
                if(rent)
                {
                    Current = (byte)inc(ref Counter);
                    machine = Allocations[Current];
                    if(Counter > Capacity)
                        machine.Reset();
                }
                else
                    machine = allocate(Xed);
                f(machine);
            }
        }
    }
}