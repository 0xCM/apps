//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class StorePaths
    {
        public static StorePaths load(Settings src)
        {
            var count = src.Count;
            var dst = alloc<StorePath>(count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var setting = ref src[i];
                seek(dst,i) = new StorePath(text.trim(setting.Name), FS.dir(setting.ValueText));
            }
            return new StorePaths(dst);
        }

        public StorePath Path(string name)
        {
            var dst = StorePath.Empty;
            Lookup.Find(name, out dst);
            return dst;
        }

        readonly Index<StorePath> Data;

        readonly ConstLookup<string, StorePath> Lookup;

        StorePaths(StorePath[] src)
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