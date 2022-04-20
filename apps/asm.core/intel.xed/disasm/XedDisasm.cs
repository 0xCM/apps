//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedFields;

    public partial class XedDisasm : AppService<XedDisasm>
    {
        const string XDIS = "XDIS ";

        public static InstOpClass opclass(MachineMode mode, DisasmOpInfo src)
        {
            var info = XedWidths.describe(src.WidthCode);
            var bitwidth = XedWidths.width(mode, src.WidthCode).Bits;
            var dst =  new InstOpClass {
                        Kind = src.Kind,
                        DataWidth = bitwidth,
                        ElementType = info.ElementType,
                        IsRegLit = IsRegLit(src.OpType),
                        IsLookup = IsLookup(src.OpType),
                        CellCount = info.CellCount,
                        WidthCode = src.WidthCode,
                    };

            return dst;
        }

        static Index<InstOpClass> resequence(Index<InstOpClass> src)
        {
            src.Sort();
            for(var i=0u; i<src.Length; i++)
                src[i].Seq = i;
            return src;
        }

        public static Index<InstOpClass> opclasses(Index<Document> src)
        {
            var buffer = hashset<InstOpClass>();
            foreach(var (summary,detail) in src)
                buffer.AddRange(detail.Blocks.Select(x => x.DetailRow).SelectMany(x => x.Ops).Select(x => XedDisasm.opclass(ModeKind.Mode64, x.OpInfo)).Distinct());
            var dst = buffer.Array();
            return resequence(dst);
        }

        public static Index<InstOpClass> opclasses(Document src)
            => resequence(
                src.Detail.Blocks.Select(x => x.DetailRow)
                   .SelectMany(x => x.Ops)
                   .Select(x => opclass(ModeKind.Mode64, x.OpInfo))
                   .Distinct());

        public static ref FieldBuffer load(in DetailBlock src, ref FieldBuffer dst)
        {
            dst.Clear();
            dst.Detail = src.DetailRow;
            dst.Lines = src.SummaryLines.Lines;
            dst.Summary = src.SummaryLines.Summary;
            DisasmParse.parse(dst.Lines, out dst.AsmInfo).Require();
            DisasmParse.parse(dst.Lines, out dst.Props);
            XedDisasm.fields(dst.Props, dst.Fields, false);
            dst.FieldSelection = dst.Fields.MemberKinds();
            XedState.Edit.fields(dst.Fields, dst.FieldSelection, ref dst.State);
            dst.Encoding = XedState.Code.encoding(dst.State, src.SummaryLines.Summary.Encoded);
            return ref dst;
        }

        public static ConstLookup<FileRef,Detail> details(WsContext context, bool pll = true)
        {
            var files = context.Files(FileKind.XedRawDisasm);
            var dst = cdict<FileRef,Detail>();
            iter(files, file => dst.TryAdd(file, details(context,file)), pll);
            return dst;
        }

        public static Index<Document> docs(WsContext context)
        {
            var summaries = CalcSummaryDocs(context);
            var details = XedDisasm.details(summaries);
            return details.Entries.Map(x => new Document(x.Key,x.Value)).ToArray();
        }

        public static Index<DetailBlock> blocks(WsContext context, in FileRef src)
            => blocks(summary(context,src));

        public static Index<DetailBlock> blocks(Summary src, bool pll = true)
        {
            var dst = bag<DetailBlock>();
            var summaries = src.Lines;
            iter(summaries, summary => dst.Add(new DetailBlock(row(summary), summary)), pll);
            return resequence(dst.Array());
        }

        public static Index<FileRef> sources(WsContext context)
            => context.Files(FileKind.XedRawDisasm);

        public static Index<DisasmSummaryRow> resequence(Index<DisasmSummaryRow> src)
        {
            var dst = src.Sort();
            var count = dst.Count;
            for(var i=0u; i<count; i++)
                dst[i].Seq = i;
            return dst;
        }

        public static Index<DetailBlock> resequence(Index<DetailBlock> src)
        {
            var dst = src.Sort();
            for(var i=0u; i<dst.Count; i++)
            {
                var row = dst[i].DetailRow;
                row.Seq = i;
                dst[i] = new DetailBlock(row, dst[i].SummaryLines);
            }
            return dst;
        }

        public static Detail details(WsContext context, in FileRef fref)
        {
            var file = load(context, fref);
            return doc(context, file, summary(context, file));
        }

        public static Summary summary(WsContext context, in FileRef src)
        {
            var buffer = bag<DisasmSummaryLines>();
            var file = load(context, src);
            summarize(src, file.Origin, file.Lines, buffer).Require();
            return Summary.create(file, buffer.ToArray());
        }

        public static uint fields(DisasmProps props, Fields dst, bool clear = true)
        {
            if(clear)
                dst.Clear();

            var counter = 0u;
            var count = props.Count;
            var keys = props.Keys.Array();
            for(var i=0; i<count; i++)
            {
                var name = skip(keys,i);
                var value = props[name];
                if(name == nameof(InstForm))
                    continue;

                if(XedParsers.parse(name, out FieldKind kind))
                {
                    if(TableCalcs.parse(value, kind, out var pack))
                    {
                        dst.Update(pack);
                        counter++;
                    }
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldPack), value));
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind),name));
            }
            return counter;
        }

        public static DataFile load(WsContext context, in FileRef src)
        {
            var dst = list<DisasmLineBlock>();
            var lines = src.Path.ReadNumberedLines();
            var count = lines.Length;
            var blocklines = list<TextLine>();
            var imax = count-1;
            for(var i=0; i<imax; i++)
            {
                blocklines.Clear();
                ref readonly var l0 = ref lines[i];
                ref readonly var l1 = ref lines[i+1];
                if(l0.IsNonEmpty && l1.IsNonEmpty)
                {
                    ref readonly var c0 = ref l0.Content;
                    ref readonly var c1 = ref l1.Content;
                    if(c1[0] == '0')
                    {
                        blocklines.Add(l0);
                        blocklines.Add(l1);
                        i++;
                        while(i++ < imax)
                        {
                            ref readonly var l = ref lines[i];
                            blocklines.Add(l);
                            if(l.StartsWith(XDIS))
                                break;
                        }
                        dst.Add(blocklines.ToArray());
                    }
                }
            }
            return new DataFile(context.Root(src), src,dst.ToArray());
        }
    }
}