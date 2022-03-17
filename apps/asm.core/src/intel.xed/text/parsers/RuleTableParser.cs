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
    using static XedParsers;

    using K = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using RF = XedRules.RuleFormKind;

    partial class XedRules
    {
        public struct RuleTableParser
        {
            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, FieldKind fk, asci8 value, CellDataKind dk)
                => new RuleCriterion(premise, fk, RuleOperator.None,  value, dk);

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, RuleCall call)
                => new RuleCriterion(premise, call);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion<T>(bool premise, FieldKind field, RuleOperator op, T value)
                where T : unmanaged
                    => new RuleCriterion(premise, field,  op, core.bw64(value));

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion(bool premise, BitfieldSeg seg)
                => new RuleCriterion(premise, seg);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion(bool premise, BitfieldSpec src)
                => new RuleCriterion(premise, src);

            static RuleExpr expr(string premise, string consequent = EmptyString)
            {
                var buffer = list<RuleCriterion>();

                if(nonempty(premise))
                    specs(true, RuleMacros.expand(premise), buffer);

                var left = buffer.ToArray();
                buffer.Clear();

                if(nonempty(consequent))
                    specs(false, RuleMacros.expand(consequent), buffer);

                var right = buffer.ToArray();
                return new RuleExpr(left, right);
            }

            static void specs(bool premise, string src, List<RuleCriterion> buffer)
            {
                var parts = text.trim(text.split(src, Chars.Space)).Where(x => nonempty(x) && !Skip.Contains(x));
                var count = parts.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(parts, i);
                    var criterion = RuleCriterion.Empty;
                    var result = spec(premise, part, buffer);
                    if(result.Fail)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), part));
                }
            }

            static void parse(bool premise, string input, out FieldKind fk, out string fv, out RuleOperator op)
            {
                var i = text.index(input, "!=");
                fv = EmptyString;
                op = 0;
                fk = 0;
                if(i > 0)
                {
                    op = RO.CmpNeq;
                    fv = text.right(input, i + 1);
                }
                else
                {
                    i = text.index(input, "=");
                    if(i > 0)
                    {
                        if(premise)
                            op = RO.CmpEq;
                        else
                            op = RO.Assign;

                        fv = text.right(input, i);
                    }
                }

                XedParsers.parse(text.left(input, i), out fk);
            }

            static bool assignment(bool premise, string input, out FieldKind fk, out string fv)
            {
                fk = 0;
                fv = EmptyString;
                var result = IsAssign(input);
                if(result)
                {
                    var i = text.index(input, "=");
                    fv = text.right(input, i);
                    result = XedParsers.parse(text.left(input, i), out fk);
                }
                return result;
            }

            static bool notequal(bool premise, string input, out FieldKind fk, out string fv)
            {
                fk = 0;
                fv = EmptyString;
                var result = IsNeq(input);
                if(result)
                {
                    var i = text.index(input, "!=");
                    fv = text.right(input, i + 1);

                    result = XedParsers.parse(text.left(input, i), out fk);
                }
                return result;
            }

            static Outcome spec(bool premise, string spec, List<RuleCriterion> dst)
            {
                var input = text.trim(text.despace(spec));
                var fk = K.INVALID;
                var op = RO.None;
                var fv = input;
                var i = -1;
                if(IsCall(input))
                {
                    var name = text.remove(input,"()");
                    parse(premise, name, out fk, out fv, out op);
                    dst.Add(criterion(premise, call(fk, op, text.ifempty(fv,name))));
                    return true;
                }
                else if(assignment(premise, input, out fk, out fv))
                {
                    if(parse(premise, fk, RO.Assign, fv, out var _p))
                    {
                        dst.Add(_p);
                        return true;
                    }
                    return false;
                }
                else if(notequal(premise, input, out fk, out fv))
                {
                    if(parse(premise, fk, RO.CmpNeq, fv, out var _p))
                    {
                        dst.Add(_p);
                        return true;
                    }
                    return false;
                }
                else if(IsBfSeg(input))
                {
                    var result = XedParsers.parse(input, out BitfieldSeg seg);
                    if(result)
                         dst.Add(criterion(premise, seg));
                    return result;
                }
                else if(IsBfSpec(input))
                {
                    dst.Add(criterion(premise,new BitfieldSpec(input)));
                    return true;
                }
                else
                {
                    if(input.Length > 8)
                        Errors.Throw(string.Format("The value '{0}' is too long to be a literal", input));

                    dst.Add(literal(premise,input));
                    return true;
                }
            }

            static RuleCriterion literal(bool premise, string input)
            {
                if(XedParsers.IsBinaryLiteral(input))
                    return criterion(premise, 0, (asci8)input, CellDataKind.Literal);
                else if(input == "otherwise")
                    return criterion(premise, 0, (asci8)"else", CellDataKind.Default);
                else if(input == "nothing")
                    return criterion(premise, 0, (asci8)"null", CellDataKind.Null);
                else if(input == "error")
                    return criterion(premise, FieldKind.ERROR, (asci8)"error", CellDataKind.Error);
                else if(input == "@")
                    return criterion(premise, 0, (asci8)"@", CellDataKind.Wildcard);
                else
                    return criterion(premise, 0, (asci8)input, CellDataKind.Literal);
            }

            [Op]
            static Outcome parse(bool premise, FieldKind field, RuleOperator op, string value, out RuleCriterion dst)
            {
                var result = Outcome.Success;
                dst = default;
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
                            dst = criterion(premise, field, op, b);
                            result = true;
                        }
                    }
                    break;

                    case K.REXW:
                    {
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = criterion(premise, field, op, b);
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
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = criterion(premise, field, op, b);
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
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = criterion(premise, field, op, b);
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
                        if(XedParsers.parse(value, out byte u8))
                        {
                            dst = criterion(premise, field, op, u8);
                            result = true;
                        }
                    }
                    break;

                    case K.MAP:
                    case K.NELEM:
                    case K.SCALE:
                    {
                        if(XedParsers.parse(value, out byte u8))
                        {
                            dst = criterion(premise, field, op, u8);
                            result = true;
                        }
                    }
                    break;

                    case K.BCAST:
                    {
                        if(XedParsers.parse(value, out byte u8))
                        {
                            dst = criterion(premise, field, op, u8);
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
                        if(XedParsers.parse(value, out byte u8))
                        {
                            dst = criterion(premise, field, op, u8);
                            result = true;
                        }
                    }
                    break;

                    case K.ELEMENT_SIZE:
                    case K.MEM_WIDTH:
                    {
                        if(ushort.TryParse(value, out ushort u8))
                        {
                            dst = criterion(premise, field, op, u8);
                            result = true;
                        }
                    }
                    break;

                    case K.RM:
                    {
                        if(XedParsers.parse(value, out byte u8))
                        {
                            dst = criterion(premise, field, op, u8);
                            result = true;
                        }
                    }
                    break;

                    case K.SIBINDEX:
                    case K.REG:
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
                        if(DataParser.parse(value, out Hex8 hex))
                        {
                            dst = criterion(premise, field, op, hex);
                            result = true;
                        }
                    }
                    break;

                    case K.DISP:
                    {
                        result = byte.TryParse(value, out byte x);
                        if(result)
                            dst = criterion(premise,field,op,x);
                        else
                        {
                            result = XedParsers.parse(value, out DispFieldSpec disp);
                            if(result)
                                dst = criterion(premise, field, op, disp);
                        }
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
                        if(XedParsers.parse(value, out XedRegId reg))
                        {
                            dst = criterion(premise, field, op, reg);
                            result = true;
                        }
                    }
                    break;
                    case K.CHIP:
                    {
                        if(XedParsers.parse(value, out ChipCode chip))
                        {
                            dst = criterion(premise, field, op, chip);
                            result = true;
                        }
                    }
                    break;

                    case K.ERROR:
                    {
                        if(XedParsers.parse(value, out ErrorKind error))
                        {
                            dst = criterion(premise, field, op, error);
                            result = true;
                        }
                    }
                    break;

                    case K.ICLASS:
                    {
                        if(XedParsers.parse(value, out IClass @class))
                        {
                            dst = criterion(premise, field, op, @class);
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

            RuleFormKind FormKind;

            TextLine Line;

            XedDocKind DocKind;

            public RuleTableParser()
            {
                Table = RuleTable.Empty;
                Reader = default;
                Line = TextLine.Empty;
                FormKind = 0;
                Tables = new();
                DocKind = 0;
            }

            Outcome Parse(TextLine src)
            {
                Line = src;
                var result = Outcome.Success;
                FormKind = RuleForm(Line);
                if(FormKind == SeqDecl)
                    ParseSeqTerms();

                while(FormKind == RuleDecl)
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
                    while(Reader.Next(out var line))
                    {
                        if(line.IsEmpty || line.StartsWith(Chars.Hash))
                            continue;

                        Parse(line).Require();
                    }
                    return Tables.ToArray();
                }
                finally
                {
                    Reader.Dispose();
                }
            }

            void ParseSeqTerms()
            {
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    FormKind = RuleForm(Line);
                    if(FormKind == 0 || FormKind == Invocation)
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

                    FormKind = RuleForm(Line);
                    if(FormKind == 0)
                        continue;

                    if(FormKind == RuleFormKind.EncodeStep || FormKind == RuleFormKind.DecodeStep)
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

                Table.Body = expressions.ToArray();
            }

            void ParseRuleDecl()
            {
                var ruledecl = text.trim(text.left(Line.Content, TableDeclSyntax));
                var i = text.index(ruledecl, Chars.Space);
                var name = EmptyString;
                if(i > 0)
                    name = text.right(ruledecl,i);
                else
                    name = ruledecl;
                Table.Sig = sig(DocKind,name);

                ParseRuleExpr();

                if(Skip.Contains(name))
                {
                    Table = RuleTable.Empty;
                    return;
                }

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