//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;
    using static NativeClass;

    using W = XedModels.OpWidthCode;
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

        [Op]
        public static NativeClass @class(OpWidthCode src)
        {
            var dst = NativeClass.None;
            switch(src)
            {
                case W.P:
                case W.P2:
                case W.MPREFETCH:
                case W.VAR:
                case W.PMMSZ16:
                case W.PMMSZ32:
                case W.VV:
                case W.ZV:
                    dst = 0;
                    break;
                case W.MSKW:
                case W.ZMSKW:
                case W.I1:
                    dst = B;
                    break;

                case W.BND32:
                case W.BND64:
                case W.WRD:
                case W.B:
                case W.U8:
                case W.U16:
                case W.U32:
                case W.U64:
                case W.X128:
                case W.XUB:
                case W.XUW:
                case W.XUD:
                case W.XUQ:
                case W.Y128:
                case W.YUB:
                case W.YUW:
                case W.YUD:
                case W.YUQ:
                case W.ZUB:
                case W.ZU8:
                case W.ZU16:
                case W.ZU32:
                case W.ZU64:

                case W.ZUD:
                case W.ZUW:
                case W.ZUQ:
                case W.ZU128:

                case W.MEM16:
                case W.MEM28:
                case W.MEM14:
                case W.MEM94:
                case W.MEM108:
                case W.M512:
                case W.M384:

                case W.TMEMCOL:
                case W.TMEMROW:
                case W.TV:
                case W.PTR:
                    dst = U;
                    break;

                case W.A16:
                case W.A32:
                case W.ASZ:
                case W.SSZ:

                case W.PI:

                case W.I2:
                case W.I3:
                case W.I4:
                case W.I5:
                case W.I6:
                case W.I7:

                case W.I8:
                case W.I16:
                case W.I32:
                case W.I64:

                case W.W:
                case W.D:
                case W.Q:

                case W.V:
                case W.Y:
                case W.Z:

                case W.DQ:
                case W.QQ:
                case W.MQ:

                case W.MB:
                case W.MW:
                case W.MD:

                case W.XB:
                case W.XW:
                case W.XD:
                case W.XQ:

                case W.YB:
                case W.YW:
                case W.YD:
                case W.YQ:

                case W.ZB:
                case W.ZW:
                case W.ZD:
                case W.ZQ:

                case W.ZI8:
                case W.ZI16:
                case W.ZI32:
                case W.ZI64:

                case W.SPW:
                case W.SPW2:
                case W.SPW3:
                case W.SPW5:
                case W.SPW8:

                case W.MEM16INT:
                case W.MEM32INT:
                case W.M64INT:

                    dst = I;
                    break;

                case W.F16:
                case W.F32:
                case W.F64:
                case W.F80:

                case W.SI:
                case W.SD:

                case W.YPS:
                case W.YPD:
                case W.ZBF16:

                case W.PS:
                case W.PD:
                case W.ZF32:
                case W.ZF64:
                case W.S:
                case W.S64:
                case W.SS:
                case W.MEM32REAL:
                case W.M64REAL:
                case W.MEM80REAL:
                    dst = F;
                    break;
            }

            return dst;
        }

        static XedLookups Instance = new();
    }
}