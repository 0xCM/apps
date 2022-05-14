//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class MemDb : IMemDb
    {
        static readonly ConcurrentDictionary<FS.FilePath, MemDb> Opened = new();

        public static IMemDb open(FS.FilePath store)
            => open(store,0);

        public static IMemDb open(FS.FilePath store, ByteSize capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity));

        public static IMemDb open(FS.FilePath store, Gb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        public static IMemDb open(FS.FilePath store, Mb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        public static Index<MemoryFileInfo> OpenStores()
            => Opened.Values.Map(x => x.Description);

        readonly MemoryFile DataMap;

        public readonly MemoryFileInfo Description;

        public MemDb(FS.FilePath store)
        {
            var spec = MemoryFileSpec.init(store.CreateParentIfMissing());
            spec.EnableAccessReadWrite();
            spec.EnableModeOpenOrCreate();
            DataMap = new MemoryFile(spec);
            Description = DataMap.Description;
        }

        public MemDb(FS.FilePath store, ByteSize size)
        {
            var spec = MemoryFileSpec.init(store.CreateParentIfMissing());
            spec.Capacity = size;
            spec.EnableAccessReadWrite();
            spec.EnableModeOpenOrCreate();
            DataMap = new MemoryFile(spec);
            Description = DataMap.Description;
        }

        MemoryFileInfo IMemDb.Description
            => Description;

        public void Dispose()
        {

        }
    }
}