//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FileTypes;

    public abstract class FileFlowType<F,A,S,T> : FileFlowType<F,A,FileKind,S,T>, IFileFlowType
        where F : FileFlowType<F,A,S,T>,new()
        where A : IActor
        where S : IWfFileType
        where T : IWfFileType
    {
        protected FileFlowType(A actor, S source, T target)
            : base(actor,source,target)
        {


        }

        public FileKind SourceKind
            => Source.Kind;

        public FileKind TargetKind
            => Target.Kind;

        public override string Format()
            => FileFlowTypes.format(this);
    }
}