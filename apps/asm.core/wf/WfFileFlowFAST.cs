//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WfFileTypes;

    public abstract class WfFileFlow<F,A,S,T> : FileFlow<F,A,WfFileKind,S,T>, IWfFileFlow
        where F : WfFileFlow<F,A,S,T>,new()
        where A : IActor
        where S : IWfFileType
        where T : IWfFileType
    {
        protected WfFileFlow(A actor, S source, T target)
            : base(actor,source,target)
        {


        }

        public WfFileKind SourceKind
            => Source.Kind;

        public WfFileKind TargetKind
            => Source.Kind;

        public override string Format()
            => WfFileFlows.format(this);
    }
}