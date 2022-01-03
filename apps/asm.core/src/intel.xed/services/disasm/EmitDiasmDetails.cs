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

    partial class XedDisasmSvc
    {
        public Outcome EmitDisasmDetails(IProjectWs src)
        {
            var result = Outcome.Success;
            var encodings = ParseEncodings(src);
            var blocks = XedDisasmOps.LoadBlocks(src);
            var files = blocks.Keys;
            var count = files.Length;
            var dir = ProjectDb.ProjectData() + FS.folder(string.Format("{0}.{1}", src.Name, "xed.disasm.detail"));
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(files,i);
                var block = blocks[path];
                var encoding = encodings[path];
                var dst = dir + FS.file(string.Format("{0}.details",path.FileName), FS.Txt);
                result = EmitDisasmDetails(path,encoding.Encoded, block.Blocks, dst);
                if(result.Fail)
                    break;
            }

            return result;
        }

        static AsmPrefixClass PrefixClasses(in OperandState state, in AsmHexCode code)
        {
            var ocpos = state.pos_nominal_opcode;
            var prefixbytes = default(Span<byte>);
            if(ocpos != 0)
                prefixbytes = slice(code.Bytes,0,ocpos);

            if(prefixbytes.Length == 0)
                return AsmPrefixClass.None;

            else if(state.rex)
                return AsmPrefixClass.REX;
            else if(state.vexvalid == VexValidityKind.VV1)
                return AsmPrefixClass.VEX;
            else if(state.vexvalid == VexValidityKind.EVV)
                return AsmPrefixClass.EVEX;
            else
                return AsmPrefixClass.Legacy;
        }

        Outcome EmitDisasmDetails(FS.FilePath src, ReadOnlySpan<AsmStatementEncoding> encodings, ReadOnlySpan<XedDisasm.Block> blocks, FS.FilePath dst)
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

                var offsets = EncodingOffsets.init();

                parser.ParseState(inst.Props.Edit, out var state);
                iter(parser.UnknownFields, u => Warn(string.Format("Unknown field:{0}", u)));
                iter(parser.Failures, f => Warn(string.Format("Parse failure for {0}:{1}", f.Key, f.Value)));

                var codebs = code.ToBitString();
                var parsed = parser.ParsedFields.ToHashSet();
                writer.WriteLine(RP.PageBreak120);
                writer.WriteLine(string.Format(RenderPattern, "Statement", encoding.Asm));
                writer.WriteLine(string.Format(RenderPattern, "Encoding", string.Format(Cols2Pattern, code, codebs)));
                writer.WriteLine(string.Format(RenderPattern, "IClass", inst.Class));
                writer.WriteLine(string.Format(RenderPattern, "IForm", inst.Form));

                var prefixbytes = default(Span<byte>);
                var prefixkinds = AsmPrefixKind.None;
                var oc = state.nominal_opcode;
                var ocpos = state.pos_nominal_opcode;
                offsets.OpCode =(sbyte)(state.pos_nominal_opcode);

                var srm = state.srm;
                var ocsrm = (uint3)math.and((byte)srm, oc);
                var ocbits = (eight)(byte)oc;
                Require.equal(srm,ocsrm);

                var pfxclass = PrefixClasses(state,code);

                var mapname = EmptyString;

                switch(pfxclass)
                {
                    case AsmPrefixClass.None:
                    case AsmPrefixClass.Legacy:
                    case AsmPrefixClass.REX:
                        mapname = ((LegacyMapKind)state.map).ToString();
                    break;

                    case AsmPrefixClass.VEX:
                        mapname = ((VexMapKind)state.map).ToString();
                    break;

                    case AsmPrefixClass.EVEX:
                        mapname = ((EvexMapKind)state.map).ToString();
                    break;
                }

                if(oc != code[ocpos])
                    return (false, string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", oc, state.modrm_byte));

                if(srm != 0)
                    writer.WriteLine(string.Format(RenderPattern, "OpCodeSrm", string.Format(Cols3Pattern, oc.Format(true,true,true), ocbits, srm)));
                else
                    writer.WriteLine(string.Format(RenderPattern, "OpCode", string.Format(Cols2Pattern, oc.Format(true,true,true), ocbits)));

                if(inst.Class == IClass.RET_NEAR || inst.Class == IClass.NOP)
                    continue;

                writer.WriteLine(string.Format(RenderPattern, "OpCodeMap", mapname));

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
                    prefixbytes = slice(code.Bytes,0,ocpos);
                    writer.WriteLine(string.Format(RenderPattern, "PrefixBytes", prefixbytes.FormatHex()));
                }

                // if(prefixbytes.Length > 0)
                // {
                //     prefixkinds = AsmPrefixCalcs.kinds(prefixbytes);
                //     writer.WriteLine(string.Format(RenderPattern, "PrefixKinds", prefixkinds.ToString()));
                // }

                if(rex(state, out var rexprefix))
                    writer.WriteLine(string.Format(RenderPattern, "REX", string.Format(Cols2Pattern, rexprefix.Format(), rexprefix.ToBitString())));

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
                        var vex = VexPrefixC4.init(skip(vexbytes,1),skip(vexbytes,2));
                        writer.WriteLine(string.Format(RenderPattern, "VEXBitPattern", VexPrefixC4.BitPattern));
                        writer.WriteLine(string.Format(RenderPattern, "VEXBits", vex.ToBitstring()));
                    }
                    else if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C5)
                    {
                        var vex = VexPrefixC5.init(skip(vexbytes,1));
                        writer.WriteLine(string.Format(RenderPattern, "VEXBitPattern", VexPrefixC5.BitPattern));
                        writer.WriteLine(string.Format(RenderPattern, "VEXBits", vex.ToBitstring()));
                    }

                    var vexdest = string.Format("{0}{1}{2}", state.vexdest4, state.vexdest3, state.vexdest210);
                    result = DataParser.parse(vexdest, out uint5 uvdst);
                    if(result.Fail)
                        return result;

                    writer.WriteLine(string.Format(RenderPattern, "VEXDEST", string.Format(Cols2Pattern, vexdest, ((byte)(uvdst)).FormatHex())));
                }


                if(modrm(state, out var modrmval))
                {
                    var pos = state.pos_modrm;

                    if(modrmval.Value() != state.modrm_byte)
                        return (false, string.Format("Derived RM value {0} differs from parsed value {1}", modrmval, state.modrm_byte));

                    if(modrmval.Value() != code[pos])
                        return (false, string.Format("Derived RM value {0} differs from encoded value {1}", modrmval, code[pos]));

                    if(pos != 0)
                        offsets.ModRm = (sbyte)pos;

                    writer.WriteLine(string.Format(RenderPattern, "ModRM", string.Format(Cols2Pattern, modrmval.Format(), modrmval.ToBitString())));
                }

                if(sib(state, out var sibval))
                {
                    var pos = state.pos_sib;
                    var sibenc = Sib.init(code[pos]);
                    if(sibenc.Value() != sibval.Value())
                        return (false, string.Format("Derived Sib value {0} differs from encoded value {1}", sibval, sibenc));

                    if(pos != 0)
                        offsets.Sib = (sbyte)pos;

                    writer.WriteLine(string.Format(RenderPattern, "Sib", string.Format(Cols2Pattern, sibval.Format(), sibval.ToBitString())));
                }

                if(state.disp_width != 0)
                {
                    var pos = state.pos_disp;

                    if(pos != 0)
                        offsets.Disp = (sbyte)pos;

                    writer.WriteLine(string.Format(RenderPattern, "Disp", disp(state,code)));
                }

                if(state.imm0)
                {
                    var size = NativeSize.code(state.imm_width);
                    var signed = state.imm0signed;
                    var pos = state.pos_imm;
                    var val = 0ul;

                    if(pos != 0)
                        offsets.Imm0 = (sbyte)pos;

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
                    writer.WriteLine(string.Format(RenderPattern, "Imm0", val.FormatHex(zpad:false,uppercase:true)));
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


                writer.WriteLine(string.Format(RenderPattern, "Offsets", offsets));

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
                        case K.OUTREG:
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