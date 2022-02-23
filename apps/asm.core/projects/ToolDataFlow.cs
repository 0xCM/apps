//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolDataFlow
    {
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
        internal ToolDataFlow(FlowId id, DataFlow<Actor,FS.FileUri,FS.FileUri> spec)
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