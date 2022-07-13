//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdDefs
    {
        [Cmd(CmdId)]
        public struct RepoArchive : IFlowCmd<RepoArchive>
        {
            const string CmdId = "repo/archive";

            public FS.FolderPath Source;

            public FS.FilePath Target;
        }
    }
}