//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class SvcDb : Service<SvcDb>, IWfDb
    {
        public FS.FolderPath Root {get; private set;}

        public SvcDb()
        {
            Root = FS.FolderPath .Empty;
        }

        protected override void Initialized()
        {
            Root = Env.Db;
        }

        public IWfDb Relocate(FS.FolderPath root)
        {
            Root = root;
            return this;
        }
    }
}