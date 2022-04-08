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
    using static XedDisasm;

    using K = XedRules.FieldKind;

    partial class XedDisasmSvc
    {
        void EmitDisasmProps(WsContext context, DisasmDetailDoc doc)
        {
            const string FieldPattern = "{0,-24} | {1}";
            ref readonly var file = ref doc.File;
            var dst = DisasmPropsPath(context, doc.File.Source);
            var emitting = EmittingFile(dst);
            Require.equal(doc.RowCount, file.LineCount);
            var counter = 0u;
            var state = RuleState.Empty;
            using var writer = dst.AsciWriter();
            var formatted = hashset<FieldKind>();
            formatted.Add(K.MAX_BYTES);
            formatted.Add(K.LZCNT);
            formatted.Add(K.TZCNT);

            for(var i=0; i<file.LineCount; i++)
            {
                if(i != 0)
                {
                    writer.AppendLine();
                    writer.AppendLine();
                }

                state = RuleState.Empty;
                ref readonly var detail = ref doc[i];
                ref readonly var summary = ref detail.Block.Summary;

                var cells = XedDisasm.values(file[i]);
                var lookup = XedState.update(cells, ref state);

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

                var positions = XedState.offsets(state);
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
                        map = ocindex(number);
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

                for(var j=0; j<cells.Count; j++)
                {
                    ref readonly var field = ref cells[j];
                    if(!formatted.Contains(field.Field))
                        writer.AppendLineFormat(FieldPattern, field.Field, XedRender.format(field));
                    counter++;
                }
            }
            EmittedFile(emitting,counter);
        }
    }
}