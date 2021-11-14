//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    using static core;

    partial struct MMIX
    {
        public class MachineControl
        {
            static long MachineSeq;

            const uint Capacity = 256;

            static KeyedValues<uint, Machine> Machines;

            public static MachineControl create()
                => new MachineControl();

            static MachineControl()
            {
                MachineSeq = -1;
                Machines = new(Capacity);
            }

            public bool CreateMachine(out Machine m)
            {
                if(MachineSeq < Capacity)
                {
                    m = Machine.allocate((uint)inc(ref MachineSeq));
                    Machines[m.Id] = (m.Id, m);
                    return true;
                }
                else
                {
                    m = default;
                    return false;
                }
            }
        }
    }
}