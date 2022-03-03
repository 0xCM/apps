//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    using K = XedRules.FieldKind;

    partial class XedRules
    {
        public class FieldParser
        {
            Symbols<FieldKind> Kinds;

            Symbols<XedRegId> Registers;

            RuleState State;

            DataList<FieldKind> _ParsedFields;

            DataList<Facet<string>> _UnknownFields;

            Dictionary<FieldKind, string> _Failures;

            public FieldParser()
            {
                Kinds = Symbols.index<FieldKind>();
                Registers = Symbols.index<XedRegId>();
                State = RuleState.Empty;
                _ParsedFields = new();
                _UnknownFields = new();
                _Failures = new();
            }

            void Clear()
            {
                State = RuleState.Empty;
                _ParsedFields.Clear();
                _UnknownFields.Clear();
                _Failures.Clear();
            }

            public ReadOnlySpan<Facet<string>> UnknownFields
                => _UnknownFields.View();

            public IReadOnlyDictionary<FieldKind,string> Failures
                => _Failures;

            public ReadOnlySpan<FieldKind> ParsedFields
                => _ParsedFields.View();

            public Outcome ParseRegister(string src, out XedRegId dst)
            {
                var result = Registers.Lookup(src, out var reg);
                if(result)
                    dst = reg.Kind;
                else
                {
                    if(src == "MM0")
                    {
                        dst = XedRegId.MMX0;
                        result = true;
                    }
                    else if(src == "MM1")
                    {
                        dst = XedRegId.MMX1;
                        result = true;
                    }
                    else if(src == "MM2")
                    {
                        dst = XedRegId.MMX2;
                        result = true;
                    }

                    dst = default;

                }
                return result;
            }

            public Outcome ParseInstOperand(string src, out InstOperand dst)
            {
                dst = default;
                if(text.length(src) < 3)
                    return (false,RP.Empty);
                var result = Outcome.Success;
                var data = span(src);

                var idx = text.trim(text.left(src,2));
                result = DataParser.parse(idx, out dst.Index);
                if(result.Fail)
                    return (false, string.Format("Parsing operand index from {0} failed", idx));

                var aspects = text.trim(text.right(src,2));
                var parts = text.split(aspects, Chars.FSlash);
                if(parts.Length != 6)
                {
                    result = (false, string.Format("Unexpected number of operand aspects in {0}", aspects));
                    return result;
                }

                var i=0;
                result = DataParser.eparse(skip(parts,i++), out dst.Kind);
                if(result.Fail)
                    return (false, string.Format("Parsing {0} from '{1}' failed", nameof(dst.Kind), skip(parts,i-1)));

                result = DataParser.eparse(skip(parts,i++), out dst.Action);
                if(result.Fail)
                    return result;

                result = DataParser.eparse(skip(parts,i++), out dst.WidthType);
                if(result.Fail)
                    return result;

                result = DataParser.eparse(skip(parts,i++), out dst.Visiblity);
                if(result.Fail)
                    return result;

                result = DataParser.eparse(skip(parts,i++), out dst.Lookup);
                if(result.Fail)
                    return result;

                result = DataParser.parse(skip(parts,i++), out dst.Prop2);
                if(result.Fail)
                    return result;

                return result;
            }

            public void ParseState(ReadOnlySpan<Facet<string>> src, out RuleState dst)
            {
                Clear();
                var count = src.Length;
                var dispwidth = 0u;
                var relbranch = Disp.Empty;
                var kind = K.INVALID;
                for(var i=0; i<count; i++)
                    kind = Parse(skip(src,i));
                dst = State;
            }

            K Parse(Facet<string> src)
            {
                var kind = K.INVALID;
                if(Kinds.Lookup(src.Key, out var k))
                {
                    var value = text.trim(src.Value);
                    kind = k.Kind;
                    var result = Parse(value, kind, ref State);
                    if(result.Fail)
                        _Failures[kind] = value;
                    else
                        _ParsedFields.Add(kind);
                }
                else
                    _UnknownFields.Add(src);
                return kind;
            }

            Outcome Parse(string src, FieldKind kind, ref RuleState state)
            {
                var result = Outcome.Success;
                switch(kind)
                {
                    case K.AGEN:
                        result = DataParser.parse(src, out state.AGENVal);
                    break;

                    case K.AMD3DNOW:
                        state.AMD3DNOW = bit.On;
                    break;

                    case K.ASZ:
                        state.ASZ = bit.On;
                    break;

                    case K.BASE0:
                        result = ParseRegister(src, out state.BASE0);
                    break;

                    case K.BASE1:
                        result = ParseRegister(src, out state.BASE1);
                    break;

                    case K.BCAST:
                        result = DataParser.eparse(src, out state.BCAST);
                    break;

                    case K.BCRC:
                        state.BCRC = bit.On;
                    break;

                    case K.RELBR:
                        result = Disp.parse(src, Sizes.native(state.BRDISP_WIDTH), out state.RELBR);
                    break;

                    case K.BRDISP_WIDTH:
                        result = DataParser.parse(src, out state.BRDISP_WIDTH);
                    break;

                    case K.CET:
                        state.CET = bit.On;
                    break;

                    case K.CHIP:
                        result = DataParser.eparse(src, out state.CHIP);
                    break;

                    case K.CLDEMOTE:
                        state.CLDEMOTE = bit.On;
                    break;

                    case K.DEFAULT_SEG:
                        result = DataParser.parse(src, out state.DEFAULT_SEG);
                    break;

                    case K.DF32:
                        state.DF32 = bit.On;
                    break;

                    case K.DF64:
                        state.DF64 = bit.On;
                    break;

                    case K.DISP:
                        result = Disp64.parse(src, out state.DISP);
                    break;

                    case K.DISP_WIDTH:
                        result = DataParser.parse(src, out state.DISP_WIDTH);
                    break;

                    case K.DUMMY:
                        state.DUMMY = bit.On;
                    break;

                    case K.EASZ:
                        result = DataParser.parse(src, out state.EASZ);
                    break;

                    case K.ELEMENT_SIZE:
                        result = DataParser.parse(src, out state.ELEMENT_SIZE);
                    break;

                    case K.ENCODER_PREFERRED:
                        state.ENCODER_PREFERRED = bit.On;
                    break;

                    case K.ENCODE_FORCE:
                        state.ENCODE_FORCE = bit.On;
                    break;

                    case K.EOSZ:
                        result = DataParser.parse(src, out state.EOSZ);
                    break;

                    case K.ESRC:
                        result = DataParser.parse(src, out state.ESRC);
                    break;

                    case K.FIRST_F2F3:
                        result = DataParser.parse(src, out state.FIRST_F2F3);
                    break;

                    case K.HAS_MODRM:
                        state.HAS_MODRM = bit.On;
                    break;

                    case K.HAS_SIB:
                        state.HAS_SIB = bit.On;
                    break;

                    case K.HINT:
                        result = DataParser.parse(src, out state.HINT);
                    break;

                    case K.ICLASS:
                        result = DataParser.eparse(src, out state.ICLASS);
                    break;

                    case K.ILD_F2:
                        state.ILD_F2 = bit.On;
                    break;

                    case K.ILD_F3:
                        state.ILD_F3 = bit.On;
                    break;

                    case K.ILD_SEG:
                        result = DataParser.parse(src, out state.ILD_SEG);
                    break;

                    case K.IMM0:
                        state.IMM0 = bit.On;
                    break;

                    case K.IMM0SIGNED:
                        state.IMM0SIGNED = bit.On;
                    break;

                    case K.IMM1:
                        state.IMM1 = bit.On;
                    break;

                    case K.IMM1_BYTES:
                        result = DataParser.parse(src, out state.IMM1_BYTES);
                    break;

                    case K.IMM_WIDTH:
                        result = DataParser.parse(src, out state.IMM_WIDTH);
                    break;

                    case K.INDEX:
                        result = ParseRegister(src, out state.INDEX);
                    break;

                    case K.LAST_F2F3:
                        result = DataParser.parse(src, out state.LAST_F2F3);
                    break;

                    case K.LLRC:
                        result = DataParser.parse(src, out state.LLRC);
                    break;

                    case K.LOCK:
                        state.LOCK = bit.On;
                    break;

                    case K.LZCNT:
                        state.LZCNT = bit.On;
                    break;

                    case K.MAP:
                        result = DataParser.parse(src, out state.MAP);
                    break;

                    case K.MASK:
                        result = DataParser.parse(src, out state.MASK);
                    break;

                    case K.MAX_BYTES:
                        result = DataParser.parse(src, out state.MAX_BYTES);
                    break;

                    case K.MEM0:
                        result = DataParser.parse(src, out state.MEM0Val);
                    break;

                    case K.MEM1:
                        result = DataParser.parse(src, out state.MEM1Val);
                    break;

                    case K.MEM_WIDTH:
                        result = DataParser.parse(src, out state.MEM_WIDTH);
                    break;

                    case K.MOD:
                        result = DataParser.parse(src, out state.MOD);
                    break;

                    case K.REG:
                        result = DataParser.parse(src, out state.REG);
                    break;

                    case K.MODRM_BYTE:
                        result = DataParser.parse(src, out byte modrm);
                        if(result)
                            state.MODRM_BYTE = modrm;
                    break;

                    case K.MODE:
                        result = DataParser.parse(src, out state.MODE);
                    break;

                    case K.MODEP5:
                        state.MODEP5 = bit.On;
                    break;

                    case K.MODEP55C:
                        state.MODEP55C = bit.On;
                    break;

                    case K.MODE_FIRST_PREFIX:
                        state.MODE_FIRST_PREFIX = bit.On;
                    break;

                    case K.MPXMODE:
                        state.MPXMODE = bit.On;
                    break;

                    case K.MUST_USE_EVEX:
                        state.MUST_USE_EVEX = bit.On;
                    break;

                    case K.NEEDREX:
                        state.NEEDREX = bit.On;
                    break;

                    case K.NEED_MEMDISP:
                        state.NEED_MEMDISP = bit.On;
                    break;

                    case K.NEED_SIB:
                        state.NEED_SIB = bit.On;
                    break;

                    case K.NELEM:
                        result = DataParser.parse(src, out state.NELEM);
                    break;

                    case K.NOMINAL_OPCODE:
                        result = DataParser.parse(src, out byte opcode);
                        if(result)
                            state.NOMINAL_OPCODE = opcode;
                    break;

                    case K.NOREX:
                        state.NOREX = bit.On;
                    break;

                    case K.NO_SCALE_DISP8:
                        state.NO_SCALE_DISP8 = bit.On;
                    break;

                    case K.NPREFIXES:
                        result = DataParser.parse(src, out state.NPREFIXES);
                    break;

                    case K.NREXES:
                        result = DataParser.parse(src, out state.NREXES);
                    break;

                    case K.NSEG_PREFIXES:
                        result = DataParser.parse(src, out state.NSEG_PREFIXES);
                    break;

                    case K.OSZ:
                        state.OSZ = bit.On;
                    break;

                    case K.OUT_OF_BYTES:
                        state.OUT_OF_BYTES = bit.On;
                    break;

                    case K.P4:
                        state.P4 = bit.On;
                    break;

                    case K.POS_DISP:
                        result = DataParser.parse(src, out state.POS_DISP);
                    break;

                    case K.POS_IMM:
                        result = DataParser.parse(src, out state.POS_IMM);
                    break;

                    case K.POS_IMM1:
                        result = DataParser.parse(src, out state.POS_IMM1);
                    break;

                    case K.POS_MODRM:
                        result = DataParser.parse(src, out state.POS_MODRM);
                    break;

                    case K.POS_NOMINAL_OPCODE:
                        result = DataParser.parse(src, out state.POS_NOMINAL_OPCODE);
                    break;

                    case K.POS_SIB:
                        result = DataParser.parse(src, out state.POS_SIB);
                    break;

                    case K.PREFIX66:
                        state.PREFIX66 = 1;
                    break;

                    case K.PTR:
                        state.PTR = 1;
                    break;

                    case K.REALMODE:
                        state.REALMODE = 1;
                    break;

                    case K.OUTREG:
                        result = ParseRegister(src, out state.OUTREG);
                    break;

                    case K.REG0:
                        result = ParseRegister(src, out state.REG0);
                    break;

                    case K.REG1:
                        result = ParseRegister(src, out state.REG1);
                    break;

                    case K.REG2:
                        result = ParseRegister(src, out state.REG2);
                    break;

                    case K.REG3:
                        result = ParseRegister(src, out state.REG3);
                    break;

                    case K.REG4:
                        result = ParseRegister(src, out state.REG4);
                    break;

                    case K.REG5:
                        result = ParseRegister(src, out state.REG5);
                    break;

                    case K.REG6:
                        result = ParseRegister(src, out state.REG6);
                    break;

                    case K.REG7:
                        result = ParseRegister(src, out state.REG7);
                    break;

                    case K.REG8:
                        result = ParseRegister(src, out state.REG8);
                    break;

                    case K.REG9:
                        result = ParseRegister(src, out state.REG9);
                    break;

                    case K.REP:
                        result = DataParser.parse(src, out state.REP);
                    break;

                    case K.REX:
                        state.REX = bit.On;
                    break;

                    case K.REXB:
                        state.REXB = 1;
                    break;

                    case K.REXR:
                        state.REXR = 1;
                    break;

                    case K.REXRR:
                        state.REXRR = 1;
                    break;

                    case K.REXW:
                        state.REXW = 1;
                    break;

                    case K.REXX:
                        state.REXX = 1;
                    break;

                    case K.RM:
                        result = DataParser.parse(src, out state.RM);
                    break;

                    case K.ROUNDC:
                        result = DataParser.parse(src, out state.ROUNDC);
                    break;

                    case K.SAE:
                        state.SAE = bit.On;
                    break;

                    case K.SCALE:
                        result = DataParser.parse(src, out state.SCALE);
                    break;

                    case K.SEG0:
                        result = ParseRegister(src, out state.SEG0);
                    break;

                    case K.SEG1:
                        result = ParseRegister(src, out state.SEG1);
                    break;

                    case K.SEG_OVD:
                        result = DataParser.parse(src, out state.SEG_OVD);
                    break;

                    case K.SIBBASE:
                        result = DataParser.parse(src, out state.SIBBASE);
                    break;

                    case K.SIBINDEX:
                        result = DataParser.parse(src, out state.SIBINDEX);
                    break;

                    case K.SIBSCALE:
                        result = DataParser.parse(src, out state.SIBSCALE);
                    break;

                    case K.SMODE:
                        result = DataParser.parse(src, out state.SMODE);
                        break;

                    case K.SRM:
                        result = DataParser.parse(src, out state.SRM);
                    break;

                    case K.TZCNT:
                        state.TZCNT = bit.On;
                    break;

                    case K.UBIT:
                        state.UBIT = bit.On;
                    break;

                    case K.UIMM0:
                        result = imm64.parse(src, out state.UIMM0);
                    break;

                    case K.UIMM1:
                        result = imm8.parse(src, out state.UIMM1);
                    break;

                    case K.USING_DEFAULT_SEGMENT0:
                        state.USING_DEFAULT_SEGMENT0 = bit.On;
                    break;

                    case K.USING_DEFAULT_SEGMENT1:
                        state.USING_DEFAULT_SEGMENT1 = bit.On;
                    break;

                    case K.VEXDEST210:
                        result = DataParser.parse(src, out state.VEXDEST210);
                    break;

                    case K.VEXDEST3:
                        state.VEXDEST3 = bit.On;
                    break;

                    case K.VEXDEST4:
                        state.VEXDEST4 = bit.On;
                    break;

                    case K.VEXVALID:
                        result = DataParser.parse(src, out state.VEXVALID);
                    break;

                    case K.VEX_C4:
                        state.VEX_C4 = bit.On;
                    break;

                    case K.VEX_PREFIX:
                        result = DataParser.parse(src, out state.VEX_PREFIX);
                    break;

                    case K.VL:
                        result = DataParser.parse(src, out state.VL);
                    break;

                    case K.WBNOINVD:
                        state.WBNOINVD = bit.On;
                    break;

                    case K.ZEROING:
                        state.ZEROING = bit.On;
                    break;
                }

                return result;
            }
        }
    }
}