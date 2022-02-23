//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static core;

    public class ToolFlowIndex
    {
        public static ToolFlowIndex from(ReadOnlySpan<ToolCmdFlow> src)
            => new ToolFlowIndex(src);

        ConstLookup<FS.FileUri,List<FS.FileUri>> Lookup;

        Index<ToolDataFlow> Data;

        ToolFlowIndex(ReadOnlySpan<ToolCmdFlow> src)
        {
            var count = src.Length;
            var flows = alloc<ToolDataFlow>(count);
            var lookup = dict<FS.FileUri,List<FS.FileUri>>();
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(flows,i);
                dst = flow(skip(src,i));
                if(lookup.TryGetValue(dst.Source, out var targets))
                {
                    targets.Add(dst.Target);
                }
                else
                {
                    lookup[dst.Source] = new();
                    lookup[dst.Source].Add(dst.Target);
                }
            }

            Lookup = lookup;
            Data = flows;
        }

        [MethodImpl(Inline)]
        static ToolDataFlow flow(in ToolCmdFlow src)
        {
            var flow = DataFlows.flow(src.TargetName, src.SourcePath.ToUri(), src.TargetPath.ToUri());
            return new ToolDataFlow(DataFlows.identify(flow), flow);
        }

        public ReadOnlySpan<ToolDataFlow> Flows
        {
            [MethodImpl(Inline)]
            get => Data;
        }
    }
}