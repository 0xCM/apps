//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedModels;
    using static XedRules;
    using static XedParsers;

    using K = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using R = XedRules;

    partial class XedRuleTables
    {
        public static bool parse(string src, out StatementSpec dst)
        {
            var input = normalize(src);
            var i = text.index(input,"=>");
            dst = StatementSpec.Empty;
            if(i > 0)
            {
                var left = text.trim(text.left(input, i));
                var premise = text.nonempty(left) ? cells(true, left) : Index<RuleCell>.Empty;
                var right = text.trim(text.right(input, i+1));
                var consequent = text.nonempty(right) ? cells(false, right) : Index<RuleCell>.Empty;
                if(premise.Count != 0 || consequent.Count != 0)
                    dst = new StatementSpec(premise,consequent);
            }
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(StatementSpec), src));

            return dst.IsNonEmpty;
        }

        static Index<RuleCell> cells(bool premise, string src)
        {
            var dst = list<RuleCell>();
            var input = text.trim(text.despace(src));
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
                            {
                                ref readonly var x = ref skip(expansions,k);
                                dst.Add(new (premise, x));
                            }
                        }
                        else
                            dst.Add(new (premise, expanded));
                    }
                    else
                        dst.Add(new (premise, part));
                }
            }
            else
            {
                if(RuleMacros.match(input, out var match))
                    dst.Add(new (premise, match.Expansion));
                else
                    dst.Add(new (premise, input));
            }
            return dst.ToArray();
        }

        static bool parse(bool premise, string input, out FieldKind fk, out RuleOperator op, out Nonterminal nt)
        {
            fk = 0;
            nt = Nonterminal.Empty;
            op = RuleOperator.None;
            var result = false;
            var i = text.index(input,"()");
            if(i > 0)
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
            else if(IsNonterminal(input))
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

        static Outcome parse(FieldKind field, string value, out R.FieldValue dst)
        {
            var result = Outcome.Success;
            dst = R.FieldValue.Empty;
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
                case K.BCAST:
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
                    if(XedParsers.reg(field, value, out dst))
                        result = true;
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
            var result = parse(field, value, out R.FieldValue z);
            dst = criterion(premise, op, z);
            return result;
        }
    }
}