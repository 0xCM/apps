//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiPack : IApiPack
    {
        public FS.FolderPath Root {get;}

        public Timestamp Timestamp {get;}

        public ApiPack(FS.FolderPath root, Timestamp ts)
        {
            Root = root;
            Timestamp = ts;
        }

        public string Format()
            => string.Format("{0}: {1}", Timestamp, Root);

        public override string ToString()
            => Format();
    }
}