//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileFLow : IDataFlow
    {
        FileKind SourceKind {get;}

        FileKind TargetKind {get;}

        FS.FileExt SourceExt
            => SourceKind.Ext();

        FS.FileExt TargetExt
            => TargetKind.Ext();

        // FileKind IArrow<FileKind,FileKind>.Source
        //     => SourceKind;

        // FileKind IArrow<FileKind,FileKind>.Target
        //     => TargetKind;

        string ITextual.Format()
            => FileFlows.format(this);
    }
}