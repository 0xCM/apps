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

        public static DisasmDetailDoc doc(WsContext context, in FileRef fref)
        {
            var file = load(fref);
            return doc(context, file, summarize(context, file));
        }

        public static Index<DisasmDetailDoc> docs(WsContext context)
        {
            var files = context.Files(FileKind.XedRawDisasm);
            var dst = bag<DisasmDetailDoc>();
            iter(files, file => dst.Add(doc(context,file)), true);
            return dst.Array();
        }

        public static ref FieldBuffer load(in DetailBlock src, ref FieldBuffer dst)
        {
            dst.Clear();
            dst.Detail = src.Detail;
            dst.Lines = src.Block.Lines;
            dst.Summary = src.Block.Summary;
            DisasmParse.parse(dst.Lines, out dst.AsmInfo).Require();
            DisasmParse.parse(dst.Lines, out dst.Props);
            XedDisasm.fields(dst.Props, dst.Fields, false);
            dst.FieldSelection = dst.Fields.MemberKinds();
            XedState.Edit.fields(dst.Fields, dst.FieldSelection, ref dst.State);
            dst.Encoding = XedState.Code.encoding(dst.State, src.Block.Summary.Encoded);
            return ref dst;
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

        public static DisasmFile load(in FileRef src)
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
            return new DisasmFile(src,dst.ToArray());
        }
    }
}