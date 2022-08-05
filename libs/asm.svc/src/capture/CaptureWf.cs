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

        public void Run()
        {
            var dst = ApiPacks.create(timestamp());
            using var transport = new CaptureTransport(Dispense.composite(), Emitter);
            var capture = new CaptureWfRunner(this, new(), dst, transport);
            capture.Run();    
            RunChecks(transport, dst);
        }

        void RunChecks(CaptureTransport transport, IApiPack dst)
        {
            //var emitted = Heaps.located(src);            

            //CheckReloaded(transport, dst);
        }

        void CheckReloaded(CaptureTransport transport, IApiPack src)
        {
            var members = transport.TransmitReloaded(ApiCode.load(src, PartId.AsmCore, Emitter));
            for(var i=0; i<members.MemberCount; i++)
            {
                ref readonly var member = ref members.Member(i);
                ref readonly var token = ref members.Token(i);
                var encoding = members.Encoding(i);
                ref readonly var entry = ref member.EntryAddress;
                ref readonly var entryRb = ref member.EntryRebase;
                ref readonly var target = ref member.TargetAddress;
                ref readonly var targetRb = ref member.TargetRebase;
                ref readonly var uri = ref member.Uri;
            }
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