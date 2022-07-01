//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an asm build command in the context of a workspace
    /// </summary>
    [Cmd(Name), StructLayout(LayoutKind.Sequential,Pack=32)]
    public record struct WsBuildCmd : IWsCmd<WsBuildCmd>
    {
        const string Name = "build-{0}";

        public WsId WsId;

        public Name Sources;

        public Name SrcId;

        public FileKind SrcKind;

        public Name Targets;

        public Name DstId;

        public FileKind DstKind;

        public Name Script;

        public FS.FileName SrcFile
            => FS.file(SrcId,SrcKind);

        public FS.FileName DstFile
            => FS.file(DstId,DstKind);

        public static WsBuildCmd Empty => default;
    }
}