//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/flows")]
        Outcome RevealDataFlows(CmdArgs args)
        {
            EmitApiDataFlows();
            return true;
        }

        void EmitApiDataFlows()
        {
            var dst = ProjectDb.Api() + FS.file("api.dataflows", FS.Txt);
            var emitting = EmittingFile(dst);
            var src = ApiRuntimeCatalog.DataFlows;
            using var writer = dst.AsciWriter();
            iter(src, flow => writer.WriteLine(flow.Format()));
            EmittedFile(emitting, src.Length);
        }
    }
}