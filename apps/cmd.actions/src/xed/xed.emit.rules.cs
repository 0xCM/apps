//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XTend
    {
        public static SymCounts<K> Counts<K>(this Symbols<K> src)
            where K : unmanaged
                => new SymCounts<K>(src);
    }

    public struct SymCounts<K>
        where K : unmanaged
    {
        readonly Symbols<K> Syms;

        readonly Index<int> Counts;

        public SymCounts(Symbols<K> symbols)
        {
            Syms = symbols;
            Counts = alloc<int>(Syms.Count);
        }

        uint Seq(K kind)
        {
            Syms.MapKind(kind, out var sym);
            return sym.Key.Value;
        }

        [MethodImpl(Inline)]
        public void Inc(K kind)
            => ++Counts[Seq(kind)];

        [MethodImpl(Inline)]
        public void Dec(K kind)
            => --Counts[Seq(kind)];

        [MethodImpl(Inline)]
        public ref readonly int Count(K kind)
            => ref Counts[Seq(kind)];

        [MethodImpl(Inline)]
        public uint Total()
            => (uint)Counts.Storage.Sum();

        public string Format()
        {
            var dst = text.buffer();
            var count = Syms.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var kind = ref skip(Syms.Kinds,i);
                Syms.MapKind(kind, out var sym);
                dst.AppendLineFormat("{0,-16} | {1}", sym.Expr, Count(kind));
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();

    }

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/rules")]
        Outcome EmitXedRules(CmdArgs args)
        {
            Xed.Rules.EmitCatalog();
            return true;
        }

        [CmdOp("check/xed/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var result = Outcome.Success;
            result = Xed.Rules.LoadRulePatterns(out var patterns);
            if(result.Fail)
                return result;

            var reader = patterns.Reader();
            var maps = Symbols.index<OpCodeKind>();
            var counts = maps.Counts();
            while(reader.Next(out var pattern))
                counts.Inc(pattern.OpCodeKind);

            var total = counts.Total();
            Require.equal(total, patterns.Count);

            Write(counts.Format());


            CheckRuleDefs();

            var opcodes = Xed.Rules.ExtractOpCodes(patterns);

            return result;
        }

        void CheckRuleDefs()
        {
            var defs = Xed.Rules.ParseEncInstDefs();
            var dst = ProjectDb.Subdir("xed") + FS.file("xed.rules.encoding.operands", FS.Csv);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var count = defs.Count;
            var buffer = text.buffer();
            var counter = 0u;
            var ockinds = Symbols.index<OpCodeKind>();
            for(var i=0; i<count; i++)
            {
                ref readonly var def = ref defs[i];

                var ops = def.PatternOps;
                var patterns = Xed.Rules.ExtractRulePatterns(def);
                var k = ops.Count;
                Require.equal(patterns.Count, k);
                for(var j=0; j<k; j++)
                {
                    ref readonly var op = ref ops[j];
                    ref readonly var pattern = ref patterns[j];
                    var opcode = Xed.Rules.OpCode(pattern);

                    ockinds.MapKind(opcode.Kind, out var sym);

                    writer.WriteLine(string.Format("{0,-6} | {1,-16} | {2,-12} | {3,-12} | {4,-8} | {5}", i, def.Class, sym.Expr, opcode.Value, EmptyString, op.Expr));
                    counter++;

                    var specs = op.Specs;
                    var m = specs.Count;
                    for(var q=0; q<m; q++)
                    {
                        ref readonly var spec = ref specs[q];
                        writer.WriteLine(string.Format("{0,-6} | {1,-16} | {2,-12} | {3,-12} | {4,-8} | {5}", i, def.Class, q, spec.Name, spec.Kind, spec.Expression));
                        counter++;
                    }
                }
            }

            EmittedFile(emitting,counter);

        }
    }
}