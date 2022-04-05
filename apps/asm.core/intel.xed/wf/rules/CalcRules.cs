//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public RuleTables CalcRules()
        {
            var tables = new RuleTables();
            var buffers = tables.CreateBuffers();
            exec(PllExec,
                () => buffers.Defs.TryAdd(RuleTableKind.Enc, CalcTableDefs(RuleTableKind.Enc)),
                () => buffers.Defs.TryAdd(RuleTableKind.Dec, CalcTableDefs(RuleTableKind.Dec)),
                () => buffers.Specs.TryAdd(RuleTableKind.Enc, CalcTableSpecs(RuleTableKind.Enc)),
                () => buffers.Specs.TryAdd(RuleTableKind.Dec, CalcTableSpecs(RuleTableKind.Dec))
                );

            exec(PllExec,
                () => buffers.Sigs = CalcSigRows(buffers.Defs),
                () => buffers.Schema = CalcRuleSchemas(buffers.Defs)
                );

            return tables.Seal(buffers, PllExec);
        }

        public static Index<RuleSigRow> CalcSigRows(ConcurrentDictionary<RuleTableKind,Index<RuleTable>> src)
        {
            var sigs = src.Values.Array().SelectMany(x => x).Select(x => x.Sig).Distinct().Sort();
            var dst = alloc<RuleSigRow>(sigs.Length);
            for(var i=0u; i<sigs.Length; i++)
            {
                ref var row = ref seek(dst,i);
                ref readonly var sig = ref skip(sigs,i);
                row.Seq = i;
                row.TableKind = sig.TableKind;
                row.TableName = sig.ShortName;
                row.TableDef = XedPaths.Service.TableDef(sig);
            }
            return dst;
        }

        public static Index<RuleSeq> CalcRuleSeq()
            => XedParsers.ruleseq(XedPaths.Service.DocSource(XedDocKind.RuleSeq));

        public static Index<RuleTable> CalcTableDefs(RuleTableKind kind)
            => XedRules.reify(XedRules.CalcTableSpecs(XedPaths.Service.RuleSource(kind)));

        public static Index<RuleSchema> CalcRuleSchemas(ConcurrentDictionary<RuleTableKind,Index<RuleTable>> src)
        {
            var dst = bag<RuleSchema>();
            iter(src[RuleTableKind.Enc], table => CalcRuleSchema(table,dst), AppData.PllExec());
            iter(src[RuleTableKind.Dec], table => CalcRuleSchema(table,dst), AppData.PllExec());

            var schema = dst.Array().Sort();
            for(var i=0u; i<schema.Length; i++)
                seek(schema,i).Seq = i;
            return schema;
        }

        static void CalcRuleSchema(in RuleTable src, ConcurrentBag<RuleSchema> buffer)
        {
            ref readonly var sig = ref src.Sig;
            var path = XedPaths.Service.TableDef(sig);
            var cellix = XedRules.cells(src);
            for(var i=0; i<cellix.Count; i++)
            {
                ref readonly var cells = ref cellix[i];
                for(var j=0; j<cells.Count; j++)
                {
                    var cell = cells[j];
                    var dst = new RuleSchema();
                    dst.TableKind = src.TableKind;
                    dst.TableName = src.Sig.ShortName;
                    dst.Logic = cell.IsPremise ? 'P' : 'C';
                    dst.Index = cell.Index;
                    dst.Field = cell.Criterion.Field;
                    dst.DataKind = cell.Criterion.DataKind;
                    dst.TableDef = path;
                    buffer.Add(dst);
                }
            }
        }

        public static Index<RuleTableSpec> CalcTableSpecs(RuleTableKind kind)
            => CalcTableSpecs(XedPaths.Service.RuleSource(kind));

        static Index<RuleTableSpec> merge(Index<RuleTableSpec> src)
        {
            var dst = dict<RuleSig,RuleTableSpec>(src.Count);
            for(var i=0u; i<src.Count; i++)
            {
                ref readonly var table = ref src[i];
                ref readonly var sig = ref table.Sig;
                if(sig.IsEmpty)
                    continue;

                if(dst.TryGetValue(sig, out var t))
                    dst[sig] = t.Merge(table);
                else
                {
                    if(!dst.TryAdd(sig,table))
                        Errors.Throw(string.Format("Duplicate sig {0}", sig));
                }

            }

            return dst.Values.Array().Sort();
        }

        public static Index<RuleTableSpec> CalcTableSpecs(FS.FilePath src)
        {
            var skip = hashset("XED_RESET");
            using var reader = src.Utf8LineReader();
            var counter = 0u;
            var dst = list<RuleTableSpec>();
            var tkind = XedPaths.tablekind(src.FileName);
            var statements =list<StatementSpec>();
            var name = EmptyString;
            while(reader.Next(out var line))
            {
                if(XedParsers.RuleForm(line.Content) == RuleFormKind.SeqDecl)
                {
                    while(reader.Next(out line))
                        if(line.IsEmpty)
                            break;
                    continue;
                }

                var content = text.trim(text.despace(line.Content));
                if(text.empty(content) || text.begins(content, Chars.Hash))
                    continue;

                var k = text.index(content,Chars.Hash);
                if(k > 0)
                    content = text.trim(text.left(content,k));

                if(text.ends(content, "()::"))
                {
                    if(counter != 0)
                    {
                        if(!skip.Contains(name))
                            dst.Add(new (new (tkind, name), statements.ToArray()));

                        statements.Clear();
                    }

                    name = text.remove(content,"()::");
                    var i = text.index(name, Chars.Space);
                    if(i > 0)
                        name = text.right(name,i);
                    counter++;
                }
                else
                {
                    if(RuleParser.parse(content, out StatementSpec s))
                        statements.Add(s);
                }
            }

            return merge(dst.ToArray());
        }
    }
}