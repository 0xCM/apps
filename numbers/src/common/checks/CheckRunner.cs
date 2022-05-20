//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class CheckRunner : CheckRunner<CheckRunner>
    {
        public static void run(string name, Action<ITextEmitter> f, bool show = true)
        {
            var log = text.emitter();
            run(name, f, log, show);
        }

        public static void run(bool pll, params (string name, Action<ITextEmitter> f)[] checks)
        {
            core.iter(checks, x => run(x.name, x.f), pll);
        }

        static void run(string name, Action<ITextEmitter> f, ITextEmitter log, bool show)
        {
            Run();

            void Run()
            {
                try
                {
                    f(log);
                    if(show)
                        ShowCheckResult(name, log.Emit(false));
                }
                catch(Exception e)
                {
                    if(show)
                        ShowCheckResult(name, log.Emit(false), e);
                }
            }
        }

        static void ShowCheckResult(string name, string data, Exception e = null)
        {
            term.print(
                (Eol, FlairKind.Data),
                (name, FlairKind.StatusData),
                (RP.PageBreak120, FlairKind.StatusData),
                (Eol, FlairKind.Data),
                (data + (e == null ? EmptyString :  Eol + e.ToString()), e == null ? FlairKind.Data : FlairKind.Error)
                );
        }


        [CmdOp("check/mem/lookup")]
        public Outcome CheckMemoryLookup(CmdArgs args)
        {
            var capacity = Pow2.T16;
            var blocks = Wf.ApiHex().ReadBlocks().View;
            var count = blocks.Length;

            if(count > capacity)
                return (false, "Insufficient cpacity");

            var distinct = blocks.Map(b => b.BaseAddress).ToHashSet();
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

            var hashes = entries.Map(x => x.HashCode).ToHashSet();
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