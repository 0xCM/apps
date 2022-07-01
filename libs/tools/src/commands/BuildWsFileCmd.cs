//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an asm build command in the context of a workspace
    /// </summary>
    [Cmd(Name)]
    public record struct WsBuildCmd : IWsCmd<WsBuildCmd>
    {
        const string Name = "build-{0}";

        public WsId WsId;

        public Sector Sources;

        public asci32 SrcId;

        public FileKind SrcKind;

        public Sector Targets;

        public asci32 DstId;

        public FileKind DstKind;

        public FS.FileName SrcFile
            => FS.file(SrcId,SrcKind);

        public FS.FileName DstFile
            => FS.file(DstId,DstKind);
    }
}