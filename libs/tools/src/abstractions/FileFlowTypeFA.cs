//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FileFlowType<F,A> : FileFlowType<F,A,FileKind>, IFileFlowType<F>
        where F : FileFlowType<F,A>,new()
        where A : IActor
    {
        protected FileFlowType(A actor, FileKind src, FileKind dst)
            : base(actor,src,dst)
        {

        }


        public FileKind SourceKind => Source;

        public FileKind TargetKind => Target;
    }
}