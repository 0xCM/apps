//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using static core;
    using static Intrinsics;


    class App : WfApp<App>
    {
        public static void Main(params string[] args)
            => run(args, PartId.CpuDsl);

        EventQueue Queue;

        Checks Checks;

        IAppCmdService Commands;

        void EventRaised(IWfEvent e)
        {

        }

        protected override void OnInit()
        {
            Queue = EventQueue.allocate(GetType(), EventRaised);
            Checks = Checks.create(Wf);
            Commands = CpuDslCmd.create(Wf);
        }

        protected override void Disposing()
        {
            EmptyQueue();
            Queue.Dispose();
        }

        void EmptyQueue()
        {
            while(Queue.Emit(out var e))
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