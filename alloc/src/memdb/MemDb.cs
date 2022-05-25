//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class MemDb : IMemDb
    {
        const byte ObjTypeCount = 24;

        static Index<ObjectKind,uint> ObjSeqSource = sys.alloc<uint>(ObjTypeCount);

        [MethodImpl(Inline)]
        public static uint NextSeq(ObjectKind kind)
            => inc(ref ObjSeqSource[kind]);

        static readonly ConcurrentDictionary<FS.FilePath, MemDb> Opened = new();

        [MethodImpl(Inline)]
        static AllocToken token(MemoryAddress @base, uint offset, uint size)
            => new AllocToken(@base,offset, size);


        public static Index<MemoryFileInfo> Allocated()
            => Opened.Values.Map(x => x.Description);

        readonly MemoryFile DbMap;

        public readonly MemoryFileInfo Description;

        uint Offset;

        public ulong Capacity
        {
            [MethodImpl(Inline)]
            get => DbMap.Size;
        }

        public MemDb(FS.FilePath store)
        {
            var spec = MemoryFileSpec.init(store.CreateParentIfMissing());
            spec.EnableAccessReadWrite();
            spec.EnableModeOpenOrCreate();
            spec.Stream = true;
            DbMap = new MemoryFile(spec);
            Description = DbMap.Description;
        }

        public MemDb(FS.FilePath store, ByteSize size)
        {
            var spec = MemoryFileSpec.init(store.CreateParentIfMissing());
            spec.Capacity = size;
            spec.EnableAccessReadWrite();
            spec.EnableModeOpenOrCreate();
            spec.Stream = true;
            DbMap = new MemoryFile(spec);
            Description = DbMap.Description;
        }

        public AllocToken Store(ReadOnlySpan<byte> src)
        {
            var size = (uint)src.Length;
            var offset = Offset;
            var next = (uint)(Offset + src.Length);
            if(next > Capacity)
                return AllocToken.Empty;
            DbMap.Stream.Seek(Offset, System.IO.SeekOrigin.Begin);
            DbMap.Stream.Write(src);
            Offset = next;
            return token(DbMap.BaseAddress, offset, size);
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Load(AllocToken token)
            => DbMap.View(token.Offset, token.Size);

        [MethodImpl(Inline)]
        public Span<byte> Edit(AllocToken token)
            => DbMap.Edit(token.Offset, token.Size);

        MemoryFileInfo IMemDb.Description
            => Description;
    }
}