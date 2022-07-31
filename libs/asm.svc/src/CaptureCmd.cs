//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public class CaptureCmd : AppCmdService<CaptureCmd>
    {
        Runtime Runtime => Wf.Runtime();

        IApiPack Dst => ApiPacks.create();

        ApiPacks ApiPacks => Wf.ApiPacks();

        [CmdOp("capture")]
        void Capture(CmdArgs args)
        {
            using var dispenser = Dispense.composite();
            var capture = new CaptureWorkflow(this, new());
            capture.Run(dispenser);
        }

        [CmdOp("capture/current")]
        void Captured()
        {
            var src = ApiPacks.Current();
            var files = ApiFiles.part(src,PartId.AsmCore);
            iter(files.Hex(), path => Write(path.ToUri()));            
        }

        [CmdOp("capture/settings")]
        void CaptureSettings(CmdArgs args)
        {
            if(args.Count == 0)
            {
                var settings = CaptureWorkflow.CaptureSettings.Default;
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