//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WsDb
    {
        readonly FS.FolderPath Root;

        [MethodImpl(Inline)]
        internal WsDb(FS.FolderPath root)
        {
            Root = root;
        }

        public FS.FolderPath Dir()
            => Root;

        public DbTargets Targets()
            => new DbTargets(Root);

        public string Format()
            => Dir().Format();

        public override string ToString()
            => Format();
    }
}