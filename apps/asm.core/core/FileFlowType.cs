//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FileFlowType : IFileFlowType
    {
        internal static string format(IFileFlowType flow)
            => string.Format("{0}:*.{1} -> *.{2}", flow.Actor, flow.SourceExt, flow.TargetExt);

        public IActor Actor {get;}

        public FileKind SourceKind {get;}

        public FileKind TargetKind {get;}

        public FileFlowType(IActor actor, FileKind src, FileKind dst)
        {
            Actor = actor;
            SourceKind = src;
            TargetKind = dst;
        }

        public FileFlowType(Identifier actor, FileKind src, FileKind dst)
        {
            Actor = new Actor(actor);
            SourceKind = src;
            TargetKind = dst;
        }

        dynamic IArrow.Source
            => SourceKind;

        dynamic IArrow.Target
            => TargetKind;

        FS.FileExt SourceExt
            => SourceKind.Ext();

        FS.FileExt TargetExt
            => TargetKind.Ext();

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}