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
            var opcodes = Xed.Rules.ExtractOpCodes(patterns);
            TableEmit(opcodes.View, XedOpCode.RenderWidths, ProjectDb.TablePath<XedOpCode>("xed"));

            return result;
        }
    }
}