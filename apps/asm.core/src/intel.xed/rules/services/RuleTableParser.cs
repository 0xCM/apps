//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static Root;
    using static XedRules.SyntaxLiterals;
    using static XedRules.RuleFormKind;
    using static XedModels;

    using K = XedRules.FieldKind;
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
                var fk = K.INVALID;
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
                        if(XedParsers.parse(value, out bit x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.REXW:
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
                    case K.REXR:
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
                    case K.REXX:
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
                    case K.REXB:
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
                    {
                        if(XedParsers.parse(value, out byte x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.SIBBASE:
                    case K.HINT:
                    case K.ROUNDC:
                    case K.SEG_OVD:
                    case K.VEXVALID:
                    {
                        if(XedParsers.parse(value, out byte x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.MAP:
                    case K.NELEM:
                    case K.SCALE:
                    {
                        if(XedParsers.parse(value, out byte x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.BCAST:
                    {
                        if(XedParsers.parse(value, out byte x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

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
                    {
                        if(XedParsers.parse(value, out byte x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.ELEMENT_SIZE:
                    case K.MEM_WIDTH:
                    {
                        if(ushort.TryParse(value, out ushort x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.SIBINDEX:
                    case K.REG:
                    case K.RM:
                    case K.VEXDEST210:
                    case K.MASK:
                    case K.SRM:
                    {
                        if(XedParsers.parse(value, out byte x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.ESRC:
                    {
                        if(DataParser.parse(value, out Hex4 x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;


                    case K.NOMINAL_OPCODE:
                    {
                        if(DataParser.parse(value, out Hex8 x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.DISP:
                    {
                        result = XedParsers.parse(value, out DispFieldSpec disp);
                        if(result)
                            dst = criterion(premise, field, op, disp);
                    }
                    break;

                    case K.UIMM1:
                    case K.UIMM0:
                    {
                        result = XedParsers.parse(value, out ImmFieldSpec imm);
                        dst = criterion(premise, field, op, imm);
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
                        if(XedParsers.parse(value, out XedRegId x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;
                    case K.CHIP:
                    {
                        if(XedParsers.parse(value, out ChipCode x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.ERROR:
                    {
                        if(XedParsers.parse(value, out ErrorKind x))
                        {
                            dst = criterion(premise, field, op, x);
                            result = true;
                        }
                    }
                    break;

                    case K.ICLASS:
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

            XedDocKind DocKind;

            public RuleTableParser()
            {
                Table = RuleTable.Empty;
                Reader = default;
                Line = TextLine.Empty;
                Kind = 0;
                Tables = new();
                DocKind = 0;
            }

            Outcome Parse(TextLine src)
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
                    DocKind = XedPaths.srckind(src.FileName);
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
                switch(DocKind)
                {
                    case XedDocKind.EncRuleTable:
                        Table.TableSig = new (RuleTableKind.Enc,name);
                    break;
                    case XedDocKind.EncDecRuleTable:
                        Table.TableSig = new (RuleTableKind.EncDec,name);
                    break;
                    case XedDocKind.DecRuleTable:
                        Table.TableSig = new (RuleTableKind.Dec,name);
                    break;
                }
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