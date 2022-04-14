//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static Datasets;
    using static core;

    partial class XedCmdProvider
    {
        [MethodImpl(Inline)]
        public static bits<T> load<T>(T src)
            where T : unmanaged
                => src;

        [MethodImpl(Inline)]
        public static bits<T> load<T>(byte n, T src)
            where T : unmanaged
                => (n,src);

        [CmdOp("xed/check/seq")]
        Outcome ChecSeq(CmdArgs args)
        {
            var defs = XedSeq.Defs();
            for(var i=0; i<defs.Count; i++)
            {
                ref readonly var def = ref defs[i];
                Write(def.Format());
            }
            return true;
        }

        [CmdOp("xed/emit/types")]
        Outcome EmitCellTypes(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            var distinct = hashset<CellTypeKind>();
            ref readonly var src = ref rules.Criteria();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var table = ref src[i];
                for(var j=0; j<table.RowCount; j++)
                {
                    ref readonly var row = ref table[j];
                    // ref readonly var left = ref row.Antecedant;
                    // ref readonly var right = ref row.Consequent;

                    // for(var k=0; k<left.Count; k++)
                    // {
                    //     ref readonly var t = ref left[k].Type;
                    //     distinct.Add(t);
                    // }

                    // for(var k=0; k<right.Count; k++)
                    // {
                    //     ref readonly var t = ref right[k].Type;
                    //     distinct.Add(t);
                    // }

                    var cells = row.Joined();
                    for(var k=0; k< cells.Count; k++)
                    {
                        ref readonly var t = ref cells[k].Type;
                        if(t.IsNonEmpty)
                            distinct.Add(t.Kind);
                    }
                }
            }

            var types = distinct.Array().Sort();
            iter(types, t => Write(t.Format()));

            return true;
        }
        [CmdOp("xed/machine")]
        Outcome RunMachine(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var groups = Xed.Rules.CalcInstGroups(patterns);
            var group = groups.Where(g => g.Class == IClass.AND);
            var machine = Wf.XedMachine();
            foreach(var g in group)
            {
                ref readonly var members = ref g.Members;
                for(var i=0; i<g.MemberCount; i++)
                {
                    ref readonly var member = ref g[i];
                    ref readonly var pattern = ref member.Pattern;
                    machine.Inst() = pattern;
                    ref readonly var mod = ref member.Mod;
                    ref readonly var rexw = ref member.RexW;
                    ref readonly var @lock = ref member.Lock;

                    Write(string.Format("{0,-8} | {1,-18} | {2,-8} | {3,-8} | {4,-26}",
                        machine.Mode(),
                        machine.InstClass.Classifier,
                        member.Indicator,
                        member.Index,
                        machine.OpCode.Format()
                        ));

                    for(byte j=0; j<machine.OpCount; j++)
                    {
                        ref readonly var op = ref machine.Op(j);
                        Write(op.Format());
                        if(op.IsNonterm)
                        {
                            ref readonly var nonterm = ref op.NonTerm;
                            var table = machine.NontermOpTable(j);
                            Write(table.Format());
                        }
                    }
                }
            }

            return true;
        }

        [CmdOp("xed/check/bits")]
        Outcome CheckBits(CmdArgs args)
        {
            Span<char> buffer = stackalloc char[84];
            ulong input = 0xF0CCAADD33;
            uint n = 24;
            ulong match = 0b1010_1010_1101_1101_0011_0011;
            var output = BitRender.render4x4(Chars.Underscore, n,input,buffer);
            Write(string.Format("{0} | {1}",  "1010_1010_1101_1101_0011_0011", text.format(output)));

            return true;
        }

        static byte _format(InstPattern pattern, Span<string> dst)
        {
            ref readonly var ops = ref pattern.Ops;

            var j=z8;
            seek(dst,j++) = string.Format("{0,-20} | {1,-4} | {2}", pattern.InstClass.Name, pattern.Mode, pattern.BodyExpr);
            seek(dst,j++) = string.Format("{0,-20} | {1}", pattern.OpCode, pattern.InstForm);

            for(var i=0; i<ops.Count; i++)
            {
                ref readonly var op = ref ops[i];
                seek(dst,j++) = string.Format("{0,20} | {1}", string.Format("{0} {1}", op.Index, op.Name), XedRender.format(op.Attribs));
            }
            return j;
        }

        void CheckPatterns(N0 n)
        {
            var forms = Symbols.index<IFormType>().Kinds.Map(x => (x,x)).ToConcurrentDictionary();
            var blocks = cdict<uint,string[]>();
            var patterns = cdict<uint,InstPattern>();
            var traversals = XedPatterns.traversals()
                                        .WithPreHandler(PatternTraversal);

            XedPatterns.traverser(traversals).TraversePatterns(Xed.Rules.CalcInstPatterns());

            void PatternTraversal(InstPattern pattern)
            {
                Require.invariant(patterns.TryAdd(pattern.PatternId,pattern));
                ref readonly var ops = ref pattern.Ops;
                var dst = alloc<string>(2 + ops.Count);
                _format(pattern, dst);
                blocks.TryAdd(pattern.PatternId, dst);
                if(pattern.InstForm.IsNonEmpty)
                    forms.TryRemove(pattern.InstForm);
            }

            var path = AppDb.Api() + FS.file("xed.inst.patterns.opinfo", FS.Csv);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            var counter = 0u;

            var sorted = patterns.Values.Array().Sort();
            var opcode = XedOpCode.Empty;
            for(var i=0; i<sorted.Length; i++)
            {
                ref readonly var pattern = ref skip(sorted,i);
                if(pattern.OpCode != opcode)
                {
                    writer.WriteLine(RP.PageBreak120);
                    opcode = pattern.OpCode;
                }

                var lines = blocks[pattern.PatternId];
                for(var j=0; j<lines.Length; j++, counter++)
                    writer.WriteLine(skip(lines,j));
            }
            EmittedFile(emitting,counter);
            iter(forms.Values, f => Write(f.ToString()));

        }
    }
}