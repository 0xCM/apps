//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileFlowType : IFlowType
    {
        FileKind SourceKind {get;}

        FileKind TargetKind {get;}

        FS.FileExt SourceExt
            => SourceKind.Ext();

        FS.FileExt TargetExt
            => TargetKind.Ext();

        string ITextual.Format()
            => string.Format("{0}:*.{1} -> *.{2}", Actor, SourceExt, TargetExt);
    }

    public interface IFileFlowType<F> : IFileFlowType
        where F : IFileFlowType<F>
    {

    }
}