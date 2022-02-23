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
        [CmdOp("api/emit/flowspecs")]
        Outcome EmitDataFlowSpecs(CmdArgs args)
        {
            EmitDataFlowSpecs();
            return true;
        }

        void EmitDataFlowSpecs()
        {
            var src = ApiDataFlow.discover(ApiRuntimeCatalog.Components);
            var count = src.Length;
            var buffer = alloc<ApiFlowSpec>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var flow = ref src[i];
                dst.Actor = flow.Actor.Name;
                dst.Source = flow.Source?.ToString() ?? EmptyString;
                dst.Target = flow.Target?.ToString() ?? EmptyString;
                dst.Description = flow.Format();
            }

            TableEmit(@readonly(buffer.Sort()), ApiFlowSpec.RenderWidths, ProjectDb.ApiTablePath<ApiFlowSpec>());
        }
    }
}