//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class MemDb : IMemDb
    {
        static readonly ConcurrentDictionary<FS.FilePath, MemDb> Opened = new();

        [MethodImpl(Inline)]
        static AllocToken token(MemoryAddress @base, uint offset, uint size)
            => new AllocToken(@base,offset, size);

        public static IMemDb open(FS.FilePath store)
            => open(store,0);

        public static IMemDb open(FS.FilePath store, ByteSize capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity));

        public static IMemDb open(FS.FilePath store, Gb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        public static IMemDb open(FS.FilePath store, Mb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        public static Index<MemoryFileInfo> Allocated()
            => Opened.Values.Map(x => x.Description);

        readonly MemoryFile Map;

        public readonly MemoryFileInfo Description;

        uint Offset;

        public ulong Capacity
        {
            [MethodImpl(Inline)]
            get => Map.Size;
        }

        public MemDb(FS.FilePath store)
        {
            var spec = MemoryFileSpec.init(store.CreateParentIfMissing());
            spec.EnableAccessReadWrite();
            spec.EnableModeOpenOrCreate();
            spec.Stream = true;
            Map = new MemoryFile(spec);
            Description = Map.Description;
        }

        public MemDb(FS.FilePath store, ByteSize size)
        {
            var spec = MemoryFileSpec.init(store.CreateParentIfMissing());
            spec.Capacity = size;
            spec.EnableAccessReadWrite();
            spec.EnableModeOpenOrCreate();
            spec.Stream = true;
            Map = new MemoryFile(spec);
            Description = Map.Description;
        }

        public AllocToken Store(ReadOnlySpan<byte> src)
        {
            var size = (uint)src.Length;
            var offset = Offset;
            var next = (uint)(Offset + src.Length);
            if(next > Capacity)
                return AllocToken.Empty;
            Map.Stream.Seek(Offset, System.IO.SeekOrigin.Begin);
            Map.Stream.Write(src);
            Offset = next;
            return token(Map.BaseAddress, offset, size);
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Load(AllocToken token)
            => Map.View(token.Offset, token.Size);

        [MethodImpl(Inline)]
        public Span<byte> Edit(AllocToken token)
            => Map.Edit(token.Offset, token.Size);

        MemoryFileInfo IMemDb.Description
            => Description;
    }
}