//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsArchives
    {
        public static WsArchives load(Settings src)
        {
            var count = src.Count;
            var dst = alloc<WsArchive>(count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var setting = ref src[i];
                seek(dst,i) = new WsArchive(text.trim(setting.Name), FS.dir(setting.ValueText));
            }
            return new WsArchives(dst);
        }

        public WsArchive Path(string name)
        {
            var dst = WsArchive.Empty;
            Lookup.Find(name, out dst);
            return dst;
        }

        readonly Index<WsArchive> Data;

        readonly ConstLookup<string, WsArchive> Lookup;

        WsArchives(WsArchive[] src)
        {
            Data = src;
            Lookup = src.Select(x => (x.Name,x)).ToDictionary();
        }

        public ReadOnlySpan<string> StoreNames
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
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