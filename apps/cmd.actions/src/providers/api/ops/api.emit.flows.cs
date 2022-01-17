//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

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
            var src = ApiRuntimeCatalog.DataFlows;
            var count = src.Length;
            var buffer = alloc<ApiFlowType>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var flow = ref skip(src,i);
                dst.Actor = flow.Actor.Name;
                dst.Source = flow.Source?.ToString() ?? EmptyString;
                dst.Target = flow.Target?.ToString() ?? EmptyString;
                dst.Description = flow.Format();
            }

            TableEmit(@readonly(buffer.Sort()), ApiFlowType.RenderWidths, ProjectDb.ApiTablePath<ApiFlowType>());
        }
    }
}