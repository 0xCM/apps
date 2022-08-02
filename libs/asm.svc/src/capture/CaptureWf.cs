//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection;
    using static Algs;

    public class CaptureWf : WfSvc<CaptureWf>, ICaptureReceiver
    {
        public class SettingsStore : Repository<FS.FilePath, CaptureWfSettings, FS.FilePath>
        {
            public override CaptureWfSettings Load(FS.FilePath key)
            {
                throw new NotImplementedException();
            }

            public override void Store(CaptureWfSettings src, FS.FilePath dst)
            {
                
            }
        }

        WorkflowState State;

        public void Run(ICompositeDispenser dispenser, IApiPack dst)
        {
            State = new();
            var capture = new CaptureWfRunner(this, new(), dst, this);
            capture.Run(dispenser);
        }

        public void Run(IApiPack dst)
        {
            using var dispenser = Dispense.composite();
            Run(dispenser, dst);
        }

        public void Run()
            => Run(ApiPacks.create(timestamp()));

        static SettingsStore Store = new();

        public static CaptureWfSettings settings()   
            => new();

        public static CaptureWfSettings settings(FS.FilePath src)   
            => Store.Load(src);

        public static void store(CaptureWfSettings src, FS.FilePath dst)
            => Store.Store(src,dst);

        void ICaptureReceiver.Capturing(Assembly src)
        {
            State.Assemblies.Add(src);            
        }

        void ICaptureReceiver.Captured(Assembly src)
        {
        }

        class WorkflowState
        {
            public readonly ConcurrentBag<Assembly> Assemblies = new();
        }
    }
}