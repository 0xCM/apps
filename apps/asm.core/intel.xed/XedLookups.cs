//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    using EK = XedModels.ElementKind;
    using WC = XedModels.OpWidthCode;

    public class XedLookups
    {
        public static XedLookups Service => Instance;

        public readonly FieldLookup Fields;

        public readonly Index<OpWidthInfo> WidthRecords;

        public readonly ConstLookup<OpWidthCode,OpWidthInfo> WidthLookup;

        readonly Index<FieldKind,RuleFieldSpec> FieldSpecs;


        XedLookups()
        {
            Fields = FieldLookup.create();
            WidthRecords = LoadOpWidths();
            WidthLookup = CalcOpWidthLookup(WidthRecords);
            FieldSpecs = XedFields.Specs;
        }

        XedPaths XedPaths => XedPaths.Service;

        [MethodImpl(Inline)]
        public ref readonly RuleFieldSpec FieldSpec(FieldKind kind)
            => ref FieldSpecs[kind];

        public OpWidthInfo WidthInfo(OpWidthCode code)
            => code == 0 ? OpWidthInfo.Empty : WidthLookup[code];

        public OpWidth Width(OpWidthCode code, MachineMode mode)
        {
            var dst = OpWidth.Empty;
            if(code == 0)
                return dst;
            else if(WidthLookup.Find(code, out var info))
            {
                switch(mode.Kind)
                {
                    case ModeKind.Mode16:
                        dst = new OpWidth(code, info.Width16);
                    break;
                    case ModeKind.Not64:
                    case ModeKind.Mode32:
                        dst = new OpWidth(code, info.Width32);
                    break;

                    default:
                        dst = new OpWidth(code, info.Width64);
                    break;
                }
            }
            else
                Errors.Throw(code.ToString());
            return dst;
        }

        ConstLookup<OpWidthCode,OpWidthInfo> CalcOpWidthLookup(Index<OpWidthInfo> src)
            => src.Select(x => (x.Code,x)).ToDictionary();

        static Outcome ParseWidthValue(string src, out ushort bits)
        {
            var result = Outcome.Success;
            bits = 0;
            var i = text.index(src, "bits");
            if(i > 0)
                result = DataParser.parse(text.left(src,i), out bits);
            else
            {
                result = DataParser.parse(src, out ushort bytes);
                if(result)
                    bits = (ushort)(bytes*8);
            }
            return result;
        }

        Index<OpWidthInfo> LoadOpWidths()
        {
            var buffer = dict<OpWidthCode,OpWidthInfo>();
            var symbols = Symbols.index<OpWidthCode>();
            var src = XedPaths.DocSource(XedDocKind.Widths);
            using var reader = src.Utf8LineReader();
            var result = Outcome.Success;
            while(reader.Next(out var line))
            {
                var content = text.trim(line.Content);
                if(text.empty(content) || content.StartsWith(Chars.Hash))
                    continue;

                var i = text.index(content, Chars.Hash);
                if(i>0)
                    content = text.left(content,i);

                var cells = text.split(text.despace(content), Chars.Space);
                if(cells.Length < 3)
                {
                    result = (false, content);
                    break;
                }

                ref readonly var code = ref skip(cells,0);
                ref readonly var xtype = ref skip(cells,1);
                ref readonly var wdefault = ref skip(cells,2);

                var dst = OpWidthInfo.Empty;
                result = XedParsers.parse(code, out dst.Code);

                if(result.Fail)
                {
                    result = (false, Msg.ParseFailure.Format(nameof(dst.Code), code));
                    break;
                }

                if(dst.Code == 0)
                    continue;

                symbols.MapKind(dst.Code, out var sym);
                dst.Name = sym.Expr.Format();
                result = XedParsers.parse(xtype, out dst.CellType);
                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.CellType), xtype));
                    break;
                }

                dst.CellWidth = bitwidth(dst.Code, dst.CellType);

                result = ParseWidthValue(wdefault, out dst.Width16);
                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.Width16), wdefault));
                    break;
                }
                else
                {
                    dst.Width32 = dst.Width16;
                    dst.Width64 = dst.Width16;
                }

                if(cells.Length >= 4)
                    result = ParseWidthValue(skip(cells,3), out dst.Width32);

                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.Width32), skip(cells,3)));
                    break;
                }

                if(cells.Length >= 5)
                    result = ParseWidthValue(skip(cells,4), out dst.Width64);

                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.Width64), skip(cells,4)));
                    break;
                }

                dst.Seg = BitSegType.define(@class(dst.Code), dst.Width64, dst.CellWidth);
                buffer.TryAdd(dst.Code, dst);

            }

            if(result.Fail)
                Errors.Throw(result.Message);

            return buffer.Values.Array().Sort();
        }

        static ushort bitwidth(OpWidthCode code)
        {
            var result = z16;
            switch(code)
            {
                case WC.B:
                    result = 8;
                break;

                case WC.D:
                    result = 32;
                break;

                case WC.MSKW:
                case WC.ZMSKW:
                case WC.I1:
                    result = 1;
                break;
                case WC.I2:
                    result = 2;
                break;
                case WC.I3:
                    result = 3;
                break;
                case WC.I4:
                    result = 4;
                break;
                case WC.I5:
                    result = 5;
                break;
                case WC.I6:
                    result = 6;
                break;
                case WC.I7:
                    result = 7;
                break;
                case WC.I8:
                    result = 8;
                break;

                case WC.MEM16:
                case WC.MEM16INT:
                    result = 16;
                    break;

                case WC.MEM28:
                    result = 224;
                    break;

                case WC.MEM14:
                    result=112;
                break;

                case WC.MEM94:
                    result=94;
                break;

                case WC.MEM108:
                    result=108;
                break;

                case WC.M512:
                    result = 512;
                    break;

                case WC.M384:
                    result = 384;
                    break;

                case WC.MFPXENV:
                    result = 4096;
                break;

                case WC.MXSAVE:
                    result = 4608;
                break;
            }

            return result;
        }

        static ushort bitwidth(OpWidthCode code, ElementKind ekind)
        {
            var result = bitwidth(code);
            if(result != 0)
                return result;

            switch(ekind)
            {
                case EK.U8:
                case EK.I8:
                    result = 8;
                    break;

                case EK.U16:
                case EK.I16:
                case EK.F16:
                case EK.BF16:
                    result = 16;
                    break;

                case EK.U32:
                case EK.I32:
                case EK.F32:
                case EK.INT:
                case EK.UINT:
                    result = 32;
                    break;

                case EK.U64:
                case EK.I64:
                case EK.F64:
                    result = 64;
                    break;

                case EK.B80:
                case EK.F80:
                    result = 80;
                    break;

                case EK.U128:
                    result = 128;
                    break;

                case EK.U256:
                    result = 256;
                    break;
                default:
                break;
            }

            return result;
        }
        static XedLookups Instance = new();
    }
}