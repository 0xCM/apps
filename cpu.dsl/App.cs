//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using static core;
    using static Intrinsics;

    using Types;

    class App : WfApp<App>
    {
        public static void Main(params string[] args)
            => run(args, PartId.CpuDsl);

        IPolySource Source;

        EventQueue Queue;

        Checks Checks;

        void EventRaised(IWfEvent e)
        {

        }

        protected override void OnInit()
        {
            Queue = EventQueue.allocate(GetType(), EventRaised);
            Source = Rng.@default();
            Checks = Checks.create(Wf);
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
        {

        }


        void Run(string spec)
        {

        }

        protected override void Run(string[] args)
        {
            var formatter = Tables.formatter<PageBankInfo>();
            Write(formatter.Format(Checks.BufferInfo,RecordFormatKind.KeyValuePairs));
            Checks.Run();
            // var count = args.Length;
            // for(var i=0; i<count; i++)
            //     Run(skip(args,i));
        }
    }
}