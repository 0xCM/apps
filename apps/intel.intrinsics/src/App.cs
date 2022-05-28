//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static IntelIntrinsics;

    class App : WfApp<App>
    {
        public static void start(params string[] args)
            => run(args, PartId.IntelIntrinsics, PartId.IntelCore, PartId.AsmCore);

        EventQueue Queue;

        IAppCmdService Commands;

        void EventRaised(IWfEvent e)
        {

        }

        protected override void OnInit()
        {
            Queue = EventQueue.allocate(GetType(), EventRaised);
            Commands = AppCmd.create(Wf);
        }

        protected override void Disposing()
        {
            EmptyQueue();
            Queue.Dispose();
        }

        void EmptyQueue()
        {
            while(Queue.Next(out var e))
                Wf.Raise(e);
        }

        protected override void Run()
            => Commands.Run();

        // protected override void Run(string[] args)
        // {
        //     var formatter = Tables.formatter<PageBankInfo>();
        //     Write(formatter.Format(Checks.BufferInfo,RecordFormatKind.KeyValuePairs));
        //     Checks.Run();
        // }
    }
}