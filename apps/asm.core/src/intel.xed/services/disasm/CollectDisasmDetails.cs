//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRecords;

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

                var originated = context.Root(file.Path, out var origin);
                var blocks = xedsvc.LoadDisamBlocks(file);
                result = XedDisasmOps.ParseEncodings(context, file, out var encodings);
                if(originated)
                {
                    for(var j=0; j<encodings.RowCount; j++)
                        encodings[j].OriginId = origin.DocId;
                }

                var rows = encodings.View;
                Require.equal((uint)rows.Length, blocks.LineBlocks.Count);
                result = xedsvc.CalcDisasmDetails(context, blocks, bag);
                result.Require();

            },true);

            var records = bag.ToArray().Sort();
            for(var i=0u; i<records.Length; i++)
                seek(records,i).Seq = i;
            Emit(records, Projects.Table<XedDisasmDetail>(context.Project));
            context.Receiver.Collected(records);
            return records;
        }

        Index<XedDisasmDetail> Emit(Index<XedDisasmDetail> src, FS.FilePath dst)
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

            var result = XedDisasmOps.ParseEncodings(context, src.Source, out var encodings);
            if(result.Fail)
                return result;

            if(encodings.RowCount != count)
            {
                result = (false, string.Format("{0} != {1}", count, encodings.RowCount));
                return result;
            }

            for(var i=0u; i<count; i++)
            {
                ref readonly var block = ref blocks[i];
                ref readonly var encoding =ref encodings[i];
                var detail = XedDisasmDetail.Empty;
                result = CalcDisasmDetail(block, encoding, out detail);
                if(result.Fail)
                    break;
                else
                    buffer.Add(detail);
            }

            return result;
        }

        public Outcome CalcDisasmDetail(in DisasmLineBlock block, in AsmEncodingRow encoding, out XedDisasmDetail dst)
        {
            dst = default;
            var result = ParseInstruction(block, out var inst);
            if(result.Fail)
            {
                dst = default;
                return result;
            }

            ref readonly var code = ref encoding.Encoded;

            dst.EncodingId = encoding.EncodingId;
            dst.OriginId = encoding.OriginId;
            dst.InstructionId = AsmBytes.instid(encoding.OriginId, encoding.IP, code.Bytes);
            dst.IP = encoding.IP;
            dst.Encoded = encoding.Encoded;
            dst.Asm = encoding.Asm;
            dst.IForm = inst.Form;
            dst.SourceName = text.remove(encoding.Source.Path.FileName.Format(), "." + FileKindNames.xeddisasm_raw);

            var parser = new XedOperandParser();
            parser.ParseState(inst.Props.Edit, out var state);
            dst.Offsets = state.Offsets();
            var oc = state.nominal_opcode;
            var ocpos = state.pos_nominal_opcode;
            var ops = state.RuleOperands(code);
            var srm = state.srm;
            var ocsrm = (uint3)math.and((byte)srm, oc);
            Require.equal(srm, ocsrm);

            var ocbits = (eight)(byte)oc;

            if(oc != code[ocpos])
            {
                result = (false, string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", oc, state.modrm_byte));
                return result;
            }

            dst.OpCode = oc;

            var opcount = block.OperandCount;
            dst.Operands = alloc<InstOperandDetail>(opcount);
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
                if(ops.TryGetValue(opname, out opval))
                {
                    opdetail.RuleOp = opval;
                    opvalfmt = opval.Format();
                    if(opname == RuleOpName.RELBR)
                    {
                        var w = state.brdisp_width;
                        var val = (Hex64)opval.Value;
                        opvalfmt = val.Format();
                        if(w <= 8)
                            opvalfmt = ((byte)val).FormatHex();
                        else if(w <= 16)
                            opvalfmt = ((ushort)val).FormatHex();
                        else if(w <= 32)
                            opvalfmt = ((uint)val).FormatHex();
                        else
                            opvalfmt = val.Format();
                    }
                    opdetail.RuleOpInfo = opvalfmt;
                }

                opdetail.Description = string.Format(InstOperands.RenderPattern, title, opname, opvalfmt, op.Action, op.Visiblity, width, indicator, op.Prop2);
            }


            if(ops.TryGetValue(RuleOpName.BASE0, out var @base))
            {

            }

            if(ops.TryGetValue(RuleOpName.INDEX, out var index))
            {

            }

            if(ops.TryGetValue(RuleOpName.SCALE, out var scale))
            {

            }

            if(ops.TryGetValue(RuleOpName.DISP, out var disp))
            {
                dst.Disp = new Disp((long)disp.Value, Sizes.native(disp.Width));
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

            var has_rex = rex(state, out dst.Rex);
            if(has_rex)
            {

            }

            var has_modrm = modrm(state, out dst.ModRm);
            if(has_modrm)
            {
                var modrmval = dst.ModRm;
                if(modrmval.Value() != state.modrm_byte)
                {
                    result = (false, string.Format("Derived RM value {0} differs from parsed value {1}", modrmval, state.modrm_byte));
                    return result;
                }

                if(modrmval.Value() != code[state.pos_modrm])
                {
                    result = (false, string.Format("Derived RM value {0} differs from encoded value {1}", modrmval, code[state.pos_modrm]));
                    return result;
                }
            }

            var has_sib = sib(state, out dst.Sib);
            if(has_sib)
            {
                var sibenc = Sib.init(code[state.pos_sib]);
                if(sibenc.Value() != dst.Sib.Value())
                {
                    result = (false, string.Format("Derived Sib value {0} differs from encoded value {1}", dst.Sib, sibenc));
                    return result;
                }
            }

            if(state.vexvalid == VexValidityKind.VV1)
            {
                var vexcode = VexPrefix.code(prefix);
                var vexsize = VexPrefix.size(vexcode.Value);
                var vexbytes = slice(prefix, vexcode.Offset, vexsize);
                Require.equal(vexbytes.Length, vexsize);

                if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C4)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC4,skip(vexbytes, 1), skip(vexbytes,2));
                else if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C5)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC5,skip(vexbytes, 1));

            }
            else if(state.vexvalid == VexValidityKind.EVV)
            {
                var evexbytes = slice(prefix,legacyskip);
                dst.Evex = EvexPrefix.define(evexbytes);
            }

            return result;
        }

        public Outcome CollectDetailPages(WsContext collect)
        {
            var result = Outcome.Success;
            var encodings = CollectEncodingDocs(collect);
            var files = encodings.Keys.ToArray().Sort();
            var count = files.Length;
            var blocks = XedDisasmOps.LoadFileBlocks(files);
            var dir = Projects.XedDisasmDir(collect.Project);
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref skip(files,i);
                var block = blocks[file];
                var encoding = encodings[file];
                var srcid = file.Path.FileName.WithoutExtension.Format();
                var k = text.index(srcid, ".xed.");
                if(k > 0)
                    srcid = text.left(srcid,k);
                var dst = Projects.XedDisasmDetailPage(collect.Project, srcid);
                result = EmitDisasmDetailPages(encoding, block.LineBlocks, dst);
                if(result.Fail)
                    break;
            }

            return result;
        }

        const string RenderPattern = "{0,-22}: {1}";

        const string Cols2Pattern = "{0,-12} | {1,-12}";

        const string Cols3Pattern = "{0,-12} | {1,-12} | {2,-12}";

        const string OpPattern = "{0,-12} | {1,-20} | {2,-12} | {3,-12} | {4,-12} | {5,-12}";

        void RenderHeader(FS.FilePath path, in AsmEncodingRow encoding, in DisasmLineBlock block, in DisasmInstruction inst, in AsmHexCode code, ITextBuffer dst)
        {
            ref readonly var IP = ref encoding.IP;
            dst.AppendLineFormat(RenderPattern, "Id", AsmBytes.encid(IP, code.Bytes));
            dst.AppendLine(string.Format(RenderPattern, "IP", ((uint)IP).FormatHex(zpad:false, specifier:true, uppercase:true)));
            dst.AppendLine(string.Format(RenderPattern, "Statement", encoding.Asm));
            dst.AppendLine(string.Format(RenderPattern, "Encoding", string.Format(Cols2Pattern, code, code.BitString)));
            dst.AppendLine(string.Format(RenderPattern, "IClass", inst.Class));
            dst.Append(string.Format(RenderPattern, "IForm", inst.Form));
        }

        Outcome EmitDisasmDetailPages(AsmEncodingDoc encodings, ReadOnlySpan<DisasmLineBlock> blocks, FS.FilePath dst)
        {
            var encoded = encodings.View;
            var parser = new XedOperandParser();
            var count = (uint)Require.equal(encoded.Length, blocks.Length);
            var result = ParseInstructions(blocks, out var instructions);
            if(result.Fail)
                return result;

            Require.equal(instructions.Count, count);

            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var encoding = ref encoded[i];
                ref readonly var inst = ref instructions[i];
                ref readonly var block = ref skip(blocks,i);
                ref readonly var code = ref encoding.Encoded;
                ref readonly var IP = ref encoding.IP;

                writer.WriteLine(RP.PageBreak120);
                var header = text.buffer();
                RenderHeader(encodings.Location, encoding, block, inst, code, header);
                writer.WriteLine(header.Emit());

                parser.ParseState(inst.Props.Edit, out var state);
                iter(parser.UnknownFields, u => Warn(string.Format("Unknown field:{0}", u)));
                iter(parser.Failures, f => Warn(string.Format("Parse failure for {0}:{1}", f.Key, f.Value)));

                if(inst.Class == IClass.RET_NEAR || inst.Class == IClass.NOP)
                    continue;

                var oc = state.nominal_opcode;
                var ocpos = state.pos_nominal_opcode;
                var ops = state.RuleOperands(code);
                var srm = state.srm;
                var ocsrm = (uint3)math.and((byte)srm, oc);
                Require.equal(srm, ocsrm);

                var ocbits = (eight)(byte)oc;

                if(oc != code[ocpos])
                    return (false, string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", oc, state.modrm_byte));

                if(srm != 0)
                    writer.WriteLine(string.Format(RenderPattern, "OpCodeSrm", string.Format(Cols3Pattern, oc.Format(true,true,true), ocbits, srm)));
                else
                    writer.WriteLine(string.Format(RenderPattern, "OpCode", string.Format(Cols2Pattern, oc.Format(true,true,true), ocbits)));


                var opcount = block.OperandCount;

                for(var k=0; k<opcount; k++)
                {
                    ref readonly var opsrc = ref skip(block.Operands, k);
                    result = parser.ParseInstOperand(opsrc.Content, out var op);
                    if(result.Fail)
                        return result;

                    var title = string.Format("Op{0}", k);
                    var opwidth = OperandWidth(op.WidthType);
                    var widthdesc = string.Format("{0}:{1}", opwidth.Name, opwidth.Width64);
                    var opname = XedRuleOps.name(op.Kind);
                    var opval = RuleOperand.Empty;
                    var opvalfmt = EmptyString;
                    if(ops.TryGetValue(opname, out opval))
                    {
                        opvalfmt = opval.Format();
                        if(opname == RuleOpName.RELBR)
                        {
                            var w = state.brdisp_width;
                            var val = (Hex64)opval.Value;
                            opvalfmt = val.Format();
                            if(w <= 8)
                                opvalfmt = ((byte)val).FormatHex();
                            else if(w <= 16)
                                opvalfmt = ((ushort)val).FormatHex();
                            else if(w <= 32)
                                opvalfmt = ((uint)val).FormatHex();
                            else
                                opvalfmt = val.Format();
                        }
                    }

                    writer.WriteLine(string.Format(RenderPattern, title, string.Format(OpPattern, opname, opvalfmt, op.Action, op.Visiblity, widthdesc, op.Prop2)));
                }

                if(ops.TryGetValue(RuleOpName.BASE0, out var x3))
                    writer.WriteLine(string.Format(RenderPattern, x3.Name, x3));

                if(ops.TryGetValue(RuleOpName.INDEX, out var x2))
                    writer.WriteLine(string.Format(RenderPattern, x2.Name, x2));

                if(ops.TryGetValue(RuleOpName.SCALE, out var x0))
                    writer.WriteLine(string.Format(RenderPattern, x0.Name, x0));

                if(ops.TryGetValue(RuleOpName.DISP, out var x1))
                    writer.WriteLine(string.Format(RenderPattern, x1.Name, string.Format(Cols2Pattern, x1, x1.Width)));

                var prefixbytes = default(Span<byte>);
                if(ocpos != 0)
                    prefixbytes = slice(code.Bytes,0,ocpos);

                if(prefixbytes.Length != 0)
                    writer.WriteLine(string.Format(RenderPattern, "PrefixBytes", prefixbytes.FormatHex()));

                var has_rex = rex(state, out var rexprefix);
                if(has_rex)
                    writer.WriteLine(string.Format(RenderPattern, "REX", string.Format(Cols2Pattern, rexprefix.ToBitString(), rexprefix.Format())));

                if(state.vexvalid == VexValidityKind.VV1)
                {
                    var vexcode = VexPrefix.code(prefixbytes);
                    var vexsize = VexPrefix.size(vexcode.Value);
                    var vexbytes = slice(prefixbytes, vexcode.Offset, vexsize);
                    Require.equal(vexbytes.Length, vexsize);

                    writer.WriteLine(string.Format(RenderPattern, "VEX", string.Format("{0} {1} {2}", vexcode.Value, state.vex_prefix, state.vl)));
                    writer.WriteLine(string.Format(RenderPattern, "VEXBytes", vexbytes.FormatHex()));

                    if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C4)
                    {
                        var vex = VexPrefixC4.define(skip(vexbytes, 1), skip(vexbytes,2));
                        writer.WriteLine(string.Format(RenderPattern, "VEXBits", VexPrefixC4.BitPattern));
                        writer.WriteLine(string.Format(RenderPattern, EmptyString, vex.ToBitstring()));
                    }
                    else if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C5)
                    {
                        var vex = VexPrefixC5.define(skip(vexbytes, 1));
                        writer.WriteLine(string.Format(RenderPattern, "VEXBits", VexPrefixC5.BitPattern));
                        writer.WriteLine(string.Format(RenderPattern, EmptyString, vex.ToBitstring()));
                    }

                    var vexdest = string.Format("{0}{1}{2}", state.vexdest4, state.vexdest3, state.vexdest210);
                    result = DataParser.parse(vexdest, out uint5 uvdst);
                    if(result.Fail)
                        return result;

                    writer.WriteLine(string.Format(RenderPattern, "VEXDEST", string.Format(Cols2Pattern, vexdest, ((byte)(uvdst)).FormatHex())));
                }
                else if(state.vexvalid == VexValidityKind.EVV)
                {

                }

                var has_modrm = modrm(state, out var modrmval);
                if(has_modrm)
                {
                    if(modrmval.Value() != state.modrm_byte)
                        return (false, string.Format("Derived RM value {0} differs from parsed value {1}", modrmval, state.modrm_byte));

                    if(modrmval.Value() != code[state.pos_modrm])
                        return (false, string.Format("Derived RM value {0} differs from encoded value {1}", modrmval, code[state.pos_modrm]));

                    writer.WriteLine(string.Format(RenderPattern, "MODRM", string.Format(Cols2Pattern, modrmval.ToBitString(), modrmval.Format())));
                }

                var has_sib = sib(state, out var sibval);
                if(has_sib)
                {
                    var sibenc = Sib.init(code[state.pos_sib]);
                    if(sibenc.Value() != sibval.Value())
                        return (false, string.Format("Derived Sib value {0} differs from encoded value {1}", sibval, sibenc));
                    writer.WriteLine(string.Format(RenderPattern, "SIB", string.Format(Cols2Pattern, sibval.ToBitString(), sibval.Format())));
                }

                if(state.imm0)
                {
                    var size = Sizes.native(state.imm_width).Code;
                    var signed = state.imm0signed;
                    var pos = state.pos_imm;
                    var _val = asm.imm(code, pos, signed, size);
                    var val = 0ul;

                    switch(size)
                    {
                        case NativeSizeCode.W8:
                            val = code[pos];
                        break;
                        case NativeSizeCode.W16:
                            val = slice(code.Bytes, pos, 2).TakeUInt16();
                        break;
                        case NativeSizeCode.W32:
                            val = slice(code.Bytes, pos, 4).TakeUInt32();
                        break;
                        case NativeSizeCode.W64:
                            val = slice(code.Bytes, pos, 8).TakeUInt64();
                        break;
                    }
                    writer.WriteLine(string.Format(RenderPattern, "IMM0", _val));
                }

                var easzW = widths(state.easz);
                if(easzW > 64)
                {
                    var w0 = (byte)easzW;
                    var w1 =(byte)(easzW >> 8);
                    writer.WriteLine(RenderPattern, "EASZ", string.Format("{0}, {1}", w0, w1));
                }
                else
                    writer.WriteLine(RenderPattern, "EASZ", easzW);

                var eoszW = widths(state.eosz);
                if(eoszW > 64)
                {
                    var w0 = (byte)eoszW;
                    var w1 = (byte)(eoszW >> 8);
                    var w2 = (byte)(eoszW >> 16);
                    if(w2 > 0)
                        writer.WriteLine(RenderPattern, "EOSZ", string.Format("{0}, {1}, {2}", w0, w1, w2));
                    else
                        writer.WriteLine(RenderPattern, "EOSZ", string.Format("{0}, {1}", w0, w1));
                }
                else
                    writer.WriteLine(RenderPattern, "EOSZ", eoszW);

                if(state.nelem != 0)
                    writer.WriteLine(string.Format(RenderPattern, "Segments", string.Format("{0}x{1}", state.nelem, state.element_size)));

                writer.WriteLine(string.Format(RenderPattern, "Offsets", state.Offsets()));
                writer.WriteLine(RenderPattern, "Flags", state.Flags().Delimit().Format());
            }

            writer.WriteLine();

            EmittedFile(emitting, count);
            return result;
        }
    }
}