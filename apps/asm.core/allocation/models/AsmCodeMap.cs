//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmCodeMap : IDisposable
    {
        public static AsmCodeMap create(IWfRuntime wf)
            => new AsmCodeMap(wf);

        AllocationDispensers Dispensers;

        List<AsmCodeMapEntry> EntryBuffer;

        Index<AsmCodeMapEntry> EntryData;

        readonly IWfRuntime Wf;

        AsmCodeMap(IWfRuntime wf)
        {
            Dispensers = Alloc.dispensers();
            EntryBuffer = new();
            Wf = wf;
            EntryData = sys.empty<AsmCodeMapEntry>();
        }

        public void Dispose()
        {
            Dispensers.Dispose();
        }


        public void Seal()
        {
            EntryData = EntryBuffer.Array();
        }

        public ReadOnlySpan<AsmCodeMapEntry> Entries
        {
            [MethodImpl(Inline)]
            get => EntryData;
        }

        public void Include(ReadOnlySpan<ObjDumpRow> src)
        {
            var traverser = new Traverser(this);
            var blocks = Wf.AsmObjects().DistillBlocks(src, Dispensers.AsmCodes());
            traverser.Traverse(blocks.Values);
        }

        class Traverser : AsmCodeBlockTraverser
        {
            AsmCodeMap Map;

            Label BlockOrigin;

            MemoryAddress BaseAddress;

            uint BlockNumber;

            public Traverser(AsmCodeMap map)
            {
                Map = map;
            }

            void AddEntries(in AsmCodeBlock src)
            {
                var count = src.Count;
                ref readonly var address = ref src.Label.Location.Address;
                ref readonly var name = ref src.Label.Name;
                 for(var i=0; i<count; i++)
                 {
                     ref readonly var c = ref src[i];
                     if(BaseAddress == 0)
                        BaseAddress = c.Encoded.BaseAddress;

                     var entry = new AsmCodeMapEntry();
                     entry.Id = c.Id;
                     entry.MappedAddress = c.Encoded.BaseAddress;
                     entry.MappedRebase = c.Encoded.BaseAddress - BaseAddress;
                     entry.Origin = BlockOrigin;
                     entry.BlockNumber = BlockNumber;
                     entry.BlockName = name;
                     entry.BlockAddress = address;
                     entry.EntryAddress = c.IP;
                     entry.EncodingSize = c.EncodingSize;
                     entry.Encoded = c.Encoded;
                     entry.Asm = c.Asm;
                     entry.BlockSize = src.Size;
                     Map.EntryBuffer.Add(entry);
                 }
            }

            protected override void Traversing(in AsmCodeBlock src)
            {
                AddEntries(src);
                BlockNumber++;
            }

            protected override void Traversing(in AsmCodeBlocks src)
            {
                BlockOrigin = src.Origin;
            }
        }
    }
}