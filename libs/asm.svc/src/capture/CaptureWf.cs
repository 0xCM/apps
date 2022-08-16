//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

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

        public void RunChecks(IApiPack src)
        {
            CaptureWfChecks.run(src, Emitter);            
        }

        static CaptureWfRunner runner(IWfSvc svc, CaptureWfSettings settings, IApiPack dst, CaptureTransport transport)
            => new CaptureWfRunner(svc, settings, dst, transport);

        public void Run(CmdArgs args)
        {
            var dst = ApiPacks.create(Algs.timestamp());
            var settings = new CaptureWfSettings();
            var svc = this;
            using var transport = new CaptureTransport(Dispense.composite(), Emitter);
            if(args.Count !=0)
            {
                var parts = list<PartId>();
                iter(args, arg => {
                    if(PartNames.parse(arg.Value, out var name))
                        parts.Add(name);
                    else
                        Warn($"{arg.Value} is not a part");
                });

                settings.Parts = parts.ToSeq();
            }
            
            var src = FS.path(ExecutingPart.Assembly.Location).FolderPath;
            var catalog = ApiRuntime.catalog(ApiRuntime.assemblies(src));
            runner(svc, settings, dst, transport).Run(catalog);
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