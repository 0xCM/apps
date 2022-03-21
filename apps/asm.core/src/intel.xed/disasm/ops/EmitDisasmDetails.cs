//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;
    using R = XedRules;
    using K = XedRules.FieldKind;

    partial class XedDisasmSvc
    {
        bool PllExec {get;} = true;

        public void EmitDisasmDetail(WsContext context)
        {
            Projects.XedDisasmDir(context.Project).Clear();

            var files = context.Files(FileKind.XedRawDisasm);
            exec(PllExec,
                () => EmitDisasmOps(context, files),
                () => EmitDisasmProps(context, files)
            );
        }

        void EmitDisasmOps(WsContext context, Index<FileRef> src)
            => iter(src, file => EmitDisasmOps(context,file), PllExec);

        void EmitDisasmProps(WsContext context, Index<FileRef> src)
            => iter(src, file => EmitDisasmProps(context, XedDisasm.blocks(file)), PllExec);

        void EmitDisasmOps(WsContext context, in FileRef file)
        {
            var outdir = Projects.XedDisasmDir(context.Project);
            var filename = FS.file(string.Format("{0}.ops",file.Path.FileName.WithoutExtension.Format()), FS.Txt);
            var dst = outdir + filename;
            var details = CalcDisasmDetails(context,file);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var buffer = text.buffer();
            var counter = 0u;
            foreach(var detail in details)
            {
                var mnemonic = detail.Mnemonic;
                var ops = detail.Operands;
                var count = ops.Count;

                writer.AppendLineFormat("{0,-6} {1}", counter++, mnemonic);
                writer.AppendLine(RP.PageBreak40);

                for(var i=0; i<count; i++)
                {
                    ref readonly var op = ref ops[i];
                    var spec = DisasmOpSpec.from(op);
                    render(op, buffer);
                    writer.AppendLine(buffer.Emit());

                }
                writer.WriteLine();
            }
            EmittedFile(emitting,counter);
        }

        static void render(in DisasmOpDetail src, ITextBuffer dst)
        {
            dst.AppendFormat("{0,-6} {1,-4}", src.Index, XedRender.format(src.OpName));

            var kind = opkind(src.OpName);
            ref readonly var opinfo = ref src.OpInfo;
            switch(kind)
            {
                case OpKind.Reg:
                case OpKind.Base:
                case OpKind.Index:
                    if(opinfo.Selector.IsNonEmpty)
                    {
                        dst.AppendFormat(" {0}", opinfo.Selector);
                        dst.AppendFormat("/{0}", XedRender.format(src.Action));
                    }
                break;
                default:
                    dst.AppendFormat(" {0}", XedRender.format(src.Action));
                break;
            }

            ref readonly var width = ref src.OpWidth;

            dst.AppendFormat("/{0}", XedRender.format(width.Code));

            if(width.EType.IsNonEmpty && !width.EType.IsInt)
                dst.AppendFormat("/{0}", src.OpWidth.EType);
            if(!opinfo.Visiblity.IsExplicit)
                dst.AppendFormat("/{0}", opinfo.Visiblity);
            if(opinfo.OpType != 0)
                dst.AppendFormat("/{0}", opinfo.OpType);
        }

        static Dictionary<K,R.FieldValue> update(Index<R.FieldValue> src, ref RuleState state)
        {
            XedFields.update(src, ref state);
            return src.Map(x => (x.Field, x)).ToDictionary();
        }

        void EmitDisasmProps(WsContext context, in DisasmFileBlocks src)
        {
            const string FieldPattern = "{0,-24} | {1}";

            var filename = FS.file(string.Format("{0}.props",src.Source.Path.FileName.WithoutExtension.Format()), FS.Txt);
            var dst = Projects.XedDisasmDir(context.Project) + filename;
            var emitting = EmittingFile(dst);
            XedDisasm.summarize(context, src.Source, out var summaries);
            Require.equal(summaries.RowCount, src.Count);
            var counter = 0u;
            var state = RuleState.Empty;
            using var writer = dst.AsciWriter();
            var formatted = hashset<FieldKind>();
            formatted.Add(K.MAX_BYTES);
            formatted.Add(K.LZCNT);
            formatted.Add(K.TZCNT);

            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                {
                    writer.AppendLine();
                    writer.AppendLine();
                }

                state = RuleState.Empty;
                ref readonly var summary = ref summaries[i];
                var fields = XedDisasm.fields(src[i]);
                var lookup = update(fields, ref state);

                void Emit(FieldKind kind)
                {
                    writer.AppendLineFormat(FieldPattern, kind, XedRender.format(lookup[kind]));
                    formatted.Add(kind);
                }

                void EmitValue(FieldKind kind, string value)
                {
                    writer.AppendLineFormat(FieldPattern, kind, value);
                    formatted.Add(kind);
                }

                writer.AppendLine((Address32)summary.IP);
                writer.AppendLine(RP.PageBreak80);
                writer.AppendLineFormat(FieldPattern, nameof(summary.Asm), summary.Asm);
                writer.AppendLineFormat(FieldPattern, nameof(summary.Encoded), summary.Encoded);

                Emit(K.MODE);
                Emit(K.SMODE);
                Emit(K.EASZ);
                Emit(K.EOSZ);

                if(state.DF32)
                    Emit(K.DF32);

                if(state.DF64)
                    Emit(K.DF64);

                if(lookup.TryGetValue(K.NOMINAL_OPCODE, out _))
                    Emit(K.NOMINAL_OPCODE);
                else
                    EmitValue(K.NOMINAL_OPCODE, "0x00");

                if(lookup.TryGetValue(K.SRM, out _))
                    Emit(K.SRM);

                var positions = XedRules.positions(state);
                writer.AppendLineFormat(FieldPattern, "ENCODING_OFFSETS", positions);
                formatted.Add(K.POS_NOMINAL_OPCODE);
                formatted.Add(K.POS_MODRM);
                formatted.Add(K.POS_SIB);
                formatted.Add(K.POS_IMM);
                formatted.Add(K.POS_IMM1);
                formatted.Add(K.POS_DISP);

                var vclass = VexClass.None;
                if(lookup.TryGetValue(K.VEXVALID, out var vv))
                    vclass = (VexClass)vv.Data;

                if(lookup.TryGetValue(K.MAP, out var m))
                {
                    var number = (byte)m.Data;
                    var map = XedPatterns.ocindex(vclass,number);
                    if(map == null)
                        map = XedPatterns.ocindex(number);
                    if(map != null)
                        EmitValue(K.MAP, XedRender.format(map.Value));
                }
                else
                {
                    EmitValue(K.MAP, XedRender.format(OpCodeIndex.LegacyMap0));
                }

                if(vclass != 0)
                    Emit(K.VEXVALID);

                if(vclass == VexClass.VV1)
                {
                    if(lookup.TryGetValue(K.VEX_PREFIX, out _))
                        Emit(K.VEX_PREFIX);
                }


                if(lookup.TryGetValue(K.VEXDEST4, out _))
                    Emit(K.VEXDEST4);

                if(lookup.TryGetValue(K.VEXDEST3, out _))
                    Emit(K.VEXDEST3);

                if(lookup.TryGetValue(K.VEXDEST210, out _))
                    Emit(K.VEXDEST210);

                if(state.HAS_MODRM)
                {
                    formatted.Add(K.HAS_MODRM);

                    if(lookup.TryGetValue(K.MOD, out _))
                        Emit(K.MOD);
                    else
                        EmitValue(K.MOD, "0b00");

                    if(lookup.TryGetValue(K.REG, out _))
                        Emit(K.REG);
                    else
                        EmitValue(K.REG, "0b000");

                    if(lookup.TryGetValue(K.RM, out _))
                        Emit(K.RM);
                    else
                        EmitValue(K.RM, "0b000");

                    if(lookup.TryGetValue(K.MODRM_BYTE, out _))
                        Emit(K.MODRM_BYTE);
                    else
                        EmitValue(K.MODRM_BYTE, "0x00");
                }

                if(state.HAS_SIB)
                {
                    formatted.Add(K.HAS_SIB);

                    if(lookup.TryGetValue(K.SIBSCALE, out _))
                        Emit(K.SIBSCALE);
                    else
                        EmitValue(K.SIBSCALE, "0b00");

                    if(lookup.TryGetValue(K.SIBINDEX, out _))
                        Emit(K.SIBINDEX);
                    else
                        EmitValue(K.SIBINDEX, "0b000");

                    if(lookup.TryGetValue(K.SIBBASE, out _))
                        Emit(K.SIBBASE);
                    else
                        EmitValue(K.SIBBASE, "0b000");
                }

                if(lookup.TryGetValue(K.MASK, out _))
                    Emit(K.MASK);

                if(lookup.TryGetValue(K.ZEROING, out _))
                    Emit(K.ZEROING);

                if(lookup.TryGetValue(K.NELEM, out _))
                    Emit(K.NELEM);

                if(lookup.TryGetValue(K.ELEMENT_SIZE, out _))
                    Emit(K.ELEMENT_SIZE);

                for(var j=0; j<fields.Count; j++)
                {
                    ref readonly var field = ref fields[j];
                    if(!formatted.Contains(field.Field))
                        writer.AppendLineFormat(FieldPattern, field.Field, XedRender.format(field));
                    counter++;
                }
            }
            EmittedFile(emitting,counter);
        }

        Index<DisasmDetail> EmitDisasmDetails(Index<DisasmDetail> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            var formatter = Tables.formatter<DisasmDetail>(DisasmDetail.RenderWidths);
            var headerBase = formatter.FormatHeader();
            var j = text.lastindex(headerBase, Chars.Pipe);
            headerBase = text.left(headerBase,j);
            var opheader = text.buffer();
            for(var k=0; k<6; k++)
            {
                opheader.Append("| ");
                opheader.Append(DisasmOpDetail.Header(k));
            }

            var header = string.Format("{0}{1}", headerBase, opheader.Emit());
            using var writer = dst.AsciWriter();
            writer.WriteLine(header);
            for(var i=0; i<src.Length; i++)
                writer.WriteLine(formatter.Format(src[i]));

            EmittedFile(emitting, src.Length);
            return src;
        }
    }
}