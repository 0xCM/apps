//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ImportsWs : Workspace<ImportsWs>
    {
        [MethodImpl(Inline)]
        public static ImportsWs create(FS.FolderPath root)
            => new ImportsWs(root);

        [MethodImpl(Inline)]
        internal ImportsWs(FS.FolderPath root)
            : base(root)
        {

        }
    }
}