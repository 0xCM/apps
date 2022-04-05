//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        public class RuleTables
        {
            internal class Buffers
            {
                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTable>> Defs = new();

                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTableSpec>> Specs = new();

                public Index<RuleSchema> Schema = sys.empty<RuleSchema>();

                public Index<RuleSigRow> Sigs = sys.empty<RuleSigRow>();

                public static Buffers Empty => new();
            }

            Index<RuleTable> TableDefIndex;

            SortedLookup<RuleSig,RuleTable> TableDefLookup;

            Dictionary<RuleSig,FS.FilePath> TablePaths;

            Index<TableDefRow> DefRowIndex;

            Index<RuleTableSpec> _EncTableSpecs;

            Index<RuleTableSpec> _DecTableSpecs;

            Index<RuleTableSpec> _TableSpecs;

            public ref readonly Index<RuleSchema> Schema
            {
                [MethodImpl(Inline)]
                get => ref Data.Schema;
            }

            public ref readonly Index<RuleSigRow> SigInfo
            {
                [MethodImpl(Inline)]
                get => ref Data.Sigs;
            }

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTableSpec> EncTableSpecs()
                => ref _EncTableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTableSpec> DecTableSpecs()
                => ref _DecTableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTableSpec> TableSpecs(RuleTableKind kind)
            {
                if(kind == RuleTableKind.Enc)
                    return ref EncTableSpecs();
                else
                    return ref DecTableSpecs();
            }

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTableSpec> TableSpecs()
                => ref _TableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<TableDefRow> DefRows()
                => ref DefRowIndex;

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTable> Tables()
                => ref TableDefIndex;

            [MethodImpl(Inline)]
            public RuleTable Table(in RuleSig sig)
            {
                if(TableDefLookup.Find(sig, out var def))
                    return def;
                else
                    return RuleTable.Empty;
            }

            [MethodImpl(Inline)]
            public ReadOnlySpan<RuleSig> Sigs()
                => TableDefLookup.Keys;

            public FS.FileUri FindTablePath(Nonterminal src)
            {
                var name = src.Name;
                var path = FS.FilePath.Empty;
                if(!TablePaths.TryGetValue(new (RuleTableKind.Dec,name), out path))
                    TablePaths.TryGetValue(new (RuleTableKind.Enc,name), out path);
                return path;
            }

            Buffers Data = Buffers.Empty;

            public RuleTables()
            {

            }

            internal RuleTables Seal(Buffers src, bool pll)
            {
                Data = src;
                SealTableSpecs();
                exec(pll, SealTableDefs, SealPaths);
                return this;
            }

            internal Buffers CreateBuffers()
                => new();

            void SealPaths()
            {
                var paths = dict<RuleSig,FS.FilePath>();
                foreach(var spec in EncTableSpecs())
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));
                foreach(var spec in DecTableSpecs())
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));
                TablePaths = paths;
            }

            void SealTableSpecs()
            {
                var enc = Data.Specs[RuleTableKind.Enc];
                var dec = Data.Specs[RuleTableKind.Dec];
                var specs = enc.Append(dec).Sort();
                for(var i=0u; i<specs.Count; i++)
                    specs[i] = specs[i].WithId(i);

                var j=0u;
                var k=0u;
                for(var i=0u; i<specs.Count; i++)
                {
                    ref readonly var spec = ref specs[i];
                    if(spec.IsEncTable)
                        enc[j++] = spec;
                    else
                        dec[k++] = spec;
                }

                _EncTableSpecs = enc;
                _DecTableSpecs = dec;
                _TableSpecs = specs;
            }

            void SealTableDefs()
            {
                DefRowIndex = RuleTableCalcs.CalcDefRows(TableSpecs());

                var tables = Data.Defs.Values.SelectMany(x => x).Array();
                var count = tables.Length;
                var defs = dict<RuleSig,RuleTable>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var table = ref tables[i];
                    if(defs.TryGetValue(table.Sig, out var t))
                        defs[table.Sig] = t.WithBody(table.Body);
                    else
                        defs.Add(table.Sig, table);
                }

                TableDefLookup = defs;
                TableDefIndex = defs.Values.Array().Sort();
                //DefRowIndex = CalcDefRows(TableDefIndex);
            }

            // static Index<TableDefRow> CalcDefRows(Index<RuleTable> src)
            // {
            //     var count = src.Storage.Map(x => x.EntryCount).Sum();
            //     var dst = alloc<TableDefRow>(count);
            //     var k = 0u;

            //     for(var i=0u; i<src.Count; i++)
            //     {
            //         ref readonly var table = ref src[i];
            //         var cells = grid(table);
            //         for(var j=0u; j<cells.Length; j++,k++)
            //         {
            //             ref var row = ref seek(dst,k);
            //             row.Seq = k;
            //             row.TableId = i;
            //             row.Index = j;
            //             row.Statement = cells[j];
            //             row.Kind = table.TableKind;
            //             row.Name = table.Sig.ShortName;
            //         }
            //     }
            //     return dst;
            // }

            // static Index<RuleGridCells> grid(in RuleTable table)
            // {
            //     var rows = XedRules.cells(table);
            //     var cols = rows.Storage.Select(x => x.Count).Max();
            //     var grid = alloc<RuleGridCells>(rows.Count);
            //     for(var j=0; j<rows.Count; j++)
            //     {
            //         var premise = true;
            //         var dst = RuleGridCells.Empty;
            //         var i = z8;
            //         for(var k=0; k<rows[j].Count; k++)
            //         {
            //             var cell = rows[j][k];
            //             if(!cell.IsPremise)
            //             {
            //                 if(premise)
            //                 {
            //                     premise  = false;
            //                     dst[i] = new(premise, i, table.TableKind, OperatorKind.Impl);
            //                     i++;
            //                 }
            //             }

            //             cell.Index = i;
            //             dst[i] = cell;
            //             i++;
            //             dst.Count = i;
            //         }
            //         seek(grid,j) = dst;
            //     }
            //     return grid;
            // }

            public static RuleTables Empty => new();
        }
    }
}