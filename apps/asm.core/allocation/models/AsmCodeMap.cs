//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

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

        public void Include(IProjectWs project, Index<ObjDumpRow> src)
        {
            var catalog = project.FileCatalog();
            var distilled = Wf.AsmObjects().DistillBlocks(project, src, Dispensers);
            for(var i=0; i<distilled.Count; i++)
            {
                ref readonly var blocks = ref distilled[i];
                if(blocks.Count == 0)
                    continue;

                ref readonly var origin = ref blocks.Origin;

                var blocknumber = 0u;
                var @base = MemoryAddress.Zero;

                for(var j=0; j<blocks.Count; j++)
                {
                    ref readonly var block = ref blocks[j];
                    var count = block.Count;
                    ref readonly var address = ref block.Label.Location.Address;
                    ref readonly var name = ref block.Label.Name;
                    for(var k=0; k<count; k++)
                    {
                        ref readonly var c = ref block[k];

                        if(j==0 && k==0)
                            @base = c.Encoded.BaseAddress;

                        var entry = new AsmCodeMapEntry();
                        entry.Id = c.Id;
                        entry.MappedAddress = c.Encoded.BaseAddress;
                        entry.MappedRebase = c.Encoded.BaseAddress - @base;
                        entry.Origin = origin;
                        entry.BlockNumber = blocknumber;
                        entry.BlockName = name;
                        entry.BlockAddress = address;
                        entry.EntryAddress = c.IP;
                        entry.EncodingSize = c.EncodingSize;
                        entry.Encoded = c.Encoded;
                        entry.Asm = c.Asm;
                        entry.BlockSize = block.Size;
                        EntryBuffer.Add(entry);
                    }

                    blocknumber++;
                }
            }
        }
    }
}