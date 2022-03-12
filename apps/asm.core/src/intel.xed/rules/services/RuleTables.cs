//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules.FieldKind;
    using static XedModels;

    using FK = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using SL = XedRules.SyntaxLiterals;

    partial class XedRules
    {
        public readonly struct RuleTables
        {
            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, NameResolver resolver)
                => new RuleCriterion(premise, 0, RuleOperator.Call, (uint)(int)resolver);

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, NontermCall call)
                => new RuleCriterion(premise, 0, RuleOperator.Call, (ushort)call.Kind);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion<T>(bool premise, FieldKind field, RuleOperator op, T value)
                where T : unmanaged
                    => untype(new RuleCriterion<T>(premise, field, op, value));

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion(bool premise, BitfieldSeg seg)
                => new RuleCriterion(premise, seg.Field, RuleOperator.Seg, seg.Pattern.Storage);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion untype<T>(in RuleCriterion<T> src)
                where T : unmanaged
                    => new RuleCriterion(src.IsPremise, src.Field, src.Operator, core.u64(src.Value));

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
                        result = XedParsers.parse(value, out DispFieldSpec disp);
                        if(result)
                            dst = criterion(premise, field, op, disp);
                    }
                    break;

                    case UIMM1:
                    case UIMM0:
                    {
                        result = XedParsers.parse(value, out ImmFieldSpec imm);
                        dst = criterion(premise, field, op, imm);
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

                if(!result && op == RO.Seg)
                {
                    if(XedParsers.parse(value, out BitfieldSeg seg))
                    {
                        dst = criterion(premise,seg);
                        result = true;
                    }
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
                    if(XedParsers.parse(fv, out NonterminalKind nt))
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
                else if(text.contains(input, Chars.LBracket) && text.contains(input, Chars.RBracket))
                {
                    i = text.index(input,Chars.LBracket);
                    var j = text.index(input,Chars.RBracket);
                    fv = text.inside(input,i,j);
                    //op = RO.Seg;
                    //name = text.left(input,i);
                    XedParsers.parse(text.left(input,i), out fk);
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

            static HashSet<string> Skip;

            static RuleTables()
            {
                Skip = hashset("VEXED_REX", "XED_RESET");
            }
        }
    }
}