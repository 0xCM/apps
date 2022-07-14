//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdDefs
    {
        [Cmd(CmdId)]
        public struct RepoArchive : IFlowCmd<FS.FolderPath,FS.FilePath>
        {
            const string CmdId = "repo/archive";

            public Actor Actor;

            public FS.FolderPath Source;

            public FS.FilePath Target;

            FS.FolderPath IFlowCmd<FS.FolderPath, FS.FilePath>.Source
                => Source;

            FS.FilePath IFlowCmd<FS.FolderPath, FS.FilePath>.Target
                => Target;

            IActor IFlowCmd.Actor
                => Actor;
        }
    }
}