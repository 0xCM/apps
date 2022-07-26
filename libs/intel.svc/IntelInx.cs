//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using System.Text;

    partial class IntelInx
    {
        public class CmdSvc : AppCmdService<CmdSvc>
        {
            IntelInx Intrinsics => Wf.IntelIntrinsics();

            Checks IntrinsicChecks => Wf.Checks();

            IntelSdm Sdm => Wf.IntelSdm();

            CpuIdSvc CpuId => Wf.CpuId();

            XedRuntime Xed => GlobalServices.Instance.Injected<XedRuntime>();

            SdeSvc Sde => Wf.SdeSvc();

            [CmdOp("intel/etl")]
            void ImportIntrinsics()
            {
                Intrinsics.RunEtl();
                Sdm.RunEtl();
                Sde.RunEtl();
                Xed.Start();
                Xed.RunEtl();

                //IntrinsicChecks.Run();
            }

            public static TextEncoding encoding()
                => new TextEncoding(Encoding.UTF8);

            [CmdOp("intel/int/algs")]
            void EmitAlgs()
            {
                var asset = Assets.Algorithms();
                Utf8.decode(asset.ResBytes, out var doc);
                FileEmit(doc, AppDb.DbOut("intrinsics").Path(algs,FileKind.Txt), TextEncodingKind.Utf8);
            }

        }
    }
}