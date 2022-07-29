//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class CaptureCmd : AppCmdService<CaptureCmd>
    {
        Runtime Runtime => Wf.Runtime();

        IApiPack Dst => ApiPacks.create();

        [CmdOp("capture")]
        void Capture(CmdArgs args)
        {
            var capture = new CaptureWorkflow(this, new());
            capture.Run();
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