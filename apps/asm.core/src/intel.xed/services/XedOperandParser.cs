//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static core;
    using static XedModels;

    using K = XedModels.OperandKind;

    public class XedOperandParser
    {
        Symbols<OperandKind> Kinds;

        Symbols<RegId> Registers;

        OperandState State;

        DataList<OperandKind> _ParsedKinds;

        DataList<Facet<string>> _UnknownFields;

        Dictionary<OperandKind, string> _Failures;

        public XedOperandParser()
        {
            Kinds = Symbols.index<OperandKind>();
            Registers = Symbols.index<RegId>();
            State = OperandState.Empty;
            _ParsedKinds = new();
            _UnknownFields = new();
            _Failures = new();
        }

        void Clear()
        {
            State = OperandState.Empty;
            _ParsedKinds.Clear();
            _UnknownFields.Clear();
            _Failures.Clear();
        }

        public ReadOnlySpan<Facet<string>> UnknownFields
            => _UnknownFields.View();

        public IReadOnlyDictionary<OperandKind,string> Failures
            => _Failures;

        public ReadOnlySpan<OperandKind> ParsedFields
            => _ParsedKinds.View();

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

        public void ParseState(ReadOnlySpan<Facet<string>> src, out OperandState dst)
        {
            Clear();
            var count = src.Length;
            for(var i=0; i<count; i++)
                Parse(skip(src,i));
            dst = State;
        }

        void Parse(in Facet<string> src)
        {
            if(Kinds.Lookup(src.Key, out var k))
                Parse(src.Value, k.Kind);
            else
                _UnknownFields.Add(src);
        }

        void Parse(string src, OperandKind kind)
        {
            var value = text.trim(src);
            var result = Outcome.Success;
            switch(kind)
            {
                case K.AGEN:
                    result = DataParser.parse(value, out State.agen);
                break;

                case K.AMD3DNOW:
                    State.amd3dnow = bit.On;
                break;

                case K.ASZ:
                    State.asz = bit.On;
                break;

                case K.BASE0:
                    result = Parse(value, out State.base0);
                break;

                case K.BASE1:
                    result = Parse(value, out State.base1);
                break;

                case K.BCAST:
                    result = DataParser.eparse(value, out State.bcast);
                break;

                case K.BCRC:
                    State.bcrc = bit.On;
                break;

                case K.BRDISP_WIDTH:
                    result = DataParser.parse(value, out State.brdisp_width);
                break;

                case K.CET:
                    State.cet = bit.On;
                break;

                case K.CHIP:
                    result = DataParser.eparse(value, out State.chip);
                break;

                case K.CLDEMOTE:
                    State.cldemote = bit.On;
                break;

                case K.DEFAULT_SEG:
                    result = DataParser.parse(value, out State.default_seg);
                break;

                case K.DF32:
                    State.df32 = bit.On;
                break;

                case K.DF64:
                    State.df64 = bit.On;
                break;

                case K.DISP:
                    result = DataParser.parse(value, out State.disp);
                break;

                case K.DISP_WIDTH:
                    result = DataParser.parse(value, out State.disp_width);
                break;

                case K.DUMMY:
                    State.dummy = bit.On;
                break;

                case K.EASZ:
                    result = DataParser.eparse(value, out State.easz);
                break;

                case K.ELEMENT_SIZE:
                    result = DataParser.parse(value, out State.element_size);
                break;

                case K.ENCODER_PREFERRED:
                    State.encoder_preferred = bit.On;
                break;

                case K.ENCODE_FORCE:
                    State.encode_force = bit.On;
                break;

                case K.EOSZ:
                    result = DataParser.eparse(value, out State.eosz);
                break;

                case K.ESRC:
                    result = DataParser.parse(value, out State.esrc);
                break;

                case K.FIRST_F2F3:
                    result = DataParser.parse(value, out State.first_f2f3);
                break;

                case K.HAS_MODRM:
                    State.has_modrm = bit.On;
                break;

                case K.HAS_SIB:
                    State.has_sib = bit.On;
                break;

                case K.HINT:
                    result = DataParser.eparse(value, out State.iclass);
                break;

                case K.ICLASS:
                    result = DataParser.eparse(value, out State.iclass);
                break;

                case K.ILD_F2:
                    State.ild_f2 = bit.On;
                break;

                case K.ILD_F3:
                    State.ild_f3 = bit.On;
                break;

                case K.ILD_SEG:
                    result = DataParser.parse(value, out State.ild_seg);
                break;

                case K.IMM0:
                    State.imm0 = bit.On;
                break;

                case K.IMM0SIGNED:
                    State.imm0signed = bit.On;
                break;

                case K.IMM1:
                    State.imm1 = bit.On;
                break;

                case K.IMM1_BYTES:
                    result = DataParser.parse(value, out State.imm1_bytes);
                break;

                case K.IMM_WIDTH:
                    result = DataParser.parse(value, out State.imm_width);
                break;

                case K.INDEX:
                    result = Parse(value, out State.index);
                break;

                case K.LAST_F2F3:
                    result = DataParser.parse(value, out State.last_f2f3);
                break;

                case K.LLRC:
                    result = DataParser.parse(value, out State.llrc);
                break;

                case K.LOCK:
                    State.@lock = bit.On;
                break;

                case K.LZCNT:
                    State.lzcnt = bit.On;
                break;

                case K.MAP:
                    result = DataParser.parse(value, out State.map);
                break;

                case K.MASK:
                    result = DataParser.parse(value, out State.mask);
                break;

                case K.MAX_BYTES:
                    result = DataParser.parse(value, out State.max_bytes);
                break;

                case K.MEM0:
                    result = DataParser.parse(value, out State.mem0);
                break;

                case K.MEM1:
                    result = DataParser.parse(value, out State.mem1);
                break;

                case K.MEM_WIDTH:
                    result = DataParser.parse(value, out State.mem_width);
                break;

                case K.MOD:
                    result = DataParser.parse(value, out State.mod);
                break;

                case K.MODE:
                    result = DataParser.eparse(value, out State.mode);
                break;

                case K.MODEP5:
                    State.modep5 = bit.On;
                break;

                case K.MODEP55C:
                    State.modep55c = bit.On;
                break;

                case K.MODE_FIRST_PREFIX:
                    State.mode_first_prefix = bit.On;
                break;

                case K.MODRM_BYTE:
                    result = DataParser.parse(value, out byte modrm);
                    if(result)
                        State.modrm_byte = modrm;
                break;

                case K.MPXMODE:
                    State.mpxmode = bit.On;
                break;

                case K.MUST_USE_EVEX:
                    State.must_use_evex = bit.On;
                break;

                case K.NEEDREX:
                    State.needrex = bit.On;
                break;

                case K.NEED_MEMDISP:
                    State.need_memdisp = bit.On;
                break;

                case K.NEED_SIB:
                    State.need_sib = bit.On;
                break;

                case K.NELEM:
                    result = DataParser.parse(value, out State.nelem);
                break;

                case K.NOMINAL_OPCODE:
                    result = DataParser.parse(value, out byte opcode);
                    if(result)
                        State.nominal_opcode = opcode;
                break;

                case K.NOREX:
                    State.norex = bit.On;
                break;

                case K.NO_SCALE_DISP8:
                    State.no_scale_disp8 = bit.On;
                break;

                case K.NPREFIXES:
                    result = DataParser.parse(value, out State.nprefixes);
                break;

                case K.NREXES:
                    result = DataParser.parse(value, out State.nrexes);
                break;

                case K.NSEG_PREFIXES:
                    result = DataParser.parse(value, out State.nseg_prefixes);
                break;

                case K.OSZ:
                    State.osz = bit.On;
                break;

                case K.OUTREG:
                    result = Parse(value, out State.outreg);
                break;

                case K.OUT_OF_BYTES:
                    State.out_of_bytes = bit.On;
                break;

                case K.P4:
                    State.p4 = bit.On;
                break;

                case K.POS_DISP:
                    result = DataParser.parse(value, out State.pos_disp);
                break;

                case K.POS_IMM:
                    result = DataParser.parse(value, out State.pos_imm);
                break;

                case K.POS_IMM1:
                    result = DataParser.parse(value, out State.pos_imm1);
                break;

                case K.POS_MODRM:
                    result = DataParser.parse(value, out State.pos_modrm);
                break;

                case K.POS_NOMINAL_OPCODE:
                    result = DataParser.parse(value, out State.pos_nominal_opcode);
                break;

                case K.POS_SIB:
                    result = DataParser.parse(value, out State.pos_sib);
                break;

                case K.PREFIX66:
                    State.prefix66 = bit.On;
                break;

                case K.PTR:
                    State.ptr = bit.On;
                break;

                case K.REALMODE:
                    State.realmode = bit.On;
                break;

                case K.REG:
                    result = DataParser.parse(value, out State.reg);
                break;

                case K.REG0:
                    result = Parse(value, out State.reg0);
                break;

                case K.REG1:
                    result = Parse(value, out State.reg1);
                break;

                case K.REG2:
                    result = Parse(value, out State.reg2);
                break;

                case K.REG3:
                    result = Parse(value, out State.reg3);
                break;

                case K.REG4:
                    result = Parse(value, out State.reg4);
                break;

                case K.REG5:
                    result = Parse(value, out State.reg5);
                break;

                case K.REG6:
                    result = Parse(value, out State.reg6);
                break;

                case K.REG7:
                    result = Parse(value, out State.reg7);
                break;

                case K.REG8:
                    result = Parse(value, out State.reg8);
                break;

                case K.REG9:
                    result = Parse(value, out State.reg9);
                break;

                case K.RELBR:
                    State.relbr = bit.On;
                break;

                case K.REP:
                    result = DataParser.parse(value, out State.rep);
                break;

                case K.REX:
                    State.rex = bit.On;
                break;

                case K.REXB:
                    State.rexb = bit.On;
                break;

                case K.REXR:
                    State.rexr = bit.On;
                break;

                case K.REXRR:
                    State.rexrr = bit.On;
                break;

                case K.REXW:
                    State.rexw = bit.On;
                break;

                case K.REXX:
                    State.rexx = bit.On;
                break;

                case K.RM:
                    result = DataParser.parse(value, out State.rm);
                break;

                case K.ROUNDC:
                    result = DataParser.parse(value, out State.roundc);
                break;

                case K.SAE:
                    State.sae = bit.On;
                break;

                case K.SCALE:
                    result = DataParser.parse(value, out State.scale);
                break;

                case K.SEG0:
                    result = Parse(value, out State.seg0);
                break;

                case K.SEG1:
                    result = Parse(value, out State.seg1);
                break;

                case K.SEG_OVD:
                    result = DataParser.parse(value, out State.seg_ovd);
                break;

                case K.SIBBASE:
                    result = DataParser.parse(value, out State.sibbase);
                break;

                case K.SIBINDEX:
                    result = DataParser.parse(value, out State.sibindex);
                break;

                case K.SIBSCALE:
                    result = DataParser.parse(value, out State.sibscale);
                break;

                case K.SMODE:
                    result = DataParser.eparse(value, out State.smode);
                    break;

                case K.SRM:
                    result = DataParser.parse(value, out State.srm);
                break;

                case K.TZCNT:
                    State.tzcnt = bit.On;
                break;

                case K.UBIT:
                    State.ubit = bit.On;
                break;

                case K.UIMM0:
                    result = DataParser.parse(value, out State.uimm0);
                break;

                case K.UIMM1:
                    result = DataParser.parse(value, out State.uimm1);
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    State.using_default_segment0 = bit.On;
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    State.using_default_segment1 = bit.On;
                break;

                case K.VEXDEST210:
                    result = DataParser.parse(value, out State.vexdest210);
                break;

                case K.VEXDEST3:
                    State.vexdest3 = bit.On;
                break;

                case K.VEXDEST4:
                    State.vexdest4 = bit.On;
                break;

                case K.VEXVALID:
                    result = DataParser.eparse(value, out State.vexvalid);
                break;

                case K.VEX_C4:
                    State.vex_c4 = bit.On;
                break;

                case K.VEX_PREFIX:
                    result = DataParser.eparse(value, out State.vex_prefix);
                break;

                case K.VL:
                    result = DataParser.eparse(value, out State.vl);
                break;

                case K.WBNOINVD:
                    State.wbnoinvd = bit.On;
                break;

                case K.ZEROING:
                    State.zeroing = bit.On;
                break;
            }

            if(result.Fail)
                _Failures[kind] = value;
            else
                _ParsedKinds.Add(kind);
        }

        Outcome Parse(string src, out Register dst)
        {
            var result = Registers.Lookup(src, out var reg);
            if(result)
                dst = reg.Kind;
            else
                dst = default;
            return result;
        }
    }
}