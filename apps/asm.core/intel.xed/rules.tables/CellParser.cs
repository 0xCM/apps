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
    using static XedPatterns;

    using CK = XedRules.RuleCellKind;
    using K = XedRules.FieldKind;
    using R = XedRules;

    partial class XedRules
    {
        public readonly struct CellParser
        {
            public static bool parse(FieldKind field, string value, out CellValue dst)
            {
                var result = true;
                dst = R.CellValue.Empty;
                if(XedParsers.IsNontermCall(value) && XedParsers.parse(value, out Nonterminal k))
                {
                    dst = new (field, k, field != 0? CellRole.FieldValue: CellRole.NontermCall);
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
                            dst = new (new BfSeg(field, BfSegKind.REXW));
                            //dst = new (seg(field, 'w'));
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
                            dst = new (new BfSeg(field, BfSegKind.REXR));
                            //dst = new (seg(field, 'r'),CellRole.FieldValue);
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
                            dst = new (new BfSeg(field, BfSegKind.REXX));
                            //dst = new (seg(field, 'x'));
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
                            dst = new (new BfSeg(field, BfSegKind.REXB));
                            //dst = new (seg(field, 'b'));
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
                            dst = new (field,x);
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
                    {
                        result = byte.TryParse(value, out byte b);
                        if(result)
                            dst = new (field, b);
                        else
                        {
                            result = XedParsers.parse(value, out DispSeg disp);
                            if(result)
                                dst = new (field, disp);
                        }
                    }
                    break;

                    case K.UIMM0:
                    {
                        result = byte.TryParse(value, out var b);
                        if(result)
                            dst = new (field,b);
                        else
                        {
                            result = XedParsers.parse(value, out ImmSeg imm);
                            dst = new (field,imm.WithIndex(0));
                        }
                    }
                    break;
                    case K.UIMM1:
                    {
                        result = byte.TryParse(value, out var b);
                        if(result)
                            dst = new (field,b);
                        else
                        {
                            result = XedParsers.parse(value, out ImmSeg imm);
                            dst = new (field,imm.WithIndex(1));
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

            public static bool IsEq(string src)
                => !src.Contains("!=") && src.Contains("=");

            public static bool IsNeq(string src)
                => src.Contains("!=");

            public static bool IsImpl(string src)
                => src.Contains("=>");

            public static bool IsBfSeg(string src)
            {
                if(!IsDispSeg(src) && !IsImmSeg(src))
                {
                    var i = text.index(src, Chars.LBracket);
                    var j = text.index(src, Chars.RBracket);
                    return i > 0 && j > i;
                }
                else
                    return false;
            }

            public static bool IsExpr(string src)
                => IsEq(src) || IsNeq(src);

            public static bool IsNontermExpr(string src)
                => IsExpr(src) && IsNontermCall(src);

            public static bool IsDispSpec(string src)
                => XedParsers.parse(src, out DispSpec _);

            public static bool IsDispSeg(string src)
            {
                var result = false;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                if(i >0 && j>0)
                    result = IsDispSpec(text.inside(src,i,j));
                return result;
            }

            public static bool IsImmSpec(string src)
                => XedParsers.parse(src, out ImmSpec _);

            public static bool IsSeg(string src)
            {
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                return i> 0 && j > i;
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

            public static bool IsImmSeg(string src)
            {
                var result = false;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                if(i >0 && j>i)
                    result = IsImmSpec(text.inside(src,i,j));
                return result;
            }

            public static void parse(string src, out InstPatternBody dst)
            {
                var result = Outcome.Success;
                var parts = text.trim(text.split(text.despace(src), Chars.Space));
                var count = parts.Length;
                dst = alloc<InstDefField>(count);
                for(var i=0; i<count; i++)
                {
                    result = parse(skip(parts,i), out dst[i]);
                    if(result.Fail)
                        break;
                }

                if(result.Fail)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(InstPatternBody), src));
            }

            public static bool parse(string src, out Seg dst)
            {
                var result = false;
                dst = Seg.Empty;
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
                        return false;

                    var literal = XedParsers.IsBinaryLiteral(sd);
                    if(!literal && sd.Length < 8)
                        dst = seg(field,sd);
                    else
                    {
                        result = XedParsers.parse(src, out uint8b value);
                        if(!result)
                            return false;

                        var len = sd.Length - 2;
                        switch(len)
                        {
                            case 1:
                                dst = seg(n1,field,(bit)value);
                            break;
                            case 2:
                                dst = seg(n2,field,value);
                            break;
                            case 3:
                                dst = seg(n3,field,value);
                            break;
                            case 4:
                                dst = seg(n4,field,value);
                            break;
                            default:
                                result = false;
                            break;
                        }
                    }
                }

                return result;
            }

            public static CellClass @class(string data)
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
                        dst = CK.Nonterm;
                    else if(XedParsers.IsIntLiteral(data))
                        dst = CK.IntLiteral;
                    else if(XedParsers.IsHexLiteral(data))
                        dst = CK.HexLiteral;
                    else if(XedParsers.IsBinaryLiteral(data))
                        dst = CK.BinaryLiteral;
                    else if(IsImpl(input))
                        dst = CK.Operator;
                    else if(IsSeg(input))
                    {
                        SegData(input, out var sd);
                        if(XedParsers.IsBinaryLiteral(sd))
                            dst = CK.SegLiteral;
                        else
                            dst = CK.SegVar;
                    }
                    else if(RuleKeyword.parse(input, out var keyword))
                        dst = CK.Keyword;
                    else
                        dst = CK.Text;
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

            public static bool parse(string src, out RowSpec dst)
            {
                var input = normalize(src);
                var i = text.index(input,"=>");
                dst = RowSpec.Empty;
                if(i > 0)
                {
                    var left = text.trim(text.left(input, i));
                    var premise = text.nonempty(left) ? cells(left) : Index<CellSpec>.Empty;
                    var right = text.trim(text.right(input, i+1));
                    var consequent = text.nonempty(right) ? cells(right) : Index<CellSpec>.Empty;
                    if(premise.Count != 0 || consequent.Count != 0)
                        dst = new RowSpec(premise,consequent);
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(RowSpec), src));

                return dst.IsNonEmpty;
            }

            public static bool parse(string src, out BfSeg dst)
            {
                var name = EmptyString;
                var content = EmptyString;
                dst = default;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                var result = false;
                if(i > 0 && j > i)
                {
                    name = text.left(src,i);
                    content = text.inside(src,i,j);
                    if(XedParsers.parse(name, out FieldKind kind))
                    {
                        dst = new BfSeg(kind, text.remove(content,"0b"), text.begins(content,"0b"));
                        result = true;
                    }
                }
                return result;
            }

            static bool spec(string src, out CellExpr dst)
            {
                var result = false;
                if(XedParsers.parse(src, out ImmSpec imm))
                {
                    dst = new CellExpr(OperatorKind.None, new (imm));
                    result = true;
                }
                else if(XedParsers.parse(src, out DispSpec disp))
                {
                    dst = new CellExpr(OperatorKind.None, new (disp));
                    result = true;

                }
                else if(XedParsers.parse(src, out BfSpec bf))
                {
                    dst = new CellExpr(OperatorKind.None, new (bf));
                    result = true;
                }
                else
                    dst = CellExpr.Empty;
                return result;
            }

            static bool parse(string src, out CellExpr dst)
            {
                dst = CellExpr.Empty;
                Require.invariant(IsExpr(src));

                var i = text.index(src, "!=");
                var j = text.index(src, "=");
                var right = EmptyString;
                var left = EmptyString;
                var fv = CellValue.Empty;
                var fk = FieldKind.INVALID;
                var op = OperatorKind.None;
                if(i > 0)
                {
                    right = text.right(src, i + 1);
                    op = OperatorKind.Neq;
                    left = text.left(src,i);
                }
                else if (j>0)
                {
                    right = text.right(src, j);
                    op = OperatorKind.Eq;
                    left = text.left(src,j);
                }

                Require.nonempty(left);
                if(IsSeg(left))
                {
                    var k = text.index(left,Chars.LBracket);
                    left = text.left(left,k);
                }

                XedParsers.parse(left, out fk);
                Require.nonzero(fk);

                var result = spec(right, out dst);

                if(!result)
                {
                    result = parse(fk, right, out fv);
                    dst = new CellExpr(op, fv);
                }

                if(!result)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(CellExpr), src));

                return result;
            }

            static Outcome parse(string src, out InstDefField dst)
            {
                dst = InstDefField.Empty;
                Outcome result = (false, string.Format("Unrecognized segment '{0}'", src));
                if(IsHexLiteral(src))
                {
                    result = XedParsers.parse(src, out Hex8 x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(Hex8), src));
                }
                else if(IsBinaryLiteral(src))
                {
                    result = XedParsers.parse(src, out uint5 x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(uint5), src));

                }
                else if(IsBfSeg(src))
                {
                    result = parse(src, out BfSeg x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(BfSeg), src));
                }
                else if (IsExpr(src))
                {
                    result = parse(src, out CellExpr x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(CellExpr), src));
                }
                else if(IsNontermCall(src))
                {
                    result = XedParsers.parse(src, out Nonterminal x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(Nonterminal), src));
                }
                else if (XedParsers.parse(src, out byte a))
                {
                    result = true;
                    dst = new(a);
                }

                return result;
            }

            static Index<CellSpec> cells(string src)
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

                return cells.Map(x => new CellSpec(x));
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