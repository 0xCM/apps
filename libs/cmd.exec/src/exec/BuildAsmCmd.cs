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
    public record struct BuildWsFileCmd : IWsCmd<BuildWsFileCmd>
    {
        const string Name = "build-{0}";

        public WsId WsId;

        public asci16 WsSrc;

        public asci32 SrcId;

        public FileKind SrcKind;

        public FileKind DstKind;

        public FS.FileName SrcFile
            => FS.file(SrcId,SrcKind);
    }
}