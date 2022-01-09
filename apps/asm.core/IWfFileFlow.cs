//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfFileFlow : IWfDataFlow<WfFileKind,WfFileKind>
    {
        WfFileKind SourceKind {get;}

        WfFileKind TargetKind {get;}

        FS.FileExt SourceExt
            => SourceKind.Ext();

        FS.FileExt TargetExt
            => TargetKind.Ext();

        WfFileKind IArrow<WfFileKind,WfFileKind>.Source
            => SourceKind;

        WfFileKind IArrow<WfFileKind,WfFileKind>.Target
            => TargetKind;

        string ITextual.Format()
            => WfFileFlows.format(this);
    }
}