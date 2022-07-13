//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdDefs
    {
        [Cmd(CmdId)]
        public struct RepoCommit : IFlowCmd<RepoCommit>
        {
            const string CmdId = "repo/commit";

            public FS.FolderPath Source;

            public FS.FilePath Target;
        }
    }
}