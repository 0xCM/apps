//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedRules.SyntaxLiterals;
    using static XedRules.RuleFormKind;
    using static XedRules.FieldKind;
    using static XedModels;

    using FK = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using RF = XedRules.RuleFormKind;

    partial class XedRules
    {
        public struct RuleTableParser
        {
            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, RuleOperator op, NameResolver resolver)
                => new RuleCriterion(premise, op, resolver);

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, RuleOperator op, asci8 value)
                => new RuleCriterion(premise, 0, op, value);

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, NontermCall call)
                => new RuleCriterion(premise, call);

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, GroupName group)
                => new RuleCriterion(premise, group);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion<T>(bool premise, FieldKind field, RuleOperator op, T value)
                where T : unmanaged
                    => untype(new RuleCriterion<T>(premise, field, op, value));

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion(bool premise, BitfieldSeg seg)
                => new RuleCriterion(premise, seg.Field, RuleOperator.Seg, seg.Pattern);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion untype<T>(in RuleCriterion<T> src)
                where T : unmanaged
                    => new RuleCriterion(src.IsPremise, src.Field, src.Operator, core.u64(src.Value));

            public static RuleExpr expr(string premise, string consequent = EmptyString)
            {
                var left = sys.empty<RuleCriterion>();
                var right = sys.empty<RuleCriterion>();
                if(nonempty(premise))
                    left = specs(true, premise);

                if(nonempty(consequent))
                    right = specs(false, consequent);

                return new RuleExpr(left, right);
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
                    else if(XedParsers.parse(fv, out GroupName g))
                        dst = criterion(premise, g);
                    else
                        dst = criterion(premise, op, NameResolvers.Instance.Create(fv));
                    return true;
                }
                else if(text.contains(input, Chars.LBracket) && text.contains(input, Chars.RBracket))
                {
                    i = text.index(input,Chars.LBracket);
                    var result = XedParsers.parse(text.left(input,i), out fk);
                    if(!result)
                        return (false, AppMsg.ParseFailure.Format(nameof(FieldKind), input));

                    return criterion(premise, fk, RuleOperator.Seg, input, out dst);
                }
                else if(text.contains(input, "!="))
                {
                    op = RO.CmpNeq;
                    opsym = "!=";
                    i= text.index(input, "!");
                    XedParsers.parse(text.left(input, i), out fk);
                    fv = text.right(input, i + opsym.Length - 1);
                    return criterion(premise, fk, op, fv, out dst);
                }
                else if(text.contains(input, "="))
                {
                    opsym = "=";
                    if(premise)
                        op = RO.CmpEq;
                    else
                        op = RO.Assign;

                    i = text.index(input, opsym);
                    var result = XedParsers.parse(text.left(input, i), out fk);
                    if(!result)
                        return (false, AppMsg.ParseFailure.Format(nameof(FieldKind), input));

                    return criterion(premise, fk, op, text.right(input, i), out dst);
                }
                else
                {
                    var literal = input;
                    var assigned = RuleMacros.assignments(literal, out var assignments);
                    if(assigned && assignments.Length != 0 && first(assignments).Field != 0)
                    {
                        ref readonly var a = ref first(assignments);
                        dst = criterion(premise, a.Field, RuleOperator.Assign, a.Value);
                        return true;
                    }
                    else
                    {
                        if(literal == "otherwise")
                            literal = "_";
                        else if(literal == "nothing")
                            literal = "default";

                        return criterion(premise, FieldKind.INVALID, RuleOperator.Literal, literal, out dst);
                    }
                }
            }

            [Op]
            public static Outcome criterion(bool premise, FieldKind field, RuleOperator op, string value, out RuleCriterion dst)
            {
                var result = Outcome.Success;
                dst = default;
                if(op == RuleOperator.Seg)
                {
                    if(XedParsers.parse(value, out BitfieldSeg seg))
                    {
                        dst = criterion(premise,seg);
                        return true;
                    }
                }
                else if(op == RuleOperator.Literal)
                {
                    dst = criterion(premise, op, (asci8)value);
                    return true;
                }

                switch(field)
                {
                    case AGEN:
                    case AMD3DNOW:
                    case ASZ:
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
                    case WBNOINVD:
                    case REXRR:
                    case SAE:
                    case BCRC:
                    case ZEROING:
                    {
                        if(XedParsers.parse(value, out bit x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case REXW:
                    {
                        if(XedParsers.parse(value, out bit x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'w')
                        {
                            dst = criterion(premise,new BitfieldSeg(field, value[0], false));
                            result = true;
                        }
                    }
                    break;
                    case REXR:
                    {
                        if(XedParsers.parse(value, out bit x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'r')
                        {
                            dst = criterion(premise,new BitfieldSeg(field, value[0], false));
                            result = true;
                        }
                    }
                    break;
                    case REXX:
                    {
                        if(XedParsers.parse(value, out bit x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'x')
                        {
                            dst = criterion(premise,new BitfieldSeg(field, value[0], false));
                            result = true;
                        }
                    }
                    break;
                    case REXB:
                    {
                        if(XedParsers.parse(value, out bit x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'b')
                        {
                            dst = criterion(premise,new BitfieldSeg(field, value[0], false));
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
                    case DEFAULT_SEG:
                    case MODE:
                    case REP:
                    case SMODE:
                    case VEX_PREFIX:
                    case VL:
                    case LLRC:
                    {
                        if(XedParsers.parse(value, out byte x))
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
                        if(XedParsers.parse(value, out byte x))
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
                        if(XedParsers.parse(value, out byte x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case BCAST:
                    {
                        if(XedParsers.parse(value, out byte x))
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
                        if(XedParsers.parse(value, out byte x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case ELEMENT_SIZE:
                    case MEM_WIDTH:
                    {
                        if(ushort.TryParse(value, out ushort x))
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
                    case MASK:
                    case SRM:
                    {
                        if(XedParsers.parse(value, out byte x))
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
                        if(XedParsers.parse(value, out XedRegId x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;
                    case CHIP:
                    {
                        if(XedParsers.parse(value, out ChipCode x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case ERROR:
                    {
                        if(XedParsers.parse(value, out ErrorKind x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case ICLASS:
                    {
                        if(XedParsers.parse(value, out IClass x))
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

            public static RF RuleForm(TextLine src)
            {
                var i = text.index(src.Content, Chars.Hash);
                var content = (i> 0 ? text.left(src.Content,i) : src.Content).Trim();
                if(IsTableDecl(content))
                    return RF.RuleDecl;
                if(IsEncStep(content))
                    return RF.EncodeStep;
                if(IsDecStep(content))
                    return RF.DecodeStep;
                if(IsCall(content))
                    return RF.Invocation;
                if(IsSeqDecl(content))
                    return RF.SeqDecl;
                return 0;
            }

            RuleTable Table;

            List<RuleTable> Tables;

            LineReader Reader;

            RuleFormKind Kind;

            TextLine Line;

            public RuleTableParser()
            {
                Table = RuleTable.Empty;
                Reader = default;
                Line = TextLine.Empty;
                Kind = 0;
                Tables = new();
            }

            public Outcome Parse(TextLine src)
            {
                Line = src;
                var result = Outcome.Success;
                Kind = RuleForm(Line);
                if(Kind == SeqDecl)
                    ParseSeqTerms();

                while(Kind == RuleDecl)
                {
                    ParseRuleDecl();
                }

                return result;
            }

            public Index<RuleTable> Parse(FS.FilePath src)
            {
                try
                {
                    Reader = src.Utf8LineReader();
                    Parse();
                    return Tables.ToArray();
                }
                finally
                {
                    Reader.Dispose();
                }
            }

            void Parse()
            {
                while(Reader.Next(out var line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash))
                        continue;

                    Parse(line).Require();
                }
            }

            void ParseSeqTerms()
            {
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    Kind = RuleForm(Line);
                    if(Kind == 0 || Kind == Invocation)
                        continue;
                    else
                        break;
                }
            }

            void ParseRuleExpr()
            {
                var expressions = list<RuleExpr>();
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    Kind = RuleForm(Line);
                    if(Kind == 0)
                        continue;

                    if(Kind == RuleFormKind.EncodeStep || Kind == RuleFormKind.DecodeStep)
                    {
                        var content = normalize(Line.Content);
                        var parts =
                            IsEncStep(content) ? text.split(content, EncStep)
                            : IsDecStep(content) ? text.split(content, DecStep)
                            : sys.empty<string>();

                        if(parts.Length == 2)
                            expressions.Add(expr(parts[0], parts[1]));
                        else if(parts.Length == 1)
                            expressions.Add(expr(parts[0]));
                        else
                            Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleExpr), content));
                    }
                    else
                        break;
                }

                Table.Expressions = expressions.ToArray();
            }

            void ParseRuleDecl()
            {
                var ruledecl = text.trim(text.left(Line.Content, TableDeclSyntax));
                var i = text.index(ruledecl, Chars.Space);
                var name = EmptyString;
                var ret = EmptyString;
                if(i > 0)
                {
                    name = text.right(ruledecl,i);
                    ret = text.left(ruledecl,i);
                }
                else
                    name = ruledecl;

                ParseRuleExpr();

                if(Skip.Contains(name))
                {
                    Table = RuleTable.Empty;
                    return;
                }

                Table.Name = name;
                Table.ReturnType = ret;
                Tables.Add(Table);
                Table = RuleTable.Empty;
            }

            static string normalize(string src)
            {
                var i = text.index(src, Chars.Hash);
                if(i>0)
                    return text.despace(text.trim(text.left(src,i)));
                else
                    return text.despace(text.trim(src));
            }

            static HashSet<string> Skip;

            static RuleTableParser()
            {
                Skip = hashset("VEXED_REX", "XED_RESET");
            }
        }
    }
}