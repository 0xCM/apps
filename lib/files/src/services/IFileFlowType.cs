//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileFlowType<K> : IFlowType
        where K : unmanaged
    {
        K SourceKind {get;}

        K TargetKind {get;}
    }

    public interface IFileFlowType : IFlowType
    {
        FileKind SourceKind {get;}

        FileKind TargetKind {get;}

        FS.FileExt SourceExt
            => SourceKind.Ext();

        FS.FileExt TargetExt
            => TargetKind.Ext();

        string ITextual.Format()
            => FileTypes.format(this);
    }
}