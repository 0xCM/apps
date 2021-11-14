//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    //using Machines.X86;

    // struct MachineEvents : IEventSink
    // {
    //     readonly Action<IWfEvent> Receiver;

    //     public MachineEvents(Action<IWfEvent> receiver)
    //     {
    //         Receiver = receiver;
    //     }

    //     public void Deposit(IWfEvent src)
    //     {
    //         Receiver(src);
    //     }

    //     public void Dispose()
    //     {

    //     }
    // }

    // partial class LlvmCmd
    // {
    //     [CmdOp(".machine")]
    //     Outcome RunMachine(CmdArgs args)
    //     {
    //         void OnEvent(IWfEvent e)
    //         {

    //         }

    //         using var sink = new MachineEvents(OnEvent);
    //         using var machine = Control.intel64(EventSignals.signal(sink, GetType()));
    //         machine.Run();

    //         return true;
    //     }
    // }
}