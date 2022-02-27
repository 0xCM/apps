//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedModels.RuleStateCalcs;

    partial class XedDisasmSvc
    {
        public DisasmFileBlocks LoadDisamBlocks(in FileRef src)
            => XedDisasmOps.LoadFileBlocks(src);

        public Index<XedDisasmDetail> CollectDisasmDetails(WsContext context)
        {
            var result = Outcome.Success;
            var catalog = context.Files;
            var files = catalog.Entries(FileKind.XedRawDisasm);
            var count = files.Count;
            var buffer = list<XedDisasmDetail>();
            var bag = core.bag<XedDisasmDetail>();
            var xedsvc = this;
            iter(files, file => {

                var blocks = xedsvc.LoadDisamBlocks(file);
                result = XedDisasmOps.ParseSummaries(context, file, out var encodings);
                var rows = encodings.View;
                Require.equal((uint)rows.Length, blocks.LineBlocks.Count);
                result = xedsvc.CalcDisasmDetails(context, blocks, bag);
                result.Require();
            },true);

            var records = bag.ToArray().Sort();
            for(var i=0u; i<records.Length; i++)
                seek(records,i).Seq = i;
            EmitDisasmDetails(records, Projects.Table<XedDisasmDetail>(context.Project));
            context.Receiver.Collected(records);
            return records;
        }

        Index<XedDisasmDetail> EmitDisasmDetails(Index<XedDisasmDetail> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            var formatter = Tables.formatter<XedDisasmDetail>(XedDisasmDetail.RenderWidths);
            var headerBase = formatter.FormatHeader();
            var j = text.lastindex(headerBase, Chars.Pipe);
            headerBase = text.left(headerBase,j);
            var opheader = text.buffer();
            for(var k=0; k<6; k++)
            {
                opheader.Append("| ");
                opheader.Append(InstOperands.Header(k));
            }

            var header = string.Format("{0}{1}", headerBase, opheader.Emit());
            using var writer = dst.AsciWriter();
            writer.WriteLine(header);
            for(var i=0; i<src.Length; i++)
                writer.WriteLine(formatter.Format(src[i]));

            EmittedFile(emitting, src.Length);
            return src;
        }

        public Outcome CalcDisasmDetails(WsContext context, in DisasmFileBlocks src, ConcurrentBag<XedDisasmDetail> buffer)
        {
            var blocks = src.LineBlocks;
            var count = blocks.Count;
            var result = XedDisasmOps.ParseSummaries(context, src.Source, out var summaries);
            if(result.Fail)
                return result;

            if(summaries.RowCount != count)
            {
                result = (false, string.Format("{0} != {1}", count, summaries.RowCount));
                return result;
            }

            for(var i=0u; i<count; i++)
            {
                ref readonly var block = ref blocks[i];
                ref readonly var encoding =ref summaries[i];
                var detail = XedDisasmDetail.Empty;
                result = CalcDisasmDetail(block, encoding, out detail);
                if(result.Fail)
                    break;
                else
                    buffer.Add(detail);
            }

            return result;
        }

        public Outcome CalcDisasmDetail(in DisasmLineBlock block, in XedDisasmSummary summary, out XedDisasmDetail dst)
        {
            dst = default;
            var result = ParseInstruction(block, out var inst);
            if(result.Fail)
            {
                dst = default;
                return result;
            }

            ref readonly var code = ref summary.Encoded;
            dst.Seq = summary.Seq;
            dst.DocSeq = summary.DocSeq;
            dst.OriginId = summary.OriginId;
            dst.OriginName = summary.OriginName;
            dst.EncodingId = summary.EncodingId;
            dst.InstructionId = AsmBytes.instid(summary.OriginId, summary.IP, code.Bytes);
            dst.IP = summary.IP;
            dst.Encoded = summary.Encoded;
            dst.Asm = summary.Asm;
            dst.IForm = inst.Form;
            dst.SourceName = text.remove(summary.Source.Path.FileName.Format(), "." + FileKindNames.xeddisasm_raw);

            var parser = new XedOperandParser();
            parser.ParseState(inst.Props.Edit, out var state);
            dst.Offsets = state.Offsets();
            dst.OpCode = state.NOMINAL_OPCODE;
            dst.Operands = alloc<InstOperandDetail>(block.OperandCount);

            var ocpos = state.POS_NOMINAL_OPCODE;
            var ocsrm = (uint3)math.and((byte)state.SRM, state.NOMINAL_OPCODE);
            Require.equal(state.SRM, ocsrm);

            var ocbits = (eight)(byte)state.NOMINAL_OPCODE;
            if(state.NOMINAL_OPCODE != code[ocpos])
            {
                result = (false, string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", state.NOMINAL_OPCODE, state.MODRM_BYTE));
                return result;
            }

            var ruleops = state.RuleOperands(code);
            var opcount = dst.Operands.Count;
            for(var k=0; k<opcount; k++)
            {
                ref readonly var opsrc = ref skip(block.Operands, k);
                result = parser.ParseInstOperand(opsrc.Content, out var op);
                if(result.Fail)
                    break;

                ref var opdetail = ref dst.Operands[k];
                opdetail.Op = op;

                var title = string.Format("Op{0}", k);
                var opwidth = OperandWidth(op.WidthType);
                opdetail.Width = opwidth;
                var indicator = opwidth.Name;
                var width = opwidth.Width64;
                var widthdesc = string.Format("{0}:{1}", opwidth.Name, opwidth.Width64);
                var opname = XedRuleOps.name(op.Kind);
                opdetail.RuleOpName = opname;
                var opval = RuleOperand.Empty;
                var opvalfmt = EmptyString;
                if(ruleops.TryGetValue(opname, out opval))
                {
                    opdetail.RuleOp = opval;
                    opvalfmt = opval.Format();
                    if(opname == RuleOpName.RELBR)
                    {
                        var w = state.BRDISP_WIDTH;
                        var val = (Disp)opval.Value;
                        opvalfmt = val.Format();
                        // opvalfmt = val.Format();
                        // if(w <= 8)
                        //     opvalfmt = ((byte)val).FormatHex();
                        // else if(w <= 16)
                        //     opvalfmt = ((ushort)val).FormatHex();
                        // else if(w <= 32)
                        //     opvalfmt = ((uint)val).FormatHex();
                        // else
                        //     opvalfmt = val.Format();
                    }
                    opdetail.RuleOpInfo = opvalfmt;
                }

                opdetail.Description = string.Format(InstOperands.RenderPattern, title, opname, opvalfmt, op.Action, op.Visiblity, width, indicator, op.Prop2);
            }


            if(ruleops.TryGetValue(RuleOpName.BASE0, out var @base))
            {

            }

            if(ruleops.TryGetValue(RuleOpName.INDEX, out var index))
            {

            }

            if(ruleops.TryGetValue(RuleOpName.SCALE, out var scale))
            {

            }

            if(ruleops.TryGetValue(RuleOpName.DISP, out var disp))
            {
                dst.Disp = (Disp)disp.Value;
            }

            var prefix = ocpos != 0 ? slice(code.Bytes,0,ocpos) : default;
            dst.PSZ = (byte)prefix.Length;

            var legacyskip = z8;
            for(var k=0; k<prefix.Length; k++)
            {
                ref readonly var b = ref skip(prefix,k);
                if(AsmPrefixTests.opsz(b))
                {
                    dst.SZOV = AsmPrefix.opsz();
                    legacyskip++;
                }
                else if(AsmPrefixTests.adsz(b))
                {
                    dst.SZOV = AsmPrefix.adsz();
                    legacyskip++;
                }
            }

            var has_rex = rex(state, out var _rex);
            dst.Rex = _rex;
            if(has_rex)
            {

            }

            var has_modrm = modrm(state, out var _modrm);
            dst.ModRm = _modrm;
            if(has_modrm)
            {
                if(_modrm != state.MODRM_BYTE)
                {
                    result = (false, string.Format("Derived RM value {0} differs from parsed value {1}", _modrm, state.MODRM_BYTE));
                    return result;
                }

                if(_modrm != code[state.POS_MODRM])
                {
                    result = (false, string.Format("Derived RM value {0} differs from encoded value {1}", _modrm, code[state.POS_MODRM]));
                    return result;
                }
            }

            var has_sib = sib(state, out var _sib);
            dst.Sib = _sib;

            if(has_sib)
            {
                var sibenc = Sib.init(code[state.POS_SIB]);
                if(sibenc.Value() != _sib)
                {
                    result = (false, string.Format("Derived Sib value {0} differs from encoded value {1}", _sib, sibenc));
                    return result;
                }
            }

            if(state.VEXVALID == VexKind.VV1)
            {
                var vexcode = VexPrefix.code(prefix);
                var vexsize = VexPrefix.size(vexcode.Value);
                var vexbytes = slice(prefix, vexcode.Offset, vexsize);
                var vexdest = (uint5)(state.VEXDEST210 | (byte)state.VEXDEST3 << 3 | (byte)state.vexdest4 << 4);
                Require.equal(vexbytes.Length, vexsize);

                if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C4)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC4,skip(vexbytes, 1), skip(vexbytes,2));
                else if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C5)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC5,skip(vexbytes, 1));

            }
            else if(state.VEXVALID == VexKind.EVV)
            {
                var evexbytes = slice(prefix,legacyskip);
                dst.Evex = EvexPrefix.define(evexbytes);
            }

            if(state.IMM0)
            {
                var size = Sizes.native(state.IMM_WIDTH).Code;
                var signed = state.IMM0SIGNED;
                var pos = state.POS_IMM;
                dst.Imm = asm.imm(code, pos, signed, size);
            }

            dst.EASZ = Sizes.native(width(state.EASZ));
            dst.EOSZ = Sizes.native(width(state.EOSZ));

            var flags = state.Flags().Delimit();
            return result;
        }
    }
}