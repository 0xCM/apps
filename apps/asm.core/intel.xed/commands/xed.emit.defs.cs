//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/defs")]
        Outcome EmitDefs(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            var defs = TableCalcs.defs(rules);
            var specs = rules.TableSpecs().Select(x => (x.Sig, x)).ToDictionary();
            var lookup = defs.SelectMany(x => x.Rows).SelectMany(x => x.Cells).Select(x => (x.Key, x)).ToDictionary();
            EmitCellDefs(lookup);
            return true;
        }

        void EmitCellDefs(RuleExprLookup defs)
        {
            var rules = Xed.Rules.CalcRules();
            var specs = rules.TableSpecs().Select(x => (x.TableId, x)).ToDictionary();

            const string Sep = " | ";
            var cols = new Pairings<string,byte>(new Paired<string,byte>[]{
                ("Field", 22), ("Type",22), ("Width",8), ("Op", 8),
                ("Value", 32), ("Source",32), ("Def",48), ("Key", 18),
                ("TableId", 12), ("TableKind", 12), ("TableName", 32), ("Row", 8),
                });

            var count = cols.Count;
            var widths = alloc<byte>(count);
            iteri(count, i=> seek(widths,i) = cols[i].Right);
            var slots = mapi(widths, (i,w) => RP.slot((byte)i, (short)-w));
            var names = alloc<string>(count);
            iteri(count, i => names[i] = cols[i].Left);
            var RenderPattern = slots.Intersperse(" | ").Concat();
            var header = string.Format(RenderPattern, names);
            var keys = defs.Keys;
            var dst = text.buffer();
            dst.AppendLine(header);
            for(var i=0; i<keys.Length; i++)
            {
                var def = defs[skip(keys,i)];

                dst.AppendLineFormat(RenderPattern,
                    XedRender.format(def.Field), def.Type, def.Type.EffectiveWidth, def.Operator,
                    def.Value, def.Source, def.Format(), def.Key,
                    def.Key.TableId.FormatHex(), def.Key.TableKind, specs[def.Key.TableId].TableName, def.Key.RowIndex
                    );
            }

            FileEmit(dst.Emit(), keys.Length, XedPaths.RuleTargets() + FS.file("xed.rules.expressions", FS.Csv), TextEncodingKind.Asci);
        }
    }

}