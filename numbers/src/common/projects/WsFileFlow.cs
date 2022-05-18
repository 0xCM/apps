//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WsFileFlow
    {
        public readonly ProjectId Project;

        public readonly Actor Command;

        public readonly FS.FileUri Source;

        public readonly FileKind SourceKind;

        public readonly FS.FileUri Target;

        public readonly FileKind TargetKind;

        [MethodImpl(Inline)]
        public WsFileFlow(ProjectId project, FileFlowType type, FS.FileUri src, FS.FileUri dst)
        {
            Project = project;
            Command = type.Actor;
            Source = src;
            SourceKind = type.SourceKind;
            Target = dst;
            TargetKind = type.TargetKind;
        }

        [MethodImpl(Inline)]
        public DataFlow<Actor,FS.FileUri,FS.FileUri> Generalize()
            => new DataFlow<Actor,FS.FileUri,FS.FileUri>(Command,Source,Target);


        [MethodImpl(Inline)]
        public static implicit operator DataFlow<Actor,FS.FileUri,FS.FileUri>(WsFileFlow src)
            => src.Generalize();
    }
}