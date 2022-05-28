//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class App : WfApp<App>
    {
        public static void start(params string[] args)
            => run(args, PartId.IntelIntrinsics, PartId.IntelCore, PartId.AsmCore);

        EventQueue Queue;

        void EventRaised(IWfEvent e)
        {

        }

        protected override void OnInit()
        {
            Queue = EventQueue.allocate(GetType(), EventRaised);
            //Commands = AppCmd.create(Wf);
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
        {
            //Commands.Run();
        }
    }
}