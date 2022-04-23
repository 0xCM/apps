//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedParsers;
    using static XedModels;

    using CK = XedRules.RuleCellKind;
    using K = XedRules.FieldKind;
    using R = XedRules;

    partial class XedRules
    {
        public readonly partial struct CellParser
        {
            public static CellType celltype(string data)
            {
                Require.invariant(data.Length < 48);
                var kind = XedFields.kind(data);
                var field = kind != 0 ? XedFields.field(kind) : ReflectedField.Empty;
                CellParser.parse(data, out RuleOperator op);
                var wData = (byte)field.FieldSize.DataWidth;
                var wDom = (byte)field.FieldSize.DomainWidth;
                var tDom = field.DomainType;
                var tData = field.DataType;
                var @class = CellParser.@class(field.Field, data);
                if(@class.Kind == CK.Keyword)
                {
                    wDom = (byte)typeof(KeywordKind).Tag<DataWidthAttribute>().Require().ContentWidth;
                    wData = (byte)core.width<KeywordKind>();
                    tDom = new FieldTypeName(kind, nameof(CK.Keyword));
                    tData =new FieldTypeName(kind, nameof(CK.Keyword));
                }
                else if(@class.Kind == CK.BitLiteral)
                {
                    wDom = 8;
                    wData = 8;
                    tDom = new FieldTypeName(kind, nameof(uint8b));
                    tData =new FieldTypeName(kind, "byte");
                }
                else if(@class.Kind == CK.HexLiteral)
                {
                    wDom = 8;
                    wData = 8;
                    tDom = new FieldTypeName(kind, nameof(Hex8));
                    tData =new FieldTypeName(kind, "byte");
                }
                return new (field.Field, @class, op, tData, tDom, wData, wDom);
            }

            public static Outcome parse(string src, out InstField dst)
            {
                dst = InstField.Empty;
                Outcome result = (false, string.Format("Unrecognized segment '{0}'", src));
                if(IsHexLiteral(src))
                {
                    result = XedParsers.parse(src, out Hex8 x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(Hex8), src));
                }
                else if(IsBinaryLiteral(src))
                {
                    result = XedParsers.parse(src, out uint5 x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(uint5), src));

                }
                else if(IsSeg(src))
                {
                    result = parse(src, out SegField x);
                    if(result)
                        dst = x;
                }
                else if (IsExpr(src))
                {
                    result = expr(src, out CellExpr x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(CellExpr), src));
                }
                else if(IsNontermCall(src))
                {
                    result = XedParsers.parse(src, out RuleName x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(RuleName), src));
                }
                else if (XedParsers.parse(src, out byte a))
                {
                    result = true;
                    dst = a;
                }

                return result;
            }

            public static bool parse(FieldKind field, string value, out CellValue dst)
            {
                var result = true;
                dst = R.CellValue.Empty;
                if(XedParsers.IsNontermCall(value) && XedParsers.parse(value, out RuleName k))
                {
                    dst = new (field, k);
                    return true;
                }

                switch(field)
                {
                    case K.AGEN:
                    case K.AMD3DNOW:
                    case K.ASZ:
                    case K.CET:
                    case K.CLDEMOTE:
                    case K.DF32:
                    case K.DF64:
                    case K.DUMMY:
                    case K.ENCODER_PREFERRED:
                    case K.ENCODE_FORCE:
                    case K.HAS_MODRM:
                    case K.HAS_SIB:
                    case K.ILD_F2:
                    case K.ILD_F3:
                    case K.IMM0:
                    case K.IMM0SIGNED:
                    case K.IMM1:
                    case K.LOCK:
                    case K.LZCNT:
                    case K.MEM0:
                    case K.MEM1:
                    case K.MODE_FIRST_PREFIX:
                    case K.MODE_SHORT_UD0:
                    case K.MODEP5:
                    case K.MODEP55C:
                    case K.MPXMODE:
                    case K.MUST_USE_EVEX:
                    case K.NEEDREX:
                    case K.NEED_SIB:
                    case K.NOREX:
                    case K.NO_RETURN:
                    case K.NO_SCALE_DISP8:
                    case K.REX:
                    case K.OSZ:
                    case K.OUT_OF_BYTES:
                    case K.P4:
                    case K.PREFIX66:
                    case K.PTR:
                    case K.REALMODE:
                    case K.RELBR:
                    case K.TZCNT:
                    case K.UBIT:
                    case K.USING_DEFAULT_SEGMENT0:
                    case K.USING_DEFAULT_SEGMENT1:
                    case K.VEX_C4:
                    case K.VEXDEST3:
                    case K.VEXDEST4:
                    case K.WBNOINVD:
                    case K.REXRR:
                    case K.SAE:
                    case K.BCRC:
                    case K.ZEROING:
                    {
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = new(field, b);
                            result = true;
                        }
                    }
                    break;

                    case K.REXW:
                    {
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = new (field, b);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'w')
                        {
                            dst = new (seg(field, 'w'));

                            result = true;
                        }
                    }
                    break;
                    case K.REXR:
                    {
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = new (field,b);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'r')
                        {
                            dst = new (seg(field, 'r'));
                            result = true;
                        }
                    }
                    break;
                    case K.REXX:
                    {
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = new (field,b);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'x')
                        {
                            dst = new (seg(field, 'x'));
                            result = true;
                        }
                    }
                    break;
                    case K.REXB:
                    {
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = new (field, b);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'b')
                        {
                            dst = new (seg(field, 'b'));
                            result = true;
                        }
                    }
                    break;

                    case K.ELEMENT_SIZE:
                    case K.MEM_WIDTH:
                    {
                        if(ushort.TryParse(value, out ushort b))
                        {
                            dst = new (field,b);
                            result = true;
                        }
                    }
                    break;

                    case K.SIBBASE:
                    case K.HINT:
                    case K.ROUNDC:
                    case K.SEG_OVD:
                    case K.VEXVALID:
                    case K.MOD:
                    case K.SIBSCALE:
                    case K.EASZ:
                    case K.EOSZ:
                    case K.FIRST_F2F3:
                    case K.LAST_F2F3:
                    case K.DEFAULT_SEG:
                    case K.MODE:
                    case K.REP:
                    case K.SMODE:
                    case K.VEX_PREFIX:
                    case K.VL:
                    case K.LLRC:
                    case K.MAP:
                    case K.NELEM:
                    case K.SCALE:
                    case K.BRDISP_WIDTH:
                    case K.DISP_WIDTH:
                    case K.ILD_SEG:
                    case K.IMM1_BYTES:
                    case K.IMM_WIDTH:
                    case K.MAX_BYTES:
                    case K.MODRM_BYTE:
                    case K.NPREFIXES:
                    case K.NREXES:
                    case K.NSEG_PREFIXES:
                    case K.POS_DISP:
                    case K.POS_IMM:
                    case K.POS_IMM1:
                    case K.POS_MODRM:
                    case K.POS_NOMINAL_OPCODE:
                    case K.POS_SIB:
                    case K.NEED_MEMDISP:
                    case K.RM:
                    case K.SIBINDEX:
                    case K.REG:
                    case K.VEXDEST210:
                    case K.MASK:
                    case K.SRM:
                    {
                        if(XedParsers.parse(value, out byte b))
                        {
                            dst = new (field,b);
                            result = true;
                        }
                    }
                    break;

                    case K.ESRC:
                    {
                        if(DataParser.parse(value, out Hex4 x))
                        {
                            dst = new (field,(byte)x);
                            result = true;
                        }
                    }
                    break;


                    case K.NOMINAL_OPCODE:
                    {
                        if(DataParser.parse(value, out Hex8 x))
                        {
                            dst = new (field, x);
                            result = true;
                        }
                    }
                    break;

                    case K.DISP:
                    case K.UIMM0:
                    case K.UIMM1:
                    {
                        result = byte.TryParse(value, out var b);
                        if(result)
                            dst = new (field,b);
                        else
                        {
                            if(IsSeg(value))
                            {
                                if(SegData(value, out var sd))
                                {
                                    var type = SegTypes.type(sd);
                                    if(type.IsNonEmpty)
                                        dst = new (field,type);
                                    else
                                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(CellValue), value));
                                }
                            }
                        }
                    }
                    break;

                    case K.BASE0:
                    case K.BASE1:
                    case K.INDEX:
                    case K.OUTREG:
                    case K.SEG0:
                    case K.SEG1:
                    case K.REG0:
                    case K.REG1:
                    case K.REG2:
                    case K.REG3:
                    case K.REG4:
                    case K.REG5:
                    case K.REG6:
                    case K.REG7:
                    case K.REG8:
                    case K.REG9:
                    {
                        if(XedParsers.reg(field, value, out dst))
                            result = true;
                    }
                    break;
                    case K.CHIP:
                    {
                        if(XedParsers.parse(value, out ChipCode x))
                        {
                            dst = new (field, (ushort)x);
                            result = true;
                        }
                    }
                    break;

                    case K.ERROR:
                    {
                        if(XedParsers.parse(value, out ErrorKind x))
                        {
                            dst = new (field, (ushort)x);
                            result = true;
                        }
                    }
                    break;

                    case K.ICLASS:
                    {
                        if(XedParsers.parse(value, out IClass x))
                        {
                            dst = new (field, (ushort)x);
                            result = true;
                        }
                    }
                    break;

                    case K.BCAST:
                    {
                        if(XedParsers.parse(value, out BCastKind kind))
                        {
                            dst = new (field, (byte)kind);
                            result = true;
                        }
                    }
                    break;
                }

                return result;
            }


            public static bool SegData(string src, out string dst)
            {
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                var result = i>0 && j>i;
                if(result)
                    dst = text.inside(src,i,j);
                else
                    dst = EmptyString;
                return result;
            }

            public static void parse(string src, out InstPatternBody dst)
            {
                var result = Outcome.Success;
                var parts = text.trim(text.split(text.despace(src), Chars.Space));
                var count = parts.Length;
                dst = alloc<InstField>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(parts,i);
                    result = parse(part, out dst[i]);
                    if(result.Fail)
                    {
                        Errors.Throw(result.Message);
                    }
                }
            }

            public static Outcome parse(string src, out SegField dst)
            {
                var result = Outcome.Success;
                dst = SegField.Empty;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                result = i>0 && j>i;
                if(result)
                {
                    result = XedParsers.parse(text.left(src,i), out FieldKind field);
                    if(!result)
                        return false;

                    result = CellParser.SegData(src, out var sd);
                    if(!result)
                        return result;

                    var literal = XedParsers.IsBinaryLiteral(sd);
                    if(!literal)
                    {
                        var vt = SegTypes.type(sd);
                        if(vt.IsNonEmpty)
                        {
                            dst = seg(field, vt);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        result = XedParsers.parse(sd, out uint5 value);
                        if(!result)
                            return result;

                        var len = sd.Length - 2;
                        switch(len)
                        {
                            case 1:
                                dst = seg(field, (uint1)value);
                            break;
                            case 2:
                                dst = seg(field, (uint2)value);
                            break;
                            case 3:
                                dst = seg(field, (uint3)(byte)value);
                            break;
                            case 4:
                                dst = seg(field, (uint4)(byte)value);
                            break;
                            default:
                                result = false;
                            break;
                        }
                    }
                }

                return result;
            }

            public static CellClass @class(FieldKind field, string data)
            {
                var result = false;
                var input = normalize(data);
                var dst = CellClass.Empty;
                var isNonTerm = text.contains(input, "()");

                if(IsExpr(input))
                {
                    result = parse(input, out RuleOperator op);
                    if(!result)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleOperator), input));

                    switch(op.Kind)
                    {
                        case OperatorKind.Eq:
                            if(isNonTerm)
                                dst = CK.NontermExpr;
                            else
                                dst = CK.EqExpr;
                        break;
                        case OperatorKind.Neq:
                            dst = CK.NeqExpr;
                        break;
                        case OperatorKind.And:
                        case OperatorKind.Impl:
                            dst = CK.Operator;
                        break;
                    }
                }
                else
                {
                    if(isNonTerm)
                        dst = CK.NontermCall;
                    else if(XedParsers.IsIntLiteral(data))
                        dst = CK.IntLiteral;
                    else if(XedParsers.IsHexLiteral(data))
                        dst = CK.HexLiteral;
                    else if(XedParsers.IsBinaryLiteral(data))
                        dst = CK.BitLiteral;
                    else if(IsImpl(input))
                        dst = CK.Operator;
                    else if(IsSeg(input))
                    {
                        if(field != 0)
                            dst = CK.SegField;
                        else
                            Errors.Throw(AppMsg.ParseFailure.Format(nameof(CellClass), input));
                    }
                    else if(XedParsers.parse(input, out RuleKeyword keyword))
                        dst = CK.Keyword;
                    else
                        dst = CK.SegVar;
                }

                Require.invariant(dst.IsNonEmpty);
                return dst;
            }

            public static bool parse(string src, out OperatorKind dst)
            {
                if(IsNeq(src))
                {
                    dst = OperatorKind.Neq;
                    return true;
                }
                else if(IsEq(src))
                {
                    dst = OperatorKind.Eq;
                    return true;
                }
                else if(IsImpl(src))
                {
                    dst = OperatorKind.Impl;
                    return true;
                }
                else
                {
                    dst = 0;
                    return false;
                }
            }

            public static bool parse(string src, out RuleOperator dst)
            {
                if(parse(src, out OperatorKind k))
                {
                    dst = k;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            public static bool parse(string src, out RowCriteria dst)
            {
                var input = normalize(src);
                var i = text.index(input,"=>");
                dst = RowCriteria.Empty;
                if(i > 0)
                {
                    var left = text.trim(text.left(input, i));
                    var premise = text.nonempty(left) ? cells(left) : Index<CellInfo>.Empty;
                    var right = text.trim(text.right(input, i+1));
                    var consequent = text.nonempty(right) ? cells(right) : Index<CellInfo>.Empty;
                    if(premise.Count != 0 || consequent.Count != 0)
                        dst = new RowCriteria(premise, consequent);
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(RowCriteria), src));

                return dst.IsNonEmpty;
            }

            static Index<CellInfo> cells(string src)
            {
                var input = text.trim(text.despace(src));
                var cells = list<string>();
                if(text.contains(input, Chars.Space))
                {
                    var parts = text.split(input, Chars.Space);
                    var count = parts.Length;
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var part = ref skip(parts,j);
                        if(RuleMacros.match(part, out var match))
                        {
                            var expanded = text.trim(match.Expansion);
                            if(text.contains(expanded, Chars.Space))
                            {
                                var expansions = text.split(expanded, Chars.Space);
                                for(var k=0; k<expansions.Length; k++)
                                    cells.Add(skip(expansions,k));
                            }
                            else
                                cells.Add(expanded);
                        }
                        else
                            cells.Add(part);
                    }
                }
                else
                {
                    if(RuleMacros.match(input, out var match))
                        cells.Add(match.Expansion);
                    else
                        cells.Add(input);
                }

                return cells.Map(x => cellinfo(celltype(x), LogicKind.None, x));
            }

            static string normalize(string src)
            {
                var dst = EmptyString;
                var i = text.index(src, Chars.Hash);
                if(i>0)
                    dst = text.despace(text.trim(text.left(src, i)));
                else
                    dst = text.despace(text.trim(src));

                return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
            }
        }
    }
}