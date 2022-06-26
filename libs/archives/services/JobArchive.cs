//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct JobArchive : IDbArchive<JobArchive>
    {
        public FS.FolderPath Root {get;}

        public JobArchive(FS.FolderPath root)
        {
            Root = root;
        }
    }
}