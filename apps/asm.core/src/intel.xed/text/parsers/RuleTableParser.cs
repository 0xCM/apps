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
    using static XedModels;
    using static XedParsers;

    using K = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using RF = XedRules.RuleFormKind;
    using RI = XedRules.RuleTableSpec;

    partial class XedRules
    {
        public struct RuleTableParser
        {
            public static RuleTable table(RuleTableSpec src)
            {
                var body = list<RuleStatement>();
                for(var i=0; i<src.Statements.Count; i++)
                {
                    ref readonly var stmt = ref src.Statements[i];
                    if(stmt.IsNonEmpty)
                        body.Add(reify(stmt));
                }
                return new (src.Sig, body.ToArray());
            }

            public static RuleStatement reify(RI.StatementSpec src)
            {
                var left = list<RuleCriterion>();
                if(src.Premise.IsNonEmpty)
                    criteria(true, src.Premise.Delimit(Chars.Space).Format(), left);

                var right = list<RuleCriterion>();
                if(src.Consequent.IsNonEmpty)
                    criteria(false, src.Consequent.Delimit(Chars.Space).Format(), right);
                return new RuleStatement(left.ToArray(), right.ToArray());
            }

            public static Index<RuleTable> reify(ReadOnlySpan<RuleTableSpec> src)
            {
                var dst = alloc<RuleTable>(src.Length);
                for(var i=0; i<src.Length; i++)
                    seek(dst,i) = table(skip(src,i));
                return dst;
            }

            public static Index<RuleTableSpec> specs(FS.FilePath src)
            {
                var tmp = list<RuleTableSpec.StatementSpec>();
                const string TMP = "VEXED_REX";
                using var reader = src.Utf8LineReader();
                var counter = 0u;
                var dst = list<RuleTableSpec>();
                var tkind = XedPaths.tablekind(src.FileName);
                var statements =list<RuleTableSpec.StatementSpec>();
                var name = EmptyString;
                while(reader.Next(out var line))
                {
                    if(form(line.Content) == RuleFormKind.SeqDecl)
                        SkipSeq(reader);

                    var content = text.trim(text.despace(line.Content));
                    if(text.empty(content) || text.begins(content, Chars.Hash))
                        continue;

                    if(text.ends(content, "()::"))
                    {
                        if(counter != 0)
                        {
                            if(name == TMP)
                                tmp.AddRange(statements.ToArray());
                            else
                                dst.Add(new (sig(tkind, name), statements.ToArray()));

                            statements.Clear();
                        }

                        name = text.remove(content,"()::");
                        var i = text.index(name,Chars.Space);
                        if(i > 0)
                            name = text.right(name,i);
                        counter++;
                    }
                    else
                    {
                        if(spec(content, out RI.StatementSpec s))
                            statements.Add(s);
                    }
                }

                if(tmp.Count != 0)
                    dst.Add(new (sig(tkind, TMP), tmp.ToArray()));
                return dst.ToArray().Sort();
            }

            public static Index<RuleTable> tables(FS.FilePath src)
                => reify(specs(src));

            static bool spec(string src, out RI.StatementSpec dst)
            {
                var input = normalize(src);
                var i = text.index(input,"=>");
                dst = RI.StatementSpec.Empty;
                if(i > 0)
                {
                    var pcells = list<RuleCell>();
                    var premise = map(text.split(text.left(input,i), Chars.Space),RuleMacros.expand);
                    for(var j=0; j<premise.Length; j++)
                    {
                        ref readonly var x = ref skip(premise,j);
                        pcells.Add(new RuleCell(XedFields.kind(x),x));
                    }

                    var ccells = list<RuleCell>();
                    var consequent = map(text.split(text.right(input,i + 1), Chars.Space),RuleMacros.expand);
                    for(var j=0; j<consequent.Length; j++)
                    {
                        ref readonly var x = ref skip(consequent,j);
                        ccells.Add(new RuleCell(XedFields.kind(x),x));
                    }

                    if(ccells.Count !=0 && pcells.Count != 0)
                        dst = new RI.StatementSpec(pcells.ToArray(), ccells.ToArray());
                }

                return dst.IsNonEmpty;

                static string normalize(string src)
                {
                    var dst = EmptyString;
                    var i = text.index(src, Chars.Hash);
                    if(i>0)
                        dst = text.despace(text.trim(text.left(src,i)));
                    else
                        dst = text.despace(text.trim(src));
                    return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
                }
            }

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, FieldKind fk, asci8 value, CellDataKind dk)
                => new RuleCriterion(premise, fk, RuleOperator.None,  value, dk);

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, RuleCall call)
                => new RuleCriterion(premise, call);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion<T>(bool premise, FieldKind field, RuleOperator op, T value)
                where T : unmanaged
                    => new RuleCriterion(premise, field, op, core.bw64(value));

            [MethodImpl(Inline), Op]
            static RuleCriterion criterion(bool premise, FieldKind fk, RuleOperator op, Nonterminal nt)
                => new RuleCriterion(premise, fk, op, nt);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion(bool premise, BitfieldSeg seg)
                => new RuleCriterion(premise, seg);

            [MethodImpl(Inline), Op, Closures(Closure)]
            static RuleCriterion criterion(bool premise, BitfieldSpec src)
                => new RuleCriterion(premise, src);


            static void criteria(bool premise, string src, List<RuleCriterion> dst)
            {
                var parts = text.trim(text.split(src, Chars.Space)).Where(x => nonempty(x) && !Skip.Contains(x));
                var count = parts.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(parts, i);
                    var result = parse(premise, part, out var c);
                    if(result.Fail)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), part));

                    dst.Add(c);
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

            static bool parse(bool premise, string input, out FieldKind fk, out RuleOperator op, out Nonterminal nt)
            {
                fk = 0;
                nt = Nonterminal.Empty;
                op = RuleOperator.None;
                var result = false;
                var i = text.index(input,"()");
                if(i >0)
                {
                    if(assignment(premise, text.left(input,i), out fk, out var fv))
                    {
                        if(XedParsers.parse(fv, out nt))
                        {
                            result = true;
                            op = RuleOperator.Assign;
                        }
                    }
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

            static Outcome parse(bool premise, string spec, out RuleCriterion dst)
            {
                var input = text.trim(text.despace(spec));
                var fk = K.INVALID;
                var op = RO.None;
                var fv = input;
                var i = -1;
                dst = RuleCriterion.Empty;
                if(parse(premise, spec, out fk, out op, out Nonterminal nt))
                {
                    dst = criterion(premise, fk, op, nt);
                    return true;
                }
                else if(IsCall(input))
                {
                    var name = text.remove(input,"()");
                    parse(premise, name, out fk, out fv, out op);
                    dst = criterion(premise, call(fk, op, text.ifempty(fv,name)));
                    return true;
                }
                else if(assignment(premise, input, out fk, out fv))
                {
                    if(parse(premise, fk, RO.Assign, fv, out dst))
                        return true;
                    return false;
                }
                else if(notequal(premise, input, out fk, out fv))
                {
                    if(parse(premise, fk, RO.CmpNeq, fv, out dst))
                        return true;
                    return false;
                }
                else if(IsBfSeg(input))
                {
                    var result = XedParsers.parse(input, out BitfieldSeg seg);
                    if(result)
                         dst = criterion(premise, seg);
                    return result;
                }
                else if(IsBfSpec(input))
                {
                    dst = criterion(premise,new BitfieldSpec(input));
                    return true;
                }
                else
                {
                    if(input.Length > 8)
                        Errors.Throw(string.Format("The value '{0}' is too long to be a literal", input));
                    dst = literal(premise,input);
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
                        else
                        {
                            if(XedParsers.parse(value, out Nonterminal nt))
                            {
                                dst = criterion(premise, field, op, nt);
                                result = true;
                            }
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

            public static RF form(string src)
            {
                var i = text.index(src, Chars.Hash);
                var content = (i> 0 ? text.left(src,i) : src).Trim();
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
                FormKind = form(Line.Content);
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

            static void SkipSeq(LineReader reader)
            {
                while(reader.Next(out var line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash))
                        continue;

                    var kind = form(line.Content);
                    if(kind == 0 || kind == Invocation)
                        continue;
                    else
                        break;
                }
            }

            void ParseSeqTerms()
            {
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    FormKind = form(Line.Content);
                    if(FormKind == 0 || FormKind == Invocation)
                        continue;
                    else
                        break;
                }
            }

            void ParseStatements()
            {
                var expressions = list<RuleStatement>();
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    FormKind = form(Line.Content);
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
                            expressions.Add(statement(parts[0], parts[1]));
                        else if(parts.Length == 1)
                            expressions.Add(statement(parts[0], EmptyString));
                        else
                            Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleStatement), content));
                    }
                    else
                        break;
                }

                Table.Body = expressions.ToArray();

                static RuleStatement statement(string premise, string consequent)
                {
                    var buffer = list<RuleCriterion>();

                    if(nonempty(premise))
                        criteria(true, RuleMacros.expand(premise), buffer);

                    var left = buffer.ToArray();
                    buffer.Clear();

                    if(nonempty(consequent))
                        criteria(false, RuleMacros.expand(consequent), buffer);

                    var right = buffer.ToArray();
                    return new RuleStatement(left, right);
                }
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

                ParseStatements();

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