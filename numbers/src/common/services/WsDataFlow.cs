//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WsDataFlow
    {
        [MethodImpl(Inline)]
        public static WsDataFlow from(in ToolCmdFlow src)
        {
            var flow = DataFlows.flow(src.TargetName, src.SourcePath.ToUri(), src.TargetPath.ToUri());
            return new WsDataFlow(DataFlows.identify(flow), flow);
        }

        public readonly FlowId Id;

        readonly DataFlow<Actor,FS.FileUri,FS.FileUri> Spec;

        public ToolId Tool
        {
            [MethodImpl(Inline)]
            get => new ToolId(Spec.Actor.Name);
        }

        public FS.FileUri Source
        {
            [MethodImpl(Inline)]
            get => Spec.Source;
        }

        public FS.FileUri Target
        {
            [MethodImpl(Inline)]
            get => Spec.Target;
        }

        [MethodImpl(Inline)]
        WsDataFlow(FlowId id, DataFlow<Actor,FS.FileUri,FS.FileUri> spec)
        {
            Id = id;
            Spec = spec;
        }

        public string Format()
            => Spec.Format();

        public override string ToString()
            => Format();
    }
}