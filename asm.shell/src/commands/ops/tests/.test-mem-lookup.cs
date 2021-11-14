//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".test-mem-lookup")]
        public Outcome CheckMemoryLookup(CmdArgs args)
        {
            var capacity = Pow2.T16;
            var blocks = Wf.ApiHex().ReadBlocks().View;
            var count = blocks.Length;

            if(count > capacity)
                return (false, "Insufficient cpacity");

            var distinct = blocks.Map(b => b.BaseAddress).ToArray().ToHashSet();
            if(distinct.Count != count)
                Warn(string.Format("There should be {0} distinct base addresses and yet there are {1}", count, distinct.Count));

            var symbols = MemorySymbols.alloc(capacity);
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                symbols.Deposit(block.BaseAddress, block.Size, block.OpUri.Format());
            }

            Status("Creating lookup");

            var lookup = symbols.ToLookup();
            var entries = slice(lookup.Symbols, 0,symbols.EntryCount);
            var dst = Db.AppLog("addresses.lookup", FS.Csv);
            var emitting = Wf.EmittingTable<MemorySymbol>(dst);
            var emitted = Z0.Tables.emit(entries, dst);
            Wf.EmittedTable(emitting,emitted);
            var found = 0;

            var hashes = entries.Map(x => x.HashCode).ToArray().ToHashSet();
            if(hashes.Count != count)
                Warn(string.Format("There should be {0} distinct hash codes and yet there are {1}", count, hashes.Count));

            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                if(lookup.FindIndex(block.BaseAddress, out var index))
                    found++;
            }

            Wf.Status(string.Format("Blocks: {0}", count));
            Wf.Status(string.Format("Found: {0}", found));
            return true;
        }
    }
}