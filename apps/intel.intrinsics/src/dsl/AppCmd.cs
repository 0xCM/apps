//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static Z0.Parts.IntelIntrinsics;

    partial class IntelIntrinsics
    {
        public sealed class AppCmd : AppCmdService<AppCmd,CmdShellState>
        {
            Checks IntrinsicChecks => Wf.Checks();

            ref readonly Assets Assets => ref PartAssets;

            [Op]
            public static TextEncoding encoding()
                => new TextEncoding(Encoding.ASCII);

            [CmdOp("check")]
            Outcome RunChecks(CmdArgs args)
            {
                var asset = Assets.Algorithms();
                var doc = encoding().GetString(asset.ResBytes);

                IntrinsicChecks.Run();
                return true;
            }

        }
    }
}