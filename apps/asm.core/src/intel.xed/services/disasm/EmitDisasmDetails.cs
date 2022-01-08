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

    using K = XedModels.OperandKind;

    partial class XedDisasmSvc
    {
        public Outcome EmitDisasmDetails(IProjectWs project)
        {
            var result = Outcome.Success;
            var encodings = ParseEncodings(project);
            var sources = XedPaths.DisasmSources(project);
            var blocks = XedDisasmOps.LoadFileBlocks(sources);
            var files = blocks.Keys;
            var count = files.Length;
            var dir = XedPaths.DisasmDetailDir(project);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(files,i);
                var block = blocks[path];
                var encoding = encodings[path];
                var dst = XedPaths.DisasmDetailTarget(project, path.FileName);
                result = EmitDisasmDetails(path,encoding.Encoded, block.LineBlocks, dst);
                if(result.Fail)
                    break;
            }

            return result;
        }

        Outcome EmitDisasmDetails(FS.FilePath src, ReadOnlySpan<AsmStatementEncoding> encodings, ReadOnlySpan<DisasmLineBlock> blocks, FS.FilePath dst)
        {
            const string RenderPattern = "{0,-22}: {1}";
            const string Cols2Pattern = "{0,-12} | {1,-12}";
            const string Cols3Pattern = "{0,-12} | {1,-12} | {2,-12}";
            const string Cols4Pattern = Cols3Pattern + " | {3, -12}";
            const string OpPattern = "{0,-12} | {1,-20} | {2,-12} | {3,-12} | {4,-12} | {5,-12}";

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

                writer.WriteLine(RP.PageBreak120);
                writer.WriteLine(string.Format(RenderPattern, "Statement", encoding.Asm));
                writer.WriteLine(string.Format(RenderPattern, "Encoding", string.Format(Cols2Pattern, code, code.ToBitString())));
                writer.WriteLine(string.Format(RenderPattern, "IClass", inst.Class));
                writer.WriteLine(string.Format(RenderPattern, "IForm", inst.Form));

                if(inst.Class == IClass.RET_NEAR || inst.Class == IClass.NOP)
                    continue;

                var oc = state.nominal_opcode;
                var ocpos = state.pos_nominal_opcode;
                var prefixbytes = default(Span<byte>);
                var ops = state.RuleOperands(code);
                var has_rex = rex(state, out var rexprefix);
                var has_modrm = modrm(state, out var modrmval);
                var has_sib = sib(state, out var sibval);
                var srm = state.srm;
                var ocsrm = (uint3)math.and((byte)srm, oc);
                var ocbits = (eight)(byte)oc;
                var dispwidth = state.disp_width;
                Require.equal(srm,ocsrm);

                if(oc != code[ocpos])
                    return (false, string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", oc, state.modrm_byte));

                if(srm != 0)
                    writer.WriteLine(string.Format(RenderPattern, "OpCodeSrm", string.Format(Cols3Pattern, oc.Format(true,true,true), ocbits, srm)));
                else
                    writer.WriteLine(string.Format(RenderPattern, "OpCode", string.Format(Cols2Pattern, oc.Format(true,true,true), ocbits)));

                if(ocpos != 0)
                    prefixbytes = slice(code.Bytes,0,ocpos);

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
                    var opname = XedRuleOps.name(op.Kind);
                    var opval = RuleOperand.Empty;
                    var opvalfmt = EmptyString;
                    if(ops.TryGetValue(opname, out opval))
                    {
                        if(opname == RuleOpName.RELBR)
                        {
                            var w = state.brdisp_width;
                            var val = (Hex64)opval.Value;
                            if(w <= 8)
                                opvalfmt = ((byte)val).FormatHex();
                            else if(w <= 16)
                                opvalfmt = ((ushort)val).FormatHex();
                            else if(w <= 32)
                                opvalfmt = ((uint)val).FormatHex();
                            else
                                opvalfmt = val.Format();
                        }
                        else
                            opvalfmt = opval.Format();
                    }


                    var content = string.Format(OpPattern, opname, opvalfmt, op.Action, op.Visiblity, widthdesc, op.Prop2);
                    writer.WriteLine(string.Format(RenderPattern, title, content));
                }

                if(ops.TryGetValue(RuleOpName.BASE0, out var x3))
                    writer.WriteLine(string.Format(RenderPattern, x3.Name, x3));

                if(ops.TryGetValue(RuleOpName.INDEX, out var x2))
                    writer.WriteLine(string.Format(RenderPattern, x2.Name, x2));

                if(ops.TryGetValue(RuleOpName.SCALE, out var x0))
                    writer.WriteLine(string.Format(RenderPattern, x0.Name, x0));

                if(ops.TryGetValue(RuleOpName.DISP, out var x1))
                    writer.WriteLine(string.Format(RenderPattern, x1.Name, string.Format(Cols2Pattern, x1, x1.Width)));

                if(prefixbytes.Length != 0)
                    writer.WriteLine(string.Format(RenderPattern, "PrefixBytes", prefixbytes.FormatHex()));

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
                        var vex = VexPrefixC4.init(skip(vexbytes,1), skip(vexbytes,2));
                        writer.WriteLine(string.Format(RenderPattern, "VEXBits", VexPrefixC4.BitPattern));
                        writer.WriteLine(string.Format(RenderPattern, EmptyString, vex.ToBitstring()));
                    }
                    else if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C5)
                    {
                        var vex = VexPrefixC5.init(skip(vexbytes,1));
                        writer.WriteLine(string.Format(RenderPattern, "VEXBits", VexPrefixC5.BitPattern));
                        writer.WriteLine(string.Format(RenderPattern, EmptyString, vex.ToBitstring()));
                    }

                    var vexdest = string.Format("{0}{1}{2}", state.vexdest4, state.vexdest3, state.vexdest210);
                    result = DataParser.parse(vexdest, out uint5 uvdst);
                    if(result.Fail)
                        return result;

                    writer.WriteLine(string.Format(RenderPattern, "VEXDEST", string.Format(Cols2Pattern, vexdest, ((byte)(uvdst)).FormatHex())));
                }

                if(has_modrm)
                {
                    if(modrmval.Value() != state.modrm_byte)
                        return (false, string.Format("Derived RM value {0} differs from parsed value {1}", modrmval, state.modrm_byte));

                    if(modrmval.Value() != code[state.pos_modrm])
                        return (false, string.Format("Derived RM value {0} differs from encoded value {1}", modrmval, code[state.pos_modrm]));

                    writer.WriteLine(string.Format(RenderPattern, "MODRM", string.Format(Cols2Pattern, modrmval.ToBitString(), modrmval.Format())));
                }

                if(has_sib)
                {
                    var sibenc = Sib.init(code[state.pos_sib]);
                    if(sibenc.Value() != sibval.Value())
                        return (false, string.Format("Derived Sib value {0} differs from encoded value {1}", sibval, sibenc));

                    writer.WriteLine(string.Format(RenderPattern, "SIB", string.Format(Cols2Pattern, sibval.ToBitString(), sibval.Format())));
                }

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
                    writer.WriteLine(string.Format(RenderPattern, "IMM0", val.FormatHex(zpad:false,uppercase:true)));
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

                var offsets = state.Offsets();
                writer.WriteLine(string.Format(RenderPattern, "Offsets", offsets));

                var flags = list<K>();
                if(state.need_memdisp)
                    flags.Add(K.NEED_MEMDISP);
                if(state.p4)
                    flags.Add(K.P4);
                if(state.using_default_segment0)
                    flags.Add(K.USING_DEFAULT_SEGMENT0);
                if(state.using_default_segment1)
                    flags.Add(K.USING_DEFAULT_SEGMENT1);
                if(state.lzcnt)
                    flags.Add(K.LZCNT);
                if(state.tzcnt)
                    flags.Add(K.TZCNT);
                if(state.df32)
                    flags.Add(K.DF32);
                if(state.df64)
                    flags.Add(K.DF64);
                if(state.must_use_evex)
                    flags.Add(K.MUST_USE_EVEX);
                if(state.rexrr)
                    flags.Add(K.REXRR);

                writer.WriteLine(RenderPattern, "Flags", flags.Delimit().Format());
            }

            writer.WriteLine();

            EmittedFile(emitting, count);
            return result;
        }
    }
}