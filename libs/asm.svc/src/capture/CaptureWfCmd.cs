//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public class CaptureWfCmd : AppCmdService<CaptureWfCmd>
    {
        Runtime Runtime => Wf.Runtime();

        IApiPack Dst => ApiPacks.create();

        ApiPacks ApiPacks => Wf.ApiPacks();

        CaptureWf CaptureWf => Wf.CaptureWf();

        [CmdOp("capture")]
        void Capture(CmdArgs args)
            => CaptureWf.Run();

        [CmdOp("capture/current")]
        void Captured()
        {
            var src = ApiPacks.Current();
            var files = ApiFiles.part(src,PartId.AsmCore);
            iter(files.Hex(), path => Write(path.ToUri()));            
        }

        [CmdOp("capture/settings")]
        void CaptureConfig(CmdArgs args)
        {
            if(args.Count == 0)
            {
                var settings = CaptureWfSettings.Default;
                var dst = AppDb.Settings("capture", FileKind.Toml);
                var data = settings.Format();
                Row(data);
                FileEmit(data,dst);
            }
        }

        [CmdOp("capture/context")]
        void CaptureContext()
            => Runtime.EmitContext(Dst);
    }
}