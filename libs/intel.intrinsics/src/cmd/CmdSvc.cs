//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using System.Text;

    partial class IntelIntrinsics
    {
        public class CmdSvc : AppCmdService<CmdSvc>
        {
            IntelIntrinsics Intrinsics => Wf.IntelIntrinsics();

            Checks IntrinsicChecks => Wf.Checks();

            [CmdOp("intel/int/etl")]
            void ImportIntrinsics()
            {
                var intrinsics = Intrinsics.Etl();
                var types = intrinsics.SelectMany(x => x.parameters).Select(x => x.type.Format().Remove("*").Remove("const").Trim()).Distinct().Sort();
                iter(types, t => Write(t));
            }

            public static TextEncoding encoding()
                => new TextEncoding(Encoding.UTF8);

            [CmdOp("intel/int/algs")]
            void EmitAlgs()
            {
                var asset = Assets.Algorithms();
                Utf8.decode(asset.ResBytes, out var doc);
                AppSvc.FileEmit(doc, AppDb.DbTargets("intrinsics").Path(algs,FileKind.Txt), TextEncodingKind.Utf8);
            }

            [CmdOp("intel/int/check")]
            Outcome RunChecks(CmdArgs args)
            {
                IntrinsicChecks.Run();
                return true;
            }
        }
    }
}