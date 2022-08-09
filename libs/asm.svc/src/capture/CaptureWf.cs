//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

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

        // void Run(ICompositeDispenser dispenser, IApiPack dst)
        // {
        //     var receiver = new CaptureReceiver(dispenser, Emitter);
        //     var capture = new CaptureWfRunner(this, new(), dst, receiver);
        //     capture.Run(dispenser);
        // }


        public void RunChecks(IApiPack src)
        {
            CaptureWfChecks.run(src, Emitter);            
        }

        public void Run()
        {
            var dst = ApiPacks.create(timestamp());
            using var transport = new CaptureTransport(Dispense.composite(), Emitter);
            var capture = new CaptureWfRunner(this, new(), dst, transport);
            capture.Run();    
            RunChecks(dst);
        }

        static SettingsStore Store = new();

        public static CaptureWfSettings settings()   
            => new();

        public static CaptureWfSettings settings(FS.FilePath src)   
            => Store.Load(src);

        public static void store(CaptureWfSettings src, FS.FilePath dst)
            => Store.Store(src,dst);
    }
}