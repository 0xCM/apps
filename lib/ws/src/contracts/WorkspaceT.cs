//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Workspace<T> : IWorkspace<T>
        where T : Workspace<T>
    {
        public FS.FolderPath Root {get;}

        protected Workspace(FS.FolderPath root)
        {
            Root = root;
        }

        public string Format()
            => string.Format("{0}:{1}", typeof(T).Name, Root.Format());

        public override string ToString()
            => Format();
    }
}