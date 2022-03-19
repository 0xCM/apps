//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    using K = XedRules.FieldKind;

    partial class XedCmdProvider
    {
        XedDisasmSvc XedDisasmSvc => Service(Wf.XedDisasm);

        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            var actions = new Action[]{CheckDisasm1,CheckDisasm2};
            iter(actions, a => a(), true);
            return true;
        }

        void CheckDisasm2(WsContext context, in FileRef file)
        {
            var details = XedDisasmSvc.CalcDisasmDetails(context,file);
            var dst = AppDb.Log("xed",file.DocName, FileKind.Txt);
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
            ref readonly var selector = ref src.OpInfo.Selector;
            switch(kind)
            {
                case RuleOpKind.Reg:
                case RuleOpKind.Base:
                case RuleOpKind.Index:
                    if(selector.IsNonEmpty)
                    {
                        dst.AppendFormat(" {0}",selector);
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
            if(!src.OpInfo.Visiblity.IsExplicit)
                dst.AppendFormat("/{0}", src.OpInfo.Visiblity);
            if(src.OpInfo.LookupKind != 0)
                dst.AppendFormat("/{0}", src.OpInfo.LookupKind);
        }

        void CheckDisasm2()
        {
            var context = Projects.Context(Project());
            var files = context.Files(FileKind.XedRawDisasm);
            iter(files, file => CheckDisasm2(context,file),true);

        }

        void CheckDisasm1()
        {
            var project = Project();
            var context = Projects.Context(project);
            var files = context.Files(FileKind.XedRawDisasm);
            AppDb.Logs("xed.props").Clear();
            iter(files, file => CheckDisasm(context, XedDisasm.blocks(file)),true);
        }

        void CheckDisasm(WsContext context, in DisasmFileBlocks src)
        {
            const string FieldPattern = "{0,-24} | {1}";
            var name = src.Source.DocName;
            var dst = AppDb.Log("xed.props", name, FileKind.Log);
            var emitting = EmittingFile(dst);
            XedDisasm.CalcSummaryDoc(context, src.Source, out var summaries);
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
                ref readonly var block = ref src[i];
                ref readonly var summary = ref summaries[i];
                var fields = XedDisasm.fields(block);
                var lookup = fields.Map(x => (x.Field, x)).ToDictionary();
                XedFields.update(fields, ref state);

                void Emit(FieldKind kind)
                {
                    writer.AppendLineFormat(FieldPattern, kind, XedRender.format(lookup[kind]));
                    formatted.Add(kind);
                }

                void Emit2(FieldKind kind, string value)
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
                    Emit2(K.NOMINAL_OPCODE, "0x00");

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
                    var map = ocindex(vclass,number);
                    if(map == null)
                        map = ocindex(number);
                    if(map != null)
                        Emit2(K.MAP, XedRender.format(map.Value));
                }
                else
                {
                    Emit2(K.MAP, XedRender.format(OpCodeIndex.LegacyMap0));
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
                        Emit2(K.MOD, "0b00");

                    if(lookup.TryGetValue(K.REG, out _))
                        Emit(K.REG);
                    else
                        Emit2(K.REG, "0b000");

                    if(lookup.TryGetValue(K.RM, out _))
                        Emit(K.RM);
                    else
                        Emit2(K.RM, "0b000");

                    if(lookup.TryGetValue(K.MODRM_BYTE, out _))
                        Emit(K.MODRM_BYTE);
                    else
                        Emit2(K.MODRM_BYTE, "0x00");
                }

                if(state.HAS_SIB)
                {
                    formatted.Add(K.HAS_SIB);

                    if(lookup.TryGetValue(K.SIBSCALE, out _))
                        Emit(K.SIBSCALE);
                    else
                        Emit2(K.SIBSCALE, "0b00");

                    if(lookup.TryGetValue(K.SIBINDEX, out _))
                        Emit(K.SIBINDEX);
                    else
                        Emit2(K.SIBINDEX, "0b000");

                    if(lookup.TryGetValue(K.SIBBASE, out _))
                        Emit(K.SIBBASE);
                    else
                        Emit2(K.SIBBASE, "0b000");
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
    }
}