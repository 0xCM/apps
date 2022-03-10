//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules.FieldKind;
    using static XedModels;

    using FK = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using SL = XedRules.SyntaxLiterals;
    using FC = XedRules.FormatCode;

    partial class XedRules
    {
        public readonly struct RuleTables
        {
            static XedParsers Parsers => XedParsers.create();

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, NameResolver resolver)
                => new RuleCriterion(premise, 0, RuleOperator.Call, FormatCode.Call, (uint)(int)resolver);

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, NontermCall call)
                => new RuleCriterion(premise, 0, RuleOperator.Call, FormatCode.Call, (ushort)call.Kind);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion<T>(bool premise, FieldKind field, RuleOperator op, T value)
                where T : unmanaged
                    => untype(new RuleCriterion<T>(premise, field, op, value));

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion untype<T>(in RuleCriterion<T> src)
                where T : unmanaged
                    => new RuleCriterion(src.IsPremise, src.Field, src.Operator, fcode(src.Field), core.u64(src.Value));

            [Op]
            public static Outcome criterion(bool premise, FieldKind field, RuleOperator op, string value, out RuleCriterion dst)
            {
                var result = Outcome.Success;
                dst = default;
                if(op == RuleOperator.Call)
                {
                    dst = criterion(premise, NameResolvers.Instance.Create(value));
                    return true;
                }

                switch(field)
                {
                    case AGEN:
                    case AMD3DNOW:
                    case ASZ:
                    case BCRC:
                    case CET:
                    case CLDEMOTE:
                    case DF32:
                    case DF64:
                    case DUMMY:
                    case ENCODER_PREFERRED:
                    case ENCODE_FORCE:
                    case HAS_MODRM:
                    case HAS_SIB:
                    case ILD_F2:
                    case ILD_F3:
                    case IMM0:
                    case IMM0SIGNED:
                    case IMM1:
                    case LOCK:
                    case LZCNT:
                    case MEM0:
                    case MEM1:
                    case MODE_FIRST_PREFIX:
                    case MODE_SHORT_UD0:
                    case MODEP5:
                    case MODEP55C:
                    case MPXMODE:
                    case MUST_USE_EVEX:
                    case NEEDREX:
                    case NEED_SIB:
                    case NOREX:
                    case NO_RETURN:
                    case NO_SCALE_DISP8:
                    case REX:
                    case REXW:
                    case REXR:
                    case REXX:
                    case REXB:
                    case OSZ:
                    case OUT_OF_BYTES:
                    case P4:
                    case PREFIX66:
                    case PTR:
                    case REALMODE:
                    case RELBR:
                    case TZCNT:
                    case UBIT:
                    case USING_DEFAULT_SEGMENT0:
                    case USING_DEFAULT_SEGMENT1:
                    case VEX_C4:
                    case VEXDEST3:
                    case VEXDEST4:
                    case ZEROING:
                    case WBNOINVD:
                    case REXRR:
                    case SAE:
                    {
                        if(bit.parse(value, out var x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case MOD:
                    case SIBSCALE:
                    case FK.EASZ:
                    case FK.EOSZ:
                    case FIRST_F2F3:
                    case LAST_F2F3:
                    case LLRC:
                    case DEFAULT_SEG:
                    case MODE:
                    case REP:
                    case SMODE:
                    case VEX_PREFIX:
                    case VL:
                    {
                        if(byte.TryParse(value, out var x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case SIBBASE:
                    case HINT:
                    case ROUNDC:
                    case SEG_OVD:
                    case VEXVALID:
                    {
                        if(byte.TryParse(value, out var x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case MAP:
                    case NELEM:
                    case SCALE:
                    {
                        if(byte.TryParse(value, out var x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case BCAST:
                    {
                        if(byte.TryParse(value, out var x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case BRDISP_WIDTH:
                    case DISP_WIDTH:
                    case ILD_SEG:
                    case IMM1_BYTES:
                    case IMM_WIDTH:
                    case MAX_BYTES:
                    case MODRM_BYTE:
                    case NPREFIXES:
                    case NREXES:
                    case NSEG_PREFIXES:
                    case POS_DISP:
                    case POS_IMM:
                    case POS_IMM1:
                    case POS_MODRM:
                    case POS_NOMINAL_OPCODE:
                    case POS_SIB:
                    case NEED_MEMDISP:
                    {
                        if(byte.TryParse(value, out var x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case ELEMENT_SIZE:
                    case MEM_WIDTH:
                    {
                        if(ushort.TryParse(value, out var x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case SIBINDEX:
                    case REG:
                    case RM:
                    case VEXDEST210:
                    case SRM:
                    case MASK:
                    {
                        if(DataParser.parse(value, out Hex3 x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case ESRC:
                    {
                        if(DataParser.parse(value, out Hex4 x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;


                    case NOMINAL_OPCODE:
                    {
                        if(DataParser.parse(value, out Hex8 x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case DISP:
                    {
                        dst = criterion(premise, field, op, DispFieldSpec.parse(value));
                        result = true;
                    }
                    break;

                    case UIMM1:
                    case UIMM0:
                    {
                        result = RuleParser.immfield(value, out var x);
                        dst = criterion(premise, field, op, x);
                    }
                    break;

                    case BASE0:
                    case BASE1:
                    case INDEX:
                    case OUTREG:
                    case SEG0:
                    case SEG1:
                    case REG0:
                    case REG1:
                    case REG2:
                    case REG3:
                    case REG4:
                    case REG5:
                    case REG6:
                    case REG7:
                    case REG8:
                    case REG9:
                    {
                        if(DataParser.eparse(text.remove(value, "XED_REG_"), out XedRegId x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;
                    case CHIP:
                    {
                        if(DataParser.eparse(value, out ChipCode x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case ERROR:
                    {
                        if(DataParser.eparse(value, out ErrorKind x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case ICLASS:
                    {
                        if(DataParser.eparse(value, out IClass x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    default:
                        break;
                }
                return result;
            }

            public static Outcome spec(bool premise, string spec, out RuleCriterion dst)
            {
                var input = text.trim(text.despace(spec));
                var fk = FK.INVALID;
                var op = RO.None;
                var fv = input;
                var name = EmptyString;
                var i = -1;
                var opsym = EmptyString;
                dst = RuleCriterion.Empty;
                if(text.contains(input, "()"))
                {
                    op = RO.Call;
                    opsym = "()";
                    i = text.index(input, '(');
                    fv = text.left(input,i);
                    if(Parsers.Nonterm(fv, out var nt))
                        dst = criterion(premise, nt);
                    else
                        dst = criterion(premise, NameResolvers.Instance.Create(fv));
                    return true;
                }
                else if(text.contains(input, "=="))
                {
                    op = RO.CmpEq;
                    opsym = "==";
                    i= text.index(input, "==");
                    name = text.left(input,i);
                    fv = text.right(input, i + opsym.Length - 1);
                }
                else if(text.contains(input, "!="))
                {
                    op = RO.CmpNeq;
                    opsym = "!=";
                    i= text.index(input, "!");
                    name = text.left(input,i);
                    fv = text.right(input, i + opsym.Length - 1);
                }
                else if(text.contains(input, "="))
                {
                    op = RO.Assign;
                    opsym = "=";
                    i = text.index(input, "=");
                    name = text.left(input,i);
                    fv = text.right(input, i + opsym.Length - 1);
                }
                else if(text.contains(input,"UIMM0[") || text.contains(input, "DISP[") || text.contains(input, "UIMM1["))
                {
                    name = text.left(input, text.index(input,'['));
                    Parsers.Parse(name, out fk);
                }

                if(nonempty(name) && fk == 0)
                {
                    if(name.Equals(SL.REXW))
                        fk = FK.REXW;
                    else if(name.Equals(SL.REXB))
                        fk = FK.REXB;
                    else if(name.Equals(SL.REXR))
                        fk = FK.REXR;
                    else if(name.Equals(SL.REXX))
                        fk = FK.REXX;
                    else if(!FieldKinds.ExprKind(name, out fk))
                        return (false, AppMsg.ParseFailure.Format(name, spec));
                }

                return criterion(premise, fk, op, fv, out dst);
            }

            public static Index<RuleCriterion> specs(bool premise, string src)
            {
                var parts = text.trim(text.split(src, Chars.Space)).Where(x => nonempty(x) && !Skip.Contains(x));
                var count = parts.Length;
                var buffer = alloc<RuleCriterion>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(parts, i);
                    ref var dst = ref seek(buffer,i);
                    var result = spec(premise, part, out seek(buffer,i));
                    if(result.Fail)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), part));
                }
                return buffer;
            }

            public static RuleTable table(in RuleTermTable src)
            {
                var buffer = alloc<RuleExpr>(src.Expressions.Count);
                for(var i=0; i<src.Expressions.Count; i++)
                {
                    ref readonly var input = ref src.Expressions[i];
                    var p = specs(true, input.Premise.Map(x=> x.Format()).Delimit(Chars.Space).Format());
                    var c = specs(false, input.Consequent.Map(x=> x.Format()).Delimit(Chars.Space).Format());
                    seek(buffer,i) = new RuleExpr(p,c);
                }
                var dst = RuleTable.Empty;
                dst.Expressions = buffer;
                dst.Name = src.Name;
                dst.ReturnType = src.ReturnType;
                return dst;
            }

            public static RuleExpr expr(RuleFormKind kind, string premise, string consequent = EmptyString)
            {
                var left = sys.empty<RuleCriterion>();
                var right = sys.empty<RuleCriterion>();
                if(nonempty(premise))
                    left = specs(true, premise);

                if(nonempty(consequent))
                    right = specs(false, consequent);

                return new RuleExpr(left, right);
            }

            public static string format(ImmFieldSpec src)
                => src.Width == 0 ? EmptyString : string.Format("{0}{1}[i/{2}]", "UIMM", src.Index, src.Width);

            public static string format(DispFieldSpec src)
                => src.Width == 0 ? EmptyString : string.Format("{0}[{1}/{2}]", "DISP", src.Kind, src.Width);

            public static string format(RuleCall src)
                => src.Target.IsEmpty ? EmptyString : string.Format("{0}()", src.Target);

            public static string format(in RuleCriterion src)
            {
                var dst = EmptyString;
                if(src.Operator == RuleOperator.Call)
                    dst = format(src.AsCall());
                else if(src.Field == FieldKind.UIMM0 || src.Field == FieldKind.UIMM1)
                    dst = format(src.AsImmField());
                else if(src.Field == FieldKind.DISP)
                    dst = format(src.AsDispField());
                else
                {
                    dst = XedFormatters.format(src.Field);
                    if(src.Operator != 0)
                        dst += XedFormatters.format(src.Operator);
                    dst += format(src.AsValue());
                }
                return dst;
            }

            public static string format(in RuleTable src)
            {
                var dst = text.buffer();
                dst.AppendLine(sig(src));
                var expressions = src.Expressions.View;
                var count = expressions.Length;
                dst.AppendLine(Chars.LBrace);
                for(var i=0; i<count; i++)
                    dst.IndentLine(4, format(skip(expressions, i)));
                dst.AppendLine(Chars.RBrace);
                return dst.Emit();
            }

            public static string format(in RuleExpr src)
            {
                var sep = " <=> ";
                var dst = text.buffer();
                render(src.Premise, dst);
                dst.Append(sep);
                render(src.Consequent, dst);
                return dst.Emit();
            }

            static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
            {
                var count = src.Length;
                for(var i=0; i<count; i++)
                {
                    if(i != 0)
                        dst.Append(" && ");
                    dst.Append(skip(src,i).Format());
                }
            }

            public static string format(FieldValue src)
            {
                var dst = EmptyString;
                if(src.IsEmpty)
                    return EmptyString;

                var data = bytes(src.Data);
                var code = fcode(src.Kind);

                switch(code)
                {
                    case FormatCode.Text:
                        dst = ((NameResolver)((int)src.Data)).Format();
                        break;
                    case FC.B1:
                    {
                        bit x = first(data);
                        dst = x.Format();
                    }
                    break;
                    case FC.B2:
                    {
                        uint2 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.B3:
                    {
                        uint3 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.B4:
                    {
                        uint4 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.B5:
                    {
                        uint5 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.B6:
                    {
                        uint6 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.B7:
                    {
                        uint7 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.B8:
                    {
                        uint8b x = first(data);
                        dst = format(x);
                    }
                    break;

                    case FC.U2:
                    {
                        byte x = (byte)(first(data) & 0b11);
                        dst = format(x);
                    }
                    break;

                    case FC.U3:
                    {
                        byte x = (byte)(first(data) & 0b111);
                        dst = format(x);
                    }
                    break;

                    case FC.U4:
                    {
                        byte x = (byte)(first(data) & 0b1111);
                        dst = format(x);
                    }
                    break;

                    case FC.U5:
                    {
                        byte x = (byte)(first(data) & 0b11111);
                        dst = format(x);
                    }
                    break;

                    case FC.U8:
                    {
                        var x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.U16:
                    {
                        var x = @as<ushort>(data);
                        dst = format(x);
                    }
                    break;
                    case FC.U32:
                    {
                        var x = @as<uint>(data);
                        dst = format(x);
                    }
                    break;
                    case FC.U64:
                    {
                        var x = @as<ulong>(data);
                        dst = format(x);
                    }
                    break;

                    case FC.I8:
                    {
                        var x = @as<sbyte>(data);
                        dst = format(x);
                    }
                    break;
                    case FC.I16:
                    {
                        var x = @as<short>(data);
                        dst = format(x);
                    }
                    break;
                    case FC.I32:
                    {
                        var x = @as<int>(data);
                        dst = format(x);
                    }
                    break;
                    case FC.I64:
                    {
                        var x = @as<long>(data);
                        dst = format(x);
                    }
                    break;

                    case FC.X2:
                    {
                        Hex2 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.X3:
                    {
                        Hex3 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.X4:
                    {
                        Hex4 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.X5:
                    {
                        Hex5 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.X6:
                    {
                        Hex6 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.X7:
                    {
                        Hex7 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.X8:
                    {
                        Hex8 x = first(data);
                        dst = format(x);
                    }
                    break;
                    case FC.X16:
                    {
                        Hex16 x = @as<ushort>(data);
                        dst = format(x);
                    }
                    break;
                    case FC.X32:
                    {
                        Hex32 x = @as<uint>(data);
                        dst = format(x);
                    }
                    break;
                    case FC.X64:
                    {
                        Hex64 x = @as<ulong>(data);
                        dst = format(x);
                    }
                    break;

                    case FC.Disp:
                    {
                        Disp64 x = @as<long>(data);
                        dst = x.Format();
                    }
                    break;

                    case FC.Broadcast:
                    {
                        var x = @as<BCastKind>(data);
                        dst = XedFormatters.format(x);
                    }
                    break;
                    case FC.Chip:
                    {
                        var x = @as<ChipCode>(data);
                        dst = XedFormatters.format(x);
                    }
                    break;
                    case FC.Reg:
                    {
                        var x = @as<XedRegId>(data);
                        dst = XedFormatters.format(x);
                    }
                    break;
                    case FC.InstClass:
                    {
                        var x = @as<IClass>(data);
                        dst = XedFormatters.format(x);
                    }
                    break;
                    case FC.MemWidth:
                    {
                        var x = @as<ushort>(data);
                        dst = x.ToString();
                    }
                    break;
                    case FC.EnumSymbol:
                    break;
                    case FC.EnumValue:
                    break;
                    case FC.EnumName:
                    break;

                }
                return dst;
            }

            static string format(uint2 src)
                => src.Format();

            static string format(uint3 src)
                => src.Format();

            static string format(uint4 src)
                => src.Format();

            static string format(uint5 src)
                => src.Format();

            static string format(uint6 src)
                => src.Format();

            static string format(uint7 src)
                => src.Format();

            static string format(uint8b src)
                => src.Format();

            static string format(sbyte src)
                => src.ToString();

            static string format(short src)
                => src.ToString();

            static string format(int src)
                => src.ToString();

            static string format(long src)
                => src.ToString();

            static string format(byte src)
                => src.ToString();

            static string format(ushort src)
                => src.ToString();

            static string format(uint src)
                => src.ToString();

            static string format(ulong src)
                => src.ToString();

            static string format(Hex2 src)
                => src.Format(prespec:true, uppercase:true);

            static string format(Hex3 src)
                => src.Format(prespec:true, uppercase:true);

            static string format(Hex4 src)
                => src.Format(prespec:true, uppercase:true);

            static string format(Hex5 src)
                => src.Format(prespec:true, uppercase:true);

            static string format(Hex6 src)
                => src.Format(prespec:true, uppercase:true);

            static string format(Hex7 src)
                => src.Format(prespec:true, uppercase:true);

            static string format(Hex8 src)
                => src.Format(prespec:true, uppercase:true);

            static string format(Hex16 src)
                => src.Format(prespec:true, uppercase:true);

            static string format(Hex32 src)
                => src.Format(prespec:true, uppercase:true);

            static string format(Hex64 src)
                => src.Format(prespec:true, uppercase:true);

            public static string format(BitfieldSeg src)
                => string.Format(src.IsLiteral ? "{0}[0b{1}]" : "{0}[{1}]",
                    XedFormatters.format(src.Field),
                    src.Pattern)
                    ;

            public static string format(FieldAssign src)
                => src.Field == 0 ? "nothing" :
                    string.Format("{0}={1}",
                    XedFormatters.format(src.Field),
                    src.Value);

            public static string format(FieldCmp src)
                => src.IsEmpty ? EmptyString
                    : string.Format("{0}{1}{2}",
                        XedFormatters.format(src.Left.Kind),
                        XedFormatters.format(src.Operator),
                        format(src.Left)
                        );

            public static string format(in NonterminalRule src)
                => format(src.Table);

            public static string format(FieldConstraint src)
                => string.Format("{0}{1}{2}",
                        XedFormatters.format(src.Field),
                        XedFormatters.format(src.Kind),
                        literal(src.LiteralKind, src.Value)
                        );

            public static string format(NontermCall src)
                => string.Format("<{0}>()", format(src.Kind));

            static string literal(FieldLiteralKind kind, byte src)
            {
                var val = EmptyString;
                switch(kind)
                {
                    case FieldLiteralKind.BinaryLiteral:
                        val = "0b" + ((uint8b)(src)).Format();
                    break;
                    case FieldLiteralKind.DecimalLiteral:
                        val = src.ToString();
                    break;
                    case FieldLiteralKind.HexLiteral:
                        val = ((Hex8)(src)).Format(prespec:true, uppercase:true);
                    break;
                    default:
                        val = RP.Error;
                    break;
                }
                return val;
            }

            static HashSet<string> Skip;

            static RuleTables()
            {
                Skip = hashset("VEXED_REX", "XED_RESET");
            }
        }
    }
}