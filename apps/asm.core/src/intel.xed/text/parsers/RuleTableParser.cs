//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedRules.RuleFormKind;
    using static XedModels;
    using static XedParsers;

    using K = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using RF = XedRules.RuleFormKind;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(bool premise, FieldLiteral literal)
            => new RuleCriterion(premise, literal);

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

        [MethodImpl(Inline), Op]
        static RuleCriterion criterion(bool premise, RuleOperator op, FieldValue src)
            => new RuleCriterion(premise,src.Field, op, src.Data);

        public struct RuleTableParser
        {
            public static RuleTable reify(RuleTableSpec src)
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

            static Index<RuleCriterion> criteria(bool premise, ReadOnlySpan<RuleCell> src)
            {
                var dst = list<RuleCriterion>();
                var parts = map(src, p => p.Format());
                for(var i=0; i<parts.Length; i++)
                {
                    ref readonly var part = ref skip(parts, i);
                    var result = parse(premise, part, out var c);
                    if(!result)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), part));

                    dst.Add(c);
                }
                return dst.ToArray();
            }

            public static Index<RuleCriterion> premise(StatementSpec src)
                => criteria(true, src.Premise.View);

            public static Index<RuleCriterion> consequent(StatementSpec src)
                => criteria(false, src.Consequent.View);

            public static RuleStatement reify(StatementSpec src)
            {
                var left = sys.empty<RuleCriterion>();
                if(src.Premise.IsNonEmpty)
                    left = premise(src);

                var right = sys.empty<RuleCriterion>();
                if(src.Consequent.IsNonEmpty)
                    right = consequent(src);

                return new RuleStatement(left, right);
            }

            public static Index<RuleTable> reify(ReadOnlySpan<RuleTableSpec> src)
            {
                var dst = alloc<RuleTable>(src.Length);
                for(var i=0; i<src.Length; i++)
                    seek(dst,i) = reify(skip(src,i));
                return dst;
            }

            public static Index<RuleTableSpec> specs(FS.FilePath src)
            {
                using var reader = src.Utf8LineReader();
                var counter = 0u;
                var dst = list<RuleTableSpec>();
                var tkind = XedPaths.tablekind(src.FileName);
                var statements =list<StatementSpec>();
                var name = EmptyString;
                while(reader.Next(out var line))
                {
                    if(form(line.Content) == RuleFormKind.SeqDecl)
                    {
                        while(reader.Next(out line))
                            if(line.IsEmpty)
                                break;
                        continue;
                    }

                    var content = text.trim(text.despace(line.Content));
                    if(text.empty(content) || text.begins(content, Chars.Hash))
                        continue;

                    var k = text.index(content,Chars.Hash);
                    if(k > 0)
                        content = text.trim(text.left(content,k));

                    if(text.ends(content, "()::"))
                    {
                        if(counter != 0)
                        {
                            if(!Skip.Contains(name))
                                dst.Add(new (sig(tkind, name), statements.ToArray()));

                            statements.Clear();
                        }

                        name = text.remove(content,"()::");
                        var i = text.index(name, Chars.Space);
                        if(i > 0)
                            name = text.right(name,i);
                        counter++;
                    }
                    else
                    {
                        if(parse(content, out StatementSpec s))
                            statements.Add(s);
                    }
                }

                return dst.ToArray().Sort();
            }

            static Index<RuleCell> cells(string src)
            {
                var dst = list<RuleCell>();
                if(text.contains(src, Chars.Space))
                {
                    var parts = text.split(src, Chars.Space);
                    var count = parts.Length;
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var part = ref skip(parts,j);
                        Require.nonempty(part);
                        var x = RuleMacros.expand(part);
                        if(empty(x))
                            Errors.Throw(string.Format("Macro expansion obliterated '{0}'", part));
                        dst.Add(new (XedFields.kind(x), x));
                    }
                }
                else
                {
                    dst.Add(new (XedFields.kind(src),src));
                }
                return dst.ToArray();
            }

            public static bool parse(string src, out StatementSpec dst)
            {
                var input = normalize(src);
                var i = text.index(input,"=>");
                dst = StatementSpec.Empty;
                if(i > 0)
                {
                    var pcells = cells(text.trim(text.left(input, i)));
                    var ccells = cells(text.trim(text.right(input, i+1)));
                    if(ccells.Count !=0 && pcells.Count != 0)
                        dst = new StatementSpec(pcells, ccells);
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(StatementSpec), src));

                return dst.IsNonEmpty;
            }

            static string normalize(string src)
            {
                var dst = EmptyString;
                var i = text.index(src, Chars.Hash);
                if(i>0)
                    dst = text.despace(text.trim(text.left(src, i)));
                else
                    dst = text.despace(text.trim(src));
                if(dst == "otherwise")
                    return "else";
                else if(dst == "nothing")
                    return "null";
                else
                    return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
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
                var result = IsAssignment(input);
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

            static bool notequal(string input, out FieldKind fk, out string fv)
            {
                fk = 0;
                fv = EmptyString;
                var result = IsCmpNeq(input);
                if(result)
                {
                    var i = text.index(input, "!=");
                    fv = text.right(input, i + 1);
                    result = XedParsers.parse(text.left(input, i), out fk);
                }
                return result;
            }

            static bool parse(bool premise, string spec, out RuleCriterion dst)
            {
                var input = normalize(spec);
                var fk = K.INVALID;
                var op = RO.None;
                var fv = input;
                var i = -1;
                dst = RuleCriterion.Empty;
                var result = false;

                if(parse(premise, spec, out fk, out op, out Nonterminal nt))
                {
                    dst = criterion(premise, fk, op, nt);
                    result = true;
                }
                else if(IsCall(input))
                {
                    var name = text.remove(input,"()");
                    parse(premise, name, out fk, out fv, out op);
                    dst = criterion(premise, call(fk, op, text.ifempty(fv,name)));
                    result = true;
                }
                else if(assignment(premise, input, out fk, out fv))
                {
                    if(parse(premise, fk, RO.Assign, fv, out dst))
                        result = true;
                }
                else if(notequal(input, out fk, out fv))
                {
                    if(parse(premise, fk, RO.CmpNeq, fv, out dst))
                        result = true;
                }
                else if(IsBfSeg(input))
                {
                    if(XedParsers.parse(input, out BitfieldSeg seg))
                    {
                         dst = criterion(premise, seg);
                        result = true;
                    }
                }
                else if(IsBfSpec(input))
                {
                    dst = criterion(premise,new BitfieldSpec(input));
                    result = true;
                }
                else
                {
                    result = XedParsers.parse(input, out FieldLiteral literal);
                    if(result)
                        dst = literal.ToCriterion(premise);
                }
                return result;
            }

            public static Outcome parse(FieldKind field, string value, out FieldValue dst)
            {
                var result = Outcome.Success;
                dst = FieldValue.Empty;
                switch(field)
                {
                    case K.REXW:
                    {
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = new (field,b);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'w')
                        {
                            dst = new BitfieldSeg(field, value[0], false);
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
                            dst = new BitfieldSeg(field, value[0], false);
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
                            dst = new BitfieldSeg(field, value[0], false);
                            result = true;
                        }
                    }
                    break;
                    case K.REXB:
                    {
                        if(XedParsers.parse(value, out bit b))
                        {
                            dst = new (field,b);
                            result = true;
                        }
                        else if(value.Length == 1 && value[0] == 'b')
                        {
                            dst = new BitfieldSeg(field, value[0], false);
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
                        if(XedParsers.parse(value, out byte b))
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
                    {
                        if(XedParsers.parse(value, out byte b))
                        {
                            dst = new (field,b);
                            result = true;
                        }
                    }
                    break;

                    case K.MAP:
                    case K.NELEM:
                    case K.SCALE:
                    {
                        if(XedParsers.parse(value, out byte b))
                        {
                            dst = new (field,b);
                            result = true;
                        }
                    }
                    break;

                    case K.BCAST:
                    {
                        if(XedParsers.parse(value, out byte b))
                        {
                            dst = new (field,b);
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
                        if(XedParsers.parse(value, out byte b))
                        {
                            dst = new (field,b);
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

                    case K.RM:
                    {
                        if(XedParsers.parse(value, out byte b))
                        {
                            dst = new (field,b);
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
                            dst = new (field,x);
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
                            result = XedParsers.parse(value, out DispFieldSpec disp);
                            if(result)
                                dst = new (field,disp);
                        }
                    }
                    break;

                    case K.UIMM1:
                    case K.UIMM0:
                    {
                        result = XedParsers.parse(value, out ImmFieldSpec imm);
                        dst = new (field,imm);
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
                            dst = new (field, reg);
                            result = true;
                        }
                        else
                        {
                            if(XedParsers.parse(value, out Nonterminal nt))
                            {
                                dst = new(field,nt);
                                result = true;
                            }
                        }
                    }
                    break;
                    case K.CHIP:
                    {
                        if(XedParsers.parse(value, out ChipCode chip))
                        {
                            dst = new (field, (ushort)chip);
                            result = true;
                        }
                    }
                    break;

                    case K.ERROR:
                    {
                        if(XedParsers.parse(value, out ErrorKind error))
                        {
                            dst = new (field, (ushort)error);
                            result = true;
                        }
                    }
                    break;

                    case K.ICLASS:
                    {
                        if(XedParsers.parse(value, out IClass @class))
                        {
                            dst = new (field, (ushort)@class);
                            result = true;
                        }
                    }
                    break;
                }

                return result;
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
                            dst = criterion(premise, new BitfieldSeg(field, value[0], false));
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
                        result = parse(field, value, out FieldValue z);
                        if(result)
                            dst = criterion(premise, op, z);
                    break;
                }
                // switch(field)
                // {
                //     case K.MOD:
                //     case K.SIBSCALE:
                //     case K.EASZ:
                //     case K.EOSZ:
                //     case K.FIRST_F2F3:
                //     case K.LAST_F2F3:
                //     case K.DEFAULT_SEG:
                //     case K.MODE:
                //     case K.REP:
                //     case K.SMODE:
                //     case K.VEX_PREFIX:
                //     case K.VL:
                //     case K.LLRC:
                //     {
                //         if(XedParsers.parse(value, out byte x))
                //         {
                //             dst = criterion(premise, field, op, x);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.SIBBASE:
                //     case K.HINT:
                //     case K.ROUNDC:
                //     case K.SEG_OVD:
                //     case K.VEXVALID:
                //     {
                //         if(XedParsers.parse(value, out byte u8))
                //         {
                //             dst = criterion(premise, field, op, u8);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.MAP:
                //     case K.NELEM:
                //     case K.SCALE:
                //     {
                //         if(XedParsers.parse(value, out byte u8))
                //         {
                //             dst = criterion(premise, field, op, u8);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.BCAST:
                //     {
                //         if(XedParsers.parse(value, out byte u8))
                //         {
                //             dst = criterion(premise, field, op, u8);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.BRDISP_WIDTH:
                //     case K.DISP_WIDTH:
                //     case K.ILD_SEG:
                //     case K.IMM1_BYTES:
                //     case K.IMM_WIDTH:
                //     case K.MAX_BYTES:
                //     case K.MODRM_BYTE:
                //     case K.NPREFIXES:
                //     case K.NREXES:
                //     case K.NSEG_PREFIXES:
                //     case K.POS_DISP:
                //     case K.POS_IMM:
                //     case K.POS_IMM1:
                //     case K.POS_MODRM:
                //     case K.POS_NOMINAL_OPCODE:
                //     case K.POS_SIB:
                //     case K.NEED_MEMDISP:
                //     {
                //         if(XedParsers.parse(value, out byte u8))
                //         {
                //             dst = criterion(premise, field, op, u8);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.ELEMENT_SIZE:
                //     case K.MEM_WIDTH:
                //     {
                //         if(ushort.TryParse(value, out ushort u8))
                //         {
                //             dst = criterion(premise, field, op, u8);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.RM:
                //     {
                //         if(XedParsers.parse(value, out byte u8))
                //         {
                //             dst = criterion(premise, field, op, u8);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.SIBINDEX:
                //     case K.REG:
                //     case K.VEXDEST210:
                //     case K.MASK:
                //     case K.SRM:
                //     {
                //         if(XedParsers.parse(value, out byte x))
                //         {
                //             dst = criterion(premise, field, op, x);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.ESRC:
                //     {
                //         if(DataParser.parse(value, out Hex4 x))
                //         {
                //             dst = criterion(premise, field, op, x);
                //             result = true;
                //         }
                //     }
                //     break;


                //     case K.NOMINAL_OPCODE:
                //     {
                //         if(DataParser.parse(value, out Hex8 hex))
                //         {
                //             dst = criterion(premise, field, op, hex);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.DISP:
                //     {
                //         result = byte.TryParse(value, out byte x);
                //         if(result)
                //             dst = criterion(premise,field,op,x);
                //         else
                //         {
                //             result = XedParsers.parse(value, out DispFieldSpec disp);
                //             if(result)
                //                 dst = criterion(premise, field, op, disp);
                //         }
                //     }
                //     break;

                //     case K.UIMM1:
                //     case K.UIMM0:
                //     {
                //         result = XedParsers.parse(value, out ImmFieldSpec imm);
                //         dst = criterion(premise, field, op, imm);
                //     }
                //     break;

                //     case K.BASE0:
                //     case K.BASE1:
                //     case K.INDEX:
                //     case K.OUTREG:
                //     case K.SEG0:
                //     case K.SEG1:
                //     case K.REG0:
                //     case K.REG1:
                //     case K.REG2:
                //     case K.REG3:
                //     case K.REG4:
                //     case K.REG5:
                //     case K.REG6:
                //     case K.REG7:
                //     case K.REG8:
                //     case K.REG9:
                //     {
                //         if(XedParsers.parse(value, out XedRegId reg))
                //         {
                //             dst = criterion(premise, field, op, reg);
                //             result = true;
                //         }
                //         else
                //         {
                //             if(XedParsers.parse(value, out Nonterminal nt))
                //             {
                //                 dst = criterion(premise, field, op, nt);
                //                 result = true;
                //             }
                //         }
                //     }
                //     break;
                //     case K.CHIP:
                //     {
                //         if(XedParsers.parse(value, out ChipCode chip))
                //         {
                //             dst = criterion(premise, field, op, chip);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.ERROR:
                //     {
                //         if(XedParsers.parse(value, out ErrorKind error))
                //         {
                //             dst = criterion(premise, field, op, error);
                //             result = true;
                //         }
                //     }
                //     break;

                //     case K.ICLASS:
                //     {
                //         if(XedParsers.parse(value, out IClass @class))
                //         {
                //             dst = criterion(premise, field, op, @class);
                //             result = true;
                //         }
                //     }
                //     break;

                //     default:
                //         break;
                // }

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

            public RuleTableParser()
            {

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

            static HashSet<string> Skip;

            static RuleTableParser()
            {
                Skip = hashset("VEXED_REX", "XED_RESET");
            }
        }
    }
}