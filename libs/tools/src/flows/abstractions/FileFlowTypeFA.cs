//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using FK = FileKind;

    public abstract class FileFlowType<F,A> : FileFlowType<F,A,FileKind>, IFileFlowType<F>
        where F : FileFlowType<F,A>,new()
        where A : IActor
    {
        protected FileFlowType(A actor, FileKind src, FileKind dst)
            : base(actor,src,dst)
        {

        }

        public FS.FileExt SourceExt => Source.Ext();

        public FS.FileExt TargetExt => Target.Ext();

        public FK SourceKind => Source;

        public FK TargetKind => Target;
    }
}