//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class WfDb : AppService<WfDb>, IWfDb
    {
        public FS.FolderPath Root {get; private set;}

        public WfDb()
        {

        }

        internal WfDb(IWfRuntime wf, FS.FolderPath root)
            : base(wf)
        {
            Root = root;
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