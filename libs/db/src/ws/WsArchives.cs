//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsArchives
    {
        readonly Index<WsArchive> Data;

        readonly ConstLookup<string, WsArchive> Lookup;

        internal WsArchives(WsArchive[] src)
        {
            Data = src;
            Lookup = src.Select(x => (x.Name,x)).ToDictionary();
        }

        public WsArchive Path(string name)
        {
            var dst = WsArchive.Empty;
            Lookup.Find(name, out dst);
            return dst;
        }

        public string Format()
        {
            var dst = text.emitter();
            Tables.emit(Data.View, dst);
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}