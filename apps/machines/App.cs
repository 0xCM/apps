//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    using static Root;
    using static core;

    class App : WfApp<App>
    {
        public static void Main(params string[] args)
            => run(args, PartId.Cpu, PartId.CalcShell);

        MachineRunner TM;

        protected override void Disposing()
        {
            TM.Dispose();
        }

        void Run(N22 n)
        {
            TM = MachineRunner.create(Wf);
            TM.Run();
        }


        void Run(string spec)
        {
            if(uint.TryParse(spec, out var n))
            {
                switch(n)
                {
                    case 22:
                        Run(n22);
                    break;
                }
            }
        }

        protected override void Run()
        {
        }

        protected override void Run(string[] args)
        {
            var count = args.Length;
            for(var i=0; i<count; i++)
                Run(skip(args,i));
        }
    }
}