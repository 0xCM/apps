//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.Diagnostics.Runtime;

    public sealed class ClrMdSvc : AppService<ClrMdSvc>
    {
        DataTarget Target;

        ClrRuntime Runtime;

        int ProcId;

        Process Proc;

        bool Attached => Target != null && Runtime != null;

        public ClrMdSvc()
        {
            ProcId = Process.GetCurrentProcess().Id;
            Proc = Process.GetProcessById(ProcId);
            ChildProcessTracker.AddProcess(Proc);
        }

        public void Attach()
        {
            if(Attached)
                return;

            Wf.Babble(string.Format("Attaching to {0}", ProcId));
            Target = DataTarget.CreateSnapshotAndAttach(ProcId);
            Runtime = Target.ClrVersions.Single().CreateRuntime();
            Wf.Babble("Attached");
        }

        public void Detach()
        {
            if(Attached)
            {
                Wf.Babble(string.Format("Detaching from {0}", ProcId));
                Runtime.Dispose();
                Runtime = null;
                Target.Dispose();
                Target = null;

                Wf.Babble("Detached");
            }
        }

        protected override void OnInit()
        {
            Attach();
        }

        public void Collect()
        {
            foreach (ClrThread thread in Runtime.Threads)
            {
                Console.WriteLine($"{thread.OSThreadId:x}:");
                foreach (ClrStackFrame frame in thread.EnumerateStackTrace())
                    Console.WriteLine($"    {frame}");
            }
        }

        public void ParseDump()
            => Wf.DumpParser().ParseDump();

        public void ParseDump(FS.FilePath src)
            => Wf.DumpParser().ParseDump(src);

        protected override void Disposing()
        {
            Detach();
        }
    }
}