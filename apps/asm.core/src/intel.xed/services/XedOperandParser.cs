//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;

    using K = XedModels.OpKind;

    public class XedOperandParser
    {
        Symbols<OpKind> Kinds;

        Symbols<XedRegId> Registers;

        OpState State;

        DataList<OpKind> _ParsedKinds;

        DataList<Facet<string>> _UnknownFields;

        Dictionary<OpKind, string> _Failures;

        public XedOperandParser()
        {
            Kinds = Symbols.index<OpKind>();
            Registers = Symbols.index<XedRegId>();
            State = OpState.Empty;
            _ParsedKinds = new();
            _UnknownFields = new();
            _Failures = new();
        }

        void Clear()
        {
            State = OpState.Empty;
            _ParsedKinds.Clear();
            _UnknownFields.Clear();
            _Failures.Clear();
        }

        public ReadOnlySpan<Facet<string>> UnknownFields
            => _UnknownFields.View();

        public IReadOnlyDictionary<OpKind,string> Failures
            => _Failures;

        public ReadOnlySpan<OpKind> ParsedFields
            => _ParsedKinds.View();

        public Outcome ParseRegister(string src, out Register dst)
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

        [MethodImpl(Inline), Op]
        static Disp disp(long value, BitWidth size)
            => new Disp(value, Sizes.native(size));

        public void ParseState(ReadOnlySpan<Facet<string>> src, out OpState dst)
        {
            Clear();
            var count = src.Length;

            var dispwidth = 0u;
            var relbranch = Disp.Empty;
            for(var i=0; i<count; i++)
            {
                var kind = Parse(skip(src,i));
                switch(kind)
                {
                    case K.BRDISP_WIDTH:
                    break;
                    case K.RELBR:
                    break;
                }

            }
            dst = State;
            if(dst.relbr != 0 && dst.brdisp_width != 0)
                dst._relbr = disp((long)dst.relbr, dst.disp_width);
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
                    _ParsedKinds.Add(kind);
            }
            else
                _UnknownFields.Add(src);
            return kind;
        }

        Outcome Parse(string src, OpKind kind, ref OpState state)
        {
            var result = Outcome.Success;
            switch(kind)
            {
                case K.AGEN:
                    result = DataParser.parse(src, out state.agen);
                break;

                case K.AMD3DNOW:
                    state.amd3dnow = bit.On;
                break;

                case K.ASZ:
                    state.asz = bit.On;
                break;

                case K.BASE0:
                    result = ParseRegister(src, out state.base0);
                break;

                case K.BASE1:
                    result = ParseRegister(src, out state.base1);
                break;

                case K.BCAST:
                    result = DataParser.eparse(src, out state.bcast);
                break;

                case K.BCRC:
                    state.bcrc = bit.On;
                break;

                case K.RELBR:
                    result = DataParser.parse(src, out state.relbr);
                break;

                case K.BRDISP_WIDTH:
                    result = DataParser.parse(src, out state.brdisp_width);
                break;

                case K.CET:
                    state.cet = bit.On;
                break;

                case K.CHIP:
                    result = DataParser.eparse(src, out state.chip);
                break;

                case K.CLDEMOTE:
                    state.cldemote = bit.On;
                break;

                case K.DEFAULT_SEG:
                    result = DataParser.parse(src, out state.default_seg);
                break;

                case K.DF32:
                    state.df32 = bit.On;
                break;

                case K.DF64:
                    state.df64 = bit.On;
                break;

                case K.DISP:
                    result = AsmParser.parse(src, out state.disp);
                break;

                case K.DISP_WIDTH:
                    result = DataParser.parse(src, out state.disp_width);
                break;

                case K.DUMMY:
                    state.dummy = bit.On;
                break;

                case K.EASZ:
                    result = DataParser.eparse(src, out state.easz);
                break;

                case K.ELEMENT_SIZE:
                    result = DataParser.parse(src, out state.element_size);
                break;

                case K.ENCODER_PREFERRED:
                    state.encoder_preferred = bit.On;
                break;

                case K.ENCODE_FORCE:
                    state.encode_force = bit.On;
                break;

                case K.EOSZ:
                    result = DataParser.eparse(src, out state.eosz);
                break;

                case K.ESRC:
                    result = DataParser.parse(src, out state.esrc);
                break;

                case K.FIRST_F2F3:
                    result = DataParser.parse(src, out state.first_f2f3);
                break;

                case K.HAS_MODRM:
                    state.has_modrm = bit.On;
                break;

                case K.HAS_SIB:
                    state.has_sib = bit.On;
                break;

                case K.HINT:
                    result = DataParser.eparse(src, out state.iclass);
                break;

                case K.ICLASS:
                    result = DataParser.eparse(src, out state.iclass);
                break;

                case K.ILD_F2:
                    state.ild_f2 = bit.On;
                break;

                case K.ILD_F3:
                    state.ild_f3 = bit.On;
                break;

                case K.ILD_SEG:
                    result = DataParser.parse(src, out state.ild_seg);
                break;

                case K.IMM0:
                    state.imm0 = bit.On;
                break;

                case K.IMM0SIGNED:
                    state.imm0signed = bit.On;
                break;

                case K.IMM1:
                    state.imm1 = bit.On;
                break;

                case K.IMM1_BYTES:
                    result = DataParser.parse(src, out state.imm1_bytes);
                break;

                case K.IMM_WIDTH:
                    result = DataParser.parse(src, out state.imm_width);
                break;

                case K.INDEX:
                    result = ParseRegister(src, out state.index);
                break;

                case K.LAST_F2F3:
                    result = DataParser.parse(src, out state.last_f2f3);
                break;

                case K.LLRC:
                    result = DataParser.parse(src, out state.llrc);
                break;

                case K.LOCK:
                    state.@lock = bit.On;
                break;

                case K.LZCNT:
                    state.lzcnt = bit.On;
                break;

                case K.MAP:
                    result = DataParser.parse(src, out state.map);
                break;

                case K.MASK:
                    result = DataParser.parse(src, out state.mask);
                break;

                case K.MAX_BYTES:
                    result = DataParser.parse(src, out state.max_bytes);
                break;

                case K.MEM0:
                    result = DataParser.parse(src, out state.mem0);
                break;

                case K.MEM1:
                    result = DataParser.parse(src, out state.mem1);
                break;

                case K.MEM_WIDTH:
                    result = DataParser.parse(src, out state.mem_width);
                break;

                case K.MOD:
                    result = DataParser.parse(src, out state.mod);
                break;

                case K.REG:
                    result = DataParser.parse(src, out state.reg);
                break;

                case K.MODRM_BYTE:
                    result = DataParser.parse(src, out byte modrm);
                    if(result)
                        state.modrm_byte = modrm;
                break;

                case K.MODE:
                    result = DataParser.eparse(src, out state.mode);
                break;

                case K.MODEP5:
                    state.modep5 = bit.On;
                break;

                case K.MODEP55C:
                    state.modep55c = bit.On;
                break;

                case K.MODE_FIRST_PREFIX:
                    state.mode_first_prefix = bit.On;
                break;

                case K.MPXMODE:
                    state.mpxmode = bit.On;
                break;

                case K.MUST_USE_EVEX:
                    state.must_use_evex = bit.On;
                break;

                case K.NEEDREX:
                    state.needrex = bit.On;
                break;

                case K.NEED_MEMDISP:
                    state.need_memdisp = bit.On;
                break;

                case K.NEED_SIB:
                    state.need_sib = bit.On;
                break;

                case K.NELEM:
                    result = DataParser.parse(src, out state.nelem);
                break;

                case K.NOMINAL_OPCODE:
                    result = DataParser.parse(src, out byte opcode);
                    if(result)
                        state.nominal_opcode = opcode;
                break;

                case K.NOREX:
                    state.norex = bit.On;
                break;

                case K.NO_SCALE_DISP8:
                    state.no_scale_disp8 = bit.On;
                break;

                case K.NPREFIXES:
                    result = DataParser.parse(src, out state.nprefixes);
                break;

                case K.NREXES:
                    result = DataParser.parse(src, out state.nrexes);
                break;

                case K.NSEG_PREFIXES:
                    result = DataParser.parse(src, out state.nseg_prefixes);
                break;

                case K.OSZ:
                    state.osz = bit.On;
                break;

                case K.OUT_OF_BYTES:
                    state.out_of_bytes = bit.On;
                break;

                case K.P4:
                    state.p4 = bit.On;
                break;

                case K.POS_DISP:
                    result = DataParser.parse(src, out state.pos_disp);
                break;

                case K.POS_IMM:
                    result = DataParser.parse(src, out state.pos_imm);
                break;

                case K.POS_IMM1:
                    result = DataParser.parse(src, out state.pos_imm1);
                break;

                case K.POS_MODRM:
                    result = DataParser.parse(src, out state.pos_modrm);
                break;

                case K.POS_NOMINAL_OPCODE:
                    result = DataParser.parse(src, out state.pos_nominal_opcode);
                break;

                case K.POS_SIB:
                    result = DataParser.parse(src, out state.pos_sib);
                break;

                case K.PREFIX66:
                    state.prefix66 = 1;
                break;

                case K.PTR:
                    state.ptr = 1;
                break;

                case K.REALMODE:
                    state.realmode = 1;
                break;

                case K.OUTREG:
                    result = ParseRegister(src, out state.outreg);
                break;

                case K.REG0:
                    result = ParseRegister(src, out state.reg0);
                break;

                case K.REG1:
                    result = ParseRegister(src, out state.reg1);
                break;

                case K.REG2:
                    result = ParseRegister(src, out state.reg2);
                break;

                case K.REG3:
                    result = ParseRegister(src, out state.reg3);
                break;

                case K.REG4:
                    result = ParseRegister(src, out state.reg4);
                break;

                case K.REG5:
                    result = ParseRegister(src, out state.reg5);
                break;

                case K.REG6:
                    result = ParseRegister(src, out state.reg6);
                break;

                case K.REG7:
                    result = ParseRegister(src, out state.reg7);
                break;

                case K.REG8:
                    result = ParseRegister(src, out state.reg8);
                break;

                case K.REG9:
                    result = ParseRegister(src, out state.reg9);
                break;

                case K.REP:
                    result = DataParser.parse(src, out state.rep);
                break;

                case K.REX:
                    state.rex = bit.On;
                break;

                case K.REXB:
                    state.rexb = 1;
                break;

                case K.REXR:
                    state.rexr = 1;
                break;

                case K.REXRR:
                    state.rexrr = 1;
                break;

                case K.REXW:
                    state.rexw = 1;
                break;

                case K.REXX:
                    state.rexx = 1;
                break;

                case K.RM:
                    result = DataParser.parse(src, out state.rm);
                break;

                case K.ROUNDC:
                    result = DataParser.parse(src, out state.roundc);
                break;

                case K.SAE:
                    state.sae = bit.On;
                break;

                case K.SCALE:
                    result = DataParser.parse(src, out state.scale);
                break;

                case K.SEG0:
                    result = ParseRegister(src, out state.seg0);
                break;

                case K.SEG1:
                    result = ParseRegister(src, out state.seg1);
                break;

                case K.SEG_OVD:
                    result = DataParser.parse(src, out state.seg_ovd);
                break;

                case K.SIBBASE:
                    result = DataParser.parse(src, out state.sibbase);
                break;

                case K.SIBINDEX:
                    result = DataParser.parse(src, out state.sibindex);
                break;

                case K.SIBSCALE:
                    result = DataParser.parse(src, out state.sibscale);
                break;

                case K.SMODE:
                    result = DataParser.eparse(src, out state.smode);
                    break;

                case K.SRM:
                    result = DataParser.parse(src, out state.srm);
                break;

                case K.TZCNT:
                    state.tzcnt = bit.On;
                break;

                case K.UBIT:
                    state.ubit = bit.On;
                break;

                case K.UIMM0:
                    result = AsmParser.parse(src, out state.uimm0);
                break;

                case K.UIMM1:
                    result = AsmParser.parse(src, out state.uimm1);
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    state.using_default_segment0 = bit.On;
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    state.using_default_segment1 = bit.On;
                break;

                case K.VEXDEST210:
                    result = DataParser.parse(src, out state.vexdest210);
                break;

                case K.VEXDEST3:
                    state.vexdest3 = bit.On;
                break;

                case K.VEXDEST4:
                    state.vexdest4 = bit.On;
                break;

                case K.VEXVALID:
                    result = DataParser.eparse(src, out state.vexvalid);
                break;

                case K.VEX_C4:
                    state.vex_c4 = bit.On;
                break;

                case K.VEX_PREFIX:
                    result = DataParser.eparse(src, out state.vex_prefix);
                break;

                case K.VL:
                    result = DataParser.eparse(src, out state.vl);
                break;

                case K.WBNOINVD:
                    state.wbnoinvd = bit.On;
                break;

                case K.ZEROING:
                    state.zeroing = bit.On;
                break;
            }

            return result;
        }
    }
}