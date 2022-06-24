//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WsArchives
    {
        public static WsArchives load(Settings src)
            => new WsArchives(src);

        readonly Settings Data;

        internal WsArchives(Settings src)
        {
            Data = src;
        }

        public Setting Path(string name)
        {
            var dst = Setting.Empty;
            var result = Data.Lookup(name, out dst);
            if(result)
                return dst;
            else
                return Setting.Empty;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();
    }
}