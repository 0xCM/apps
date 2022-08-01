//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CaptureWf : WfSvc<CaptureWf>
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

        public void Run(IApiPack dst)
        {
            using var dispenser = Dispense.composite();
            Run(dispenser, dst);
        }

        public HostCollection Run(ICompositeDispenser dispenser, IApiPack dst)
        {
            var capture = new CaptureWfRunner(this, new(), dst);
            return capture.Run(dispenser);
        }

        public void Run()
            => Run(ApiPacks.create());

        static SettingsStore Store = new();

        public static CaptureWfSettings settings()   
            => new();

        public static CaptureWfSettings settings(FS.FilePath src)   
            => Store.Load(src);

        public static void store(CaptureWfSettings src, FS.FilePath dst)
            => Store.Store(src,dst);
    }
}