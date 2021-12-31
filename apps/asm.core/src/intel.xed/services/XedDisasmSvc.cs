//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;
    using static core;
    using static XedModels;
    using static XedDisasm;

    using K = XedModels.OperandKind;

    public class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        Symbols<IFormType> Forms;

        Symbols<IClass> Classes;

        Symbols<OperandWidthType> WidthTypes;

        XedRules Rules => Service(Wf.XedRules);

        ConstLookup<OperandWidthType,OperandWidth> OperandWidths;

        public XedDisasmSvc()
        {
            Forms = Symbols.index<IFormType>();
            Classes = Symbols.index<IClass>();
            WidthTypes = Symbols.index<OperandWidthType>();
        }

        protected override void OnInit()
        {
            var dst = dict<OperandWidthType, OperandWidth>();
            iter(Rules.LoadEmittedWidths(), w => dst.TryAdd(w.Code, w));
            OperandWidths = dst;
        }

        OperandWidth OperandWidth(OperandWidthType type)
            => OperandWidths[type];

        public FS.Files DisasmFiles(IProjectWs ws)
            => ws.OutFiles(FS.ext("xed.txt"));

        public FS.FilePath DisasmTable(IProjectWs project)
            => ProjectDb.ProjectData() + FS.file(string.Format("xed.disasm.{0}", project.Project), FS.Csv);

        public Outcome ParseInstructions(ReadOnlySpan<Block> src, out Index<Instruction> dst)
        {
            var count = src.Length;
            var result = Outcome.Success;
            dst = alloc<Instruction>(count);
            for(var i=0; i<count; i++)
            {
                result = ParseInstruction(skip(src,i), out dst[i]);
                if(result.Fail)
                    break;
            }
            return result;
        }

        public Index<AsmStatementEncoding> Collect(IProjectWs project)
        {
            var result = Outcome.Success;
            var paths = DisasmFiles(project);
            var records = ParseEncodings(paths);
            var count = paths.Length;
            TableEmit(records.View, AsmStatementEncoding.RenderWidths, DisasmTable(project));
            return records;
        }

        public Index<AsmStatementEncoding> ParseEncodings(ReadOnlySpan<FS.FilePath> src)
        {
            var dst = list<AsmStatementEncoding>();
            var counter = 0u;
            var count = src.Length;

            for(var i=0; i<count; i++)
            {
                var result = ParseEncodings(skip(src,i), dst);
                if(result.Fail)
                {
                    Error(result.Message);
                    return sys.empty<AsmStatementEncoding>();
                }
            }

            var encodings = dst.ToArray();
            for(var i=0u; i<encodings.Length; i++)
                seek(encodings,i).Seq = i;

            return encodings;
        }

        public ConstLookup<FS.FilePath,StatementEncodings> ParseEncodings(IProjectWs project)
        {
            var src = project.OutFiles(FS.ext("xed.txt"));
            var count = src.Count;
            var dst = dict<FS.FilePath,StatementEncodings>();
            for(var i=0; i<count; i++)
                dst[src[i]] =(ParseEncodings(src[i]));
            return dst;
        }

        public StatementEncodings ParseEncodings(FS.FilePath src)
        {
            var dst = list<AsmStatementEncoding>();
            var result = ParseEncodings(src,dst);
            if(result.Fail)
                Error(result);
            return new StatementEncodings(src,dst.ToArray());
        }

        public ConstLookup<FS.FilePath,FileBlocks> ParseBlocks(IProjectWs project)
        {
            var src = project.OutFiles(FS.ext("xed.txt"));
            var dst = dict<FS.FilePath,FileBlocks>();
            var blocks = list<Block>();
            foreach(var path in src)
            {
                blocks.Clear();
                Blocks(path,blocks);
                dst[path] =new FileBlocks(path, blocks.ToArray());
            }
            return dst;
        }

        /// <summary>
        /// Transforms the source document into a sequence of blocks, each of which describe a single decoded instruction
        /// </summary>
        /// <param name="src">And xed-emitted disassemly file</param>
        public Index<Block> ParseBlocks(FS.FilePath src)
            => Blocks(src);

        Outcome ParseInstruction(in Block block, out Instruction inst)
        {
            var result = Outcome.Success;
            inst = default(Instruction);
            ref readonly var content = ref block.Instruction.Content;
            if(text.nonempty(content))
            {
                var j = text.index(content, Chars.Space);
                if(j > 0)
                {
                    var expr = text.left(content,j);
                    if(Classes.Lookup(expr, out var @class))
                        inst.Class = @class;
                    else
                    {
                        result = (false,string.Format("IClass not found in '{0}'", content));
                        return result;
                    }

                    var k = text.index(content, j+1, Chars.Space);
                    if(k > 0)
                    {
                        expr = text.inside(content, j, k);
                        if(Forms.Lookup(expr, out var form))
                            inst.Form = form;
                        else
                        {
                            result = (false,string.Format("IFormType not found in '{0}'", expr));
                            return result;
                        }
                    }

                    var props = text.words(text.right(content,k), Chars.Comma);
                    var kP = props.Count;
                    inst.Props = alloc<Facet<string>>(kP);
                    for(var m=0; m<kP; m++)
                    {
                        ref readonly var p = ref props[m];
                        if(p.Contains(Chars.Colon))
                        {
                            var kv = text.split(p, Chars.Colon);
                            if(kv.Length == 2)
                                inst.Props[m] = (skip(kv,0).Trim(), skip(kv,1).Trim());
                        }
                        else
                        {
                            inst.Props[m] = (p.Trim(), EmptyString);
                        }
                    }
                }
            }
            return result;
        }

        const string XDIS = "XDIS ";

        const string YDIS = "YDIS:";

        static Index<Block> Blocks(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var dst = list<Block>();
            Blocks(src,dst);
            return dst.ToArray();
        }

        static void Blocks(FS.FilePath src, List<Block> dst)
        {
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var blocklines = list<TextLine>();
            var imax = count-1;
            for(var i=0; i<imax; i++)
            {
                blocklines.Clear();

                ref readonly var l0 = ref lines[i];
                ref readonly var l1 = ref lines[i+1];
                if(l0.IsNonEmpty && l1.IsNonEmpty)
                {
                    ref readonly var c0 = ref l0.Content;
                    ref readonly var c1 = ref l1.Content;
                    if(c1[0] == '0')
                    {
                        blocklines.Add(l0);
                        blocklines.Add(l1);
                        i++;
                        while(i++ < imax)
                        {
                            ref readonly var l = ref lines[i];
                            blocklines.Add(l);
                            if(l.StartsWith(XDIS))
                                break;
                        }
                        dst.Add(blocklines.ToArray());
                    }
                }
            }
        }

        static Outcome ParseEncodings(FS.FilePath src, List<AsmStatementEncoding> dst)
            => ParseEncodings(Blocks(src), dst);

        static Outcome ParseEncodings(ReadOnlySpan<Block> blocks, List<AsmStatementEncoding> dst)
        {
            var summaries = SummaryLines(blocks);
            var expr = expressions(blocks);
            var counter = 0u;
            var count = summaries.Length;
            var result = Outcome.Success;
            if(expr.Length != count)
                return (false, string.Format("{0} != {1}", expr.Length - 1, count));

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(summaries,i);
                ref readonly var content = ref line.Content;
                var record = new AsmStatementEncoding();
                ref readonly var expression = ref skip(expr,i);
                record.DocSeq = counter++;
                record.Asm = expression;
                record.Line = line.LineNumber;
                result = ParseOffset(content, out record.Offset);
                if(result.Fail)
                    return result;

                result = ParseHexCode(line, out record.Encoding);
                if(result.Fail)
                    return result;

                dst.Add(record);
            }

            return true;
        }

        static ReadOnlySpan<TextLine> SummaryLines(ReadOnlySpan<Block> src)
        {
            var dst = list<TextLine>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                var lines = skip(src,i).Lines;
                var lcount = lines.Count;
                for(var j=0; j<lcount; j++)
                {
                    ref readonly var line = ref lines[j];
                    if(j == lcount-1)
                        dst.Add(line);
                }
            }
            return dst.ViewDeposited();
        }

        static ReadOnlySpan<AsmExpr> expressions(ReadOnlySpan<Block> src)
        {
            var dst = list<AsmExpr>();
            foreach(var block in src)
            {
                foreach(var line in block.Lines)
                {
                    var i = text.index(line.Content, YDIS);
                    if(i >= 0)
                        dst.Add(text.trim(text.right(line.Content, i + YDIS.Length)));
                }
            }
            return dst.ViewDeposited();
        }

        static Outcome ParseOffset(string src, out Address32 dst)
        {
            var result = Outcome.Failure;
            var i = text.index(src, XDIS);
            var j = XDIS.Length;
            var k = text.index(src, Chars.Colon);
            var length = k-j;
            dst = 0;
            if(j >= 0 && length > 0)
                result = DataParser.parse(text.slice(src,j,length).Trim(), out dst);
            return result;
        }

        static Outcome ParseHexCode(TextLine src, out AsmHexCode dst)
        {
            var result = Outcome.Failure;
            dst = AsmHexCode.Empty;
            var buffer = span<byte>(16);

            if(src.StartsWith(XDIS))
            {
                ref readonly var content = ref src.Content;
                var k = text.index(content, Chars.Colon);
                if(k > 0)
                {
                    var parts = text.words(text.right(content,k));
                    if(parts.Length >=3)
                    {
                        var count = HexParser.parse(parts[2], buffer);
                        if(count)
                        {
                            dst = slice(buffer,0,count).ToArray();
                            result = Outcome.Success;
                        }
                    }
                }
            }

            return result;
        }

        public Outcome EmitDisasmDetails(IProjectWs src)
        {
            var result = Outcome.Success;
            var encodings = ParseEncodings(src);
            var blocks = ParseBlocks(src);
            var files = blocks.Keys;
            var count = files.Length;
            var dir = ProjectDb.ProjectData() + FS.folder(string.Format("{0}.{1}", src.Name, "xed.disasm.detail"));
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(files,i);
                var block = blocks[path];
                var encoding = encodings[path];
                var dst = dir + FS.file(string.Format("{0}.details",path.FileName), FS.Txt);
                result = Emit(path,encoding.Encoded, block.Blocks, dst);
                if(result.Fail)
                    break;
            }

            return result;
        }

        Outcome Emit(FS.FilePath src, ReadOnlySpan<AsmStatementEncoding> encodings, ReadOnlySpan<XedDisasm.Block> blocks, FS.FilePath dst)
        {
            const string RenderPattern = "{0,-22}: {1}";
            const string Cols2Pattern = "{0,-12} | {1,-12}";
            const string Cols3Pattern = "{0,-12} | {1,-12} | {2,-12}";
            const string Cols4Pattern = Cols3Pattern + " | {3, -12}";

            var parser = new XedOperandParser();
            var count = (uint)Require.equal(encodings.Length, blocks.Length);
            var result = ParseInstructions(blocks, out var instructions);
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
                ref readonly var code = ref encoding.Encoding;

                parser.ParseState(inst.Props.Edit, out var state);
                iter(parser.UnknownFields, u => Warn(string.Format("Unknown field:{0}", u)));
                iter(parser.Failures, f => Warn(string.Format("Parse failure for {0}:{1}", f.Key, f.Value)));

                var parsed = parser.ParsedFields.ToHashSet();
                writer.WriteLine(RP.PageBreak120);
                writer.WriteLine(string.Format(RenderPattern, "Statement", encoding.Asm));
                writer.WriteLine(string.Format(RenderPattern, "Encoding", string.Format(Cols2Pattern, code, code.ToBitString())));
                writer.WriteLine(string.Format(RenderPattern, "Class", inst.Class));
                writer.WriteLine(string.Format(RenderPattern, "Form", inst.Form));

                if(inst.Class == IClass.RET_NEAR || inst.Class == IClass.NOP)
                    continue;

                var oc = state.nominal_opcode;
                var ocpos = state.pos_nominal_opcode;
                var srm = state.srm;
                var ocsrm = (uint3)math.and((byte)srm, oc);
                var ocbits = (eight)(byte)oc;
                Require.equal(srm,ocsrm);

                var maxopcount = 5u;
                var opcount = block.OperandCount;
                for(var k=0; k<opcount; k++)
                {
                    ref readonly var opsrc = ref skip(block.Operands,k);
                    result = parser.ParseInstOperand(opsrc.Content, out var op);
                    if(result.Fail)
                        return result;

                    var title = string.Format("Op{0}", k);
                    var opwidth = OperandWidth(op.WidthType);
                    var widthdesc = string.Format("{0}:{1}", opwidth.Name, opwidth.Width64);
                    var content = string.Format("{0,-12} | {1,-12} | {2,-12} | {3,-12} | {4,-12}", op.Kind, op.Action, op.Visiblity, widthdesc, op.Prop2);
                    writer.WriteLine(string.Format(RenderPattern, title, content));
                }

                if(ocpos != 0)
                {
                    var prefixbytes = slice(code.Bytes,0,ocpos);
                    writer.WriteLine(string.Format(RenderPattern, "PrefixCount", state.nprefixes));
                    writer.WriteLine(string.Format(RenderPattern, "PrefixBytes", prefixbytes.FormatHex()));
                }

                if(rex(state, out var rexprefix))
                    writer.WriteLine(string.Format(RenderPattern, "RexPrefix", string.Format(Cols2Pattern, rexprefix.Format(), rexprefix.ToBitString())));

                if(state.vex_prefix != 0)
                {
                    writer.WriteLine(string.Format(RenderPattern, "VexPrefix", string.Format(Cols2Pattern, state.vex_prefix, ((uint2)(byte)(state.vex_prefix)))));
                    writer.WriteLine(string.Format(RenderPattern, "VexKind", state.vexvalid));
                    writer.WriteLine(string.Format(RenderPattern, "VL", string.Format(Cols2Pattern, state.vl, ((uint2)(byte)(state.vl)))));

                    var vexdest = string.Format("{0}{1}{2}", state.vexdest4, state.vexdest3, state.vexdest210);
                    result = DataParser.parse(vexdest, out uint5 uvdst);
                    if(result.Fail)
                        return result;

                    writer.WriteLine(string.Format(RenderPattern, "VEXDEST", string.Format(Cols2Pattern, vexdest, ((byte)uvdst).FormatHex())));
                }

                if(oc != code[ocpos])
                    return (false, string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", oc, state.modrm_byte));

                if(srm != 0)
                    writer.WriteLine(string.Format(RenderPattern, "OpCodeSrm", string.Format(Cols4Pattern, ocpos, oc.Format(true,true,true), ocbits, srm)));
                else
                    writer.WriteLine(string.Format(RenderPattern, "OpCode", string.Format(Cols3Pattern, ocpos, oc.Format(true,true,true), ocbits)));

                if(modrm(state, out var modrmval))
                {
                    var pos = state.pos_modrm;
                    if(modrmval.Value() != state.modrm_byte)
                        return (false, string.Format("Derived RM value {0} differs from parsed value {1}", modrmval, state.modrm_byte));

                    if(modrmval.Value() != code[pos])
                        return (false, string.Format("Derived RM value {0} differs from encoded value {1}", modrmval, code[pos]));

                    writer.WriteLine(string.Format(RenderPattern, "ModRM", string.Format(Cols3Pattern, pos, modrmval.Format(), modrmval.ToBitString())));
                }

                if(sib(state, out var sibval))
                {
                    var pos = state.pos_sib;
                    var sibenc = Sib.init(code[pos]);
                    if(sibenc.Value() != sibval.Value())
                        return (false, string.Format("Derived Sib value {0} differs from encoded value {1}", sibval, sibenc));

                    writer.WriteLine(string.Format(RenderPattern, "Sib", string.Format(Cols3Pattern, pos, sibval.Format(), sibval.ToBitString())));
                }

                if(state.disp_width != 0)
                    writer.WriteLine(string.Format(RenderPattern, "Disp", string.Format(Cols2Pattern, state.pos_disp, disp(state,code))));

                if(state.imm0)
                {
                    var size = NativeSize.code(state.imm_width);
                    var signed = state.imm0signed;
                    var pos = state.pos_imm;
                    var val = 0ul;
                    switch(size)
                    {
                        case NativeSizeCode.W8:
                            val = code[pos];
                        break;
                        case NativeSizeCode.W16:
                            val = slice(code.Bytes,pos, 2).TakeUInt16();
                        break;
                        case NativeSizeCode.W32:
                            val = slice(code.Bytes,pos, 4).TakeUInt32();
                        break;
                        case NativeSizeCode.W64:
                            val = slice(code.Bytes,pos, 8).TakeUInt64();
                        break;
                    }
                    writer.WriteLine(string.Format(RenderPattern, "Imm0", string.Format(Cols2Pattern, pos, val.FormatHex(zpad:false,uppercase:true))));
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


                if(state.vexvalid != 0)
                {
                    if(state.vexvalid == VexValidityKind.EVV)
                    {
                        var mkind = (EvexMapKind)(state.map);
                        writer.WriteLine(string.Format(RenderPattern, "Map", string.Format(Cols2Pattern, "EVEX", mkind)));
                    }
                    else
                    {
                        var mkind = (VexMapKind)(state.map);
                        writer.WriteLine(string.Format(RenderPattern, "Map", string.Format(Cols2Pattern, "VEX", mkind)));
                    }
                }
                else
                {
                    var mkind = (LegacyMapKind)(state.map);
                    writer.WriteLine(string.Format(RenderPattern, "Map", string.Format(Cols2Pattern, "LEGACY", mkind)));
                }

                if(state.nelem != 0)
                    writer.WriteLine(string.Format(RenderPattern, "Segments", string.Format("{0}x{1}", state.nelem, state.element_size)));

                var fields = state.ToLookup();
                var kinds = fields.Keys;
                var values = fields.Values;
                var flags = list<OperandKind>();
                for(var k=0; k<kinds.Length; k++)
                {
                    ref readonly var kind = ref skip(kinds,k);

                    switch(kind)
                    {
                        case K.HAS_MODRM:
                        case K.POS_MODRM:
                        case K.MODRM_BYTE:
                        case K.MOD:
                        case K.REG:
                        case K.RM:
                        case K.HAS_SIB:
                        case K.SIBBASE:
                        case K.SIBINDEX:
                        case K.SIBSCALE:
                        case K.POS_SIB:
                        case K.REX:
                        case K.REXB:
                        case K.REXX:
                        case K.REXR:
                        case K.REXW:
                        case K.NREXES:
                        case K.NOMINAL_OPCODE:
                        case K.POS_NOMINAL_OPCODE:
                        case K.MAX_BYTES:
                        case K.NPREFIXES:
                        case K.DISP_WIDTH:
                        case K.DISP:
                        case K.POS_DISP:
                        case K.IMM0:
                        case K.POS_IMM:
                        case K.IMM0SIGNED:
                        case K.IMM_WIDTH:
                        case K.EOSZ:
                        case K.EASZ:
                        case K.AMD3DNOW:
                        case K.MAP:
                        case K.VEXVALID:
                        case K.VEX_PREFIX:
                        case K.VEXDEST210:
                        case K.VEXDEST3:
                        case K.VEXDEST4:
                        case K.VL:
                        case K.NELEM:
                        case K.ELEMENT_SIZE:
                        case K.SRM:
                        break;
                        default:
                            if(parsed.Contains(kind))
                            {
                                ref readonly var value = ref skip(values,k);
                                switch(kind)
                                {
                                    case K.P4:
                                    case K.USING_DEFAULT_SEGMENT0:
                                    case K.USING_DEFAULT_SEGMENT1:
                                    case K.LZCNT:
                                    case K.TZCNT:
                                    case K.NEED_MEMDISP:
                                    case K.DF32:
                                    case K.DF64:
                                    case K.MUST_USE_EVEX:
                                    case K.REXRR:
                                        flags.Add(kind);
                                    break;
                                    default:
                                        writer.WriteLine(string.Format(RenderPattern, kind, value));
                                    break;
                                }
                            }
                        break;
                    }
                }

                writer.WriteLine(RenderPattern, "Flags", flags.Delimit().Format());
            }

            writer.WriteLine();

            EmittedFile(emitting, count);
            return result;
        }

    }
}