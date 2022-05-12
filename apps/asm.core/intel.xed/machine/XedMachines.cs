//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedRules;
    using static XedModels;
    using static XedOperands;

    public partial class XedMachines : AppService<XedMachines>
    {
        XedRuntime Xed;

        uint6 Current = 0;

        int Counter = 0;

        ConcurrentDictionary<uint, IMachine> Allocations = new();

        const byte Capacity = uint6.MaxValue + 1;

        bool Allocated = false;

        void Allocate()
        {
            if(!Allocated)
            {
                for(var i=0; i<Capacity; i++)
                {
                    var machine = XedOperands.machine(Xed);
                    Allocations[machine.Id] = machine;
                }
                Allocated = true;
            }
        }

        protected override void Disposing()
            => iter(Allocations.Values, machine => machine.Dispose());

        public XedMachine Run(XedRuntime xed)
        {
            Xed = xed;
            Allocate();
            var patterns = xed.Views.Patterns;
            var selected = patterns.Where(x => x.Classifier == IClass.AND);
            return new XedMachine(xed);
        }

        public void Reset()
        {
            iter(Allocations.Values, machine => machine.Reset());
        }

        public void Run(bool rent, Action<IMachine> f)
        {
            var machine = default(IMachine);
            if(rent)
            {
                Current = (byte)inc(ref Counter);
                machine = Allocations[Current];
                if(Counter > Capacity)
                    machine.Reset();
            }
            else
                machine = XedOperands.machine(Xed);

            f(machine);
        }
    }
}