//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Asm;
    using static core;
    using static Root;

    using static XedModels;

    using K = XedModels.OperandKind;

    partial class ProjectCmdProvider
    {
        Outcome Emit(FS.FilePath src, ReadOnlySpan<AsmStatementEncoding> encodings, ReadOnlySpan<XedDisasm.Block> blocks, FS.FilePath dst)
        {
            const string RenderPattern = "{0,-22}: {1}";

            var parser = new XedOperandParser();
            var count = (uint)Require.equal(encodings.Length, blocks.Length);
            var result = XedDisasm.ParseInstructions(blocks, out var instructions);
            if(result.Fail)
                return result;

            Require.equal(instructions.Count, count);

            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var encoding = ref skip(encodings,i);
                ref readonly var inst = ref instructions[i];
                ref readonly var block = ref skip(blocks,i);

                parser.ParseState(inst.Props.Edit, out var state);
                iter(parser.UnknownFields, u => Warn(string.Format("Unknown field:{0}", u)));
                iter(parser.Failures, f => Warn(string.Format("Parse failure for {0}:{1}", f.Key, f.Value)));

                var parsed = parser.ParsedFields.ToHashSet();
                writer.WriteLine(RP.PageBreak80);
                writer.WriteLine(string.Format(RenderPattern, "Statement", encoding.Asm));
                writer.WriteLine(string.Format(RenderPattern, "Encoding", encoding.Encoding));
                writer.WriteLine(string.Format(RenderPattern, "Class", inst.Class));
                writer.WriteLine(string.Format(RenderPattern, "Form", inst.Form));

                for(var k=0; k<block.OperandCount; k++)
                {
                    ref readonly var opsrc = ref skip(block.Operands,k);
                    result = parser.ParseInstOperand(opsrc.Content, out var op);
                    if(result.Fail)
                        return result;

                    var title = string.Format("Operand {0}", k);
                    var content = string.Format("{0,-12} | {1,-12} | {2,-12} | {3}", op.Kind, op.Action, op.Visiblity, op.Prop2);
                    writer.WriteLine(string.Format(RenderPattern, title, content));
                }

                var fields = state.ToLookup();
                var kinds = fields.Keys;
                var values = fields.Values;
                for(var k=0; k<kinds.Length; k++)
                {
                    ref readonly var kind = ref skip(kinds,k);
                    if(parsed.Contains(kind))
                    {
                        ref readonly var value = ref skip(values,k);
                        writer.WriteLine(string.Format(RenderPattern, kind, value));
                    }
                }
            }

            writer.WriteLine();

            EmittedFile(emitting, count);
            return result;
        }

        [CmdOp("xed/disasm/blocks")]
        protected Outcome EmitXedDisasmBlocks(CmdArgs args)
        {
            var project = Project();
            var encodings = XedDisasm.ParseEncodings(project);
            var blocks = XedDisasm.ParseBlocks(project);
            var files = blocks.Keys;
            var count = files.Length;
            var dir = ProjectDb.ProjectData() + FS.folder(string.Format("{0}.{1}", project.Name, "xed.disasm.detail"));
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(files,i);
                var block = blocks[path];
                var encoding = encodings[path];
                var dst = dir + FS.file(string.Format("{0}.details",path.FileName), FS.Txt);
                var result = Emit(path,encoding.Encoded, block.Blocks, dst);
                if(result.Fail)
                    return result;
            }


            return true;
        }
    }

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

            result = DataParser.parse(skip(parts,i++), out dst.Prop1);
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
            if(text.empty(value))
                return;

            var result = Outcome.Success;
            switch(kind)
            {
                case K.AGEN:
                    result = DataParser.parse(value, out State.agen);
                break;

                case K.AMD3DNOW:
                    result = DataParser.parse(value, out State.amd3dnow);
                break;

                case K.ASZ:
                    result = DataParser.parse(value, out State.asz);
                break;

                case K.BASE0:
                    result = Parse(value, out State.base0);
                break;

                case K.BASE1:
                    result = Parse(value, out State.base1);
                break;

                case K.BCAST:
                    result = DataParser.parse(value, out State.bcast);
                break;

                case K.BCRC:
                    result = DataParser.parse(value, out State.bcrc);
                break;

                case K.BRDISP_WIDTH:
                    result = DataParser.parse(value, out State.brdisp_width);
                break;

                case K.CET:
                    result = DataParser.parse(value, out State.cet);
                break;

                case K.CHIP:
                    result = DataParser.eparse(value, out State.chip);
                break;

                case K.CLDEMOTE:
                    result = DataParser.parse(value, out State.cldemote);
                    break;

                case K.DEFAULT_SEG:
                    result = DataParser.parse(value, out State.default_seg);
                break;

                case K.DF32:
                    result = DataParser.parse(value, out State.df32);
                break;

                case K.DF64:
                    result = DataParser.parse(value, out State.df64);
                break;

                case K.DISP:
                    result = DataParser.parse(value, out State.disp);
                break;

                case K.DISP_WIDTH:
                    result = DataParser.parse(value, out State.disp_width);
                break;

                case K.DUMMY:
                    result = DataParser.parse(value, out State.dummy);
                break;

                case K.EASZ:
                    result = DataParser.eparse(value, out State.easz);
                break;

                case K.ELEMENT_SIZE:
                    result = DataParser.parse(value, out State.element_size);
                break;

                case K.ENCODER_PREFERRED:
                    result = DataParser.parse(value, out State.encoder_preferred);
                break;

                case K.ENCODE_FORCE:
                    result = DataParser.parse(value, out State.encode_force);
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
                    result = DataParser.parse(value, out State.has_modrm);
                break;

                case K.HAS_SIB:
                    result = DataParser.parse(value, out State.has_sib);
                break;

                case K.HINT:
                    result = DataParser.eparse(value, out State.iclass);
                break;

                case K.ICLASS:
                    result = DataParser.eparse(value, out State.iclass);
                break;

                case K.ILD_F2:
                    result = DataParser.parse(value, out State.ild_f2);
                break;

                case K.ILD_F3:
                    result = DataParser.parse(value, out State.ild_f3);
                break;

                case K.ILD_SEG:
                    result = DataParser.parse(value, out State.ild_seg);
                break;

                case K.IMM0:
                    result = DataParser.parse(value, out State.imm0);
                break;

                case K.IMM0SIGNED:
                    result = DataParser.parse(value, out State.imm0signed);
                break;

                case K.IMM1:
                    result = DataParser.parse(value, out State.imm1);
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
                    result = DataParser.parse(value, out State.@lock);
                break;

                case K.LZCNT:
                    result = DataParser.parse(value, out State.lzcnt);
                break;

                case K.MAP:
                    result = DataParser.eparse(value, out State.map);
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
                    result = DataParser.parse(value, out State.modep5);
                break;

                case K.MODEP55C:
                    result = DataParser.parse(value, out State.modep55c);
                break;

                case K.MODE_FIRST_PREFIX:
                    result = DataParser.parse(value, out State.mode_first_prefix);
                break;

                case K.MODRM_BYTE:
                    result = DataParser.parse(value, out byte modrm);
                    if(result)
                        State.modrm_byte = modrm;
                break;

                case K.MPXMODE:
                    result = DataParser.parse(value, out State.mpxmode);
                break;

                case K.MUST_USE_EVEX:
                    result = DataParser.parse(value, out State.must_use_evex);
                break;

                case K.NEEDREX:
                    result = DataParser.parse(value, out State.needrex);
                break;

                case K.NEED_MEMDISP:
                    result = DataParser.parse(value, out State.need_memdisp);
                break;

                case K.NEED_SIB:
                    result = DataParser.parse(value, out State.need_sib);
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
                    result = DataParser.parse(value, out State.norex);
                break;

                case K.NO_SCALE_DISP8:
                    result = DataParser.parse(value, out State.no_scale_disp8);
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
                    result = DataParser.parse(value, out State.osz);
                break;

                case K.OUTREG:
                    result = Parse(value, out State.outreg);
                break;

                case K.OUT_OF_BYTES:
                    result = DataParser.parse(value, out State.out_of_bytes);
                break;

                case K.P4:
                    result = DataParser.parse(value, out State.p4);
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
                    result = DataParser.parse(value, out State.prefix66);
                break;

                case K.PTR:
                    result = DataParser.parse(value, out State.ptr);
                break;

                case K.REALMODE:
                    result = DataParser.parse(value, out State.realmode);
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
                    result = DataParser.parse(value, out State.relbr);
                break;

                case K.REP:
                    result = DataParser.parse(value, out State.rep);
                break;

                case K.REX:
                    result = DataParser.parse(value, out State.rex);
                break;

                case K.REXB:
                    result = DataParser.parse(value, out State.rexb);
                break;

                case K.REXR:
                    result = DataParser.parse(value, out State.rexr);
                break;

                case K.REXRR:
                    result = DataParser.parse(value, out State.rexrr);
                break;

                case K.REXW:
                    result = DataParser.parse(value, out State.rexw);
                break;

                case K.REXX:
                    result = DataParser.parse(value, out State.rexx);
                break;

                case K.RM:
                    result = DataParser.parse(value, out State.rm);
                break;

                case K.ROUNDC:
                    result = DataParser.parse(value, out State.roundc);
                break;

                case K.SAE:
                    result = DataParser.parse(value, out State.sae);
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
                    result = DataParser.parse(value, out State.smode);
                    break;

                case K.SRM:
                    result = DataParser.parse(value, out State.srm);
                break;

                case K.TZCNT:
                    result = DataParser.parse(value, out State.tzcnt);
                break;

                case K.UBIT:
                    result = DataParser.parse(value, out State.ubit);
                break;

                case K.UIMM0:
                    result = DataParser.parse(value, out State.uimm0);
                break;

                case K.UIMM1:
                    result = DataParser.parse(value, out State.uimm1);
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    result = DataParser.parse(value, out State.using_default_segment0);
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    result = DataParser.parse(value, out State.using_default_segment1);
                break;

                case K.VEXDEST210:
                    result = DataParser.parse(value, out State.vexdest210);
                break;

                case K.VEXDEST3:
                    result = DataParser.parse(value, out State.vexdest3);
                break;

                case K.VEXDEST4:
                    result = DataParser.parse(value, out State.vexdest4);
                break;

                case K.VEXVALID:
                    result = DataParser.parse(value, out State.vexvalid);
                break;

                case K.VEX_C4:
                    result = DataParser.parse(value, out State.vex_c4);
                break;

                case K.VEX_PREFIX:
                    result = DataParser.parse(value, out State.vex_prefix);
                break;

                case K.VL:
                    result = DataParser.parse(value, out State.vl);
                break;

                case K.WBNOINVD:
                    result = DataParser.parse(value, out State.wbnoinvd);
                break;

                case K.ZEROING:
                    result = DataParser.parse(value, out State.zeroing);
                break;
            }

            if(result.Fail)
            {
                _Failures[kind] = value;
            }
            else
            {
                _ParsedKinds.Add(kind);
            }
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