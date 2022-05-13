//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedRecords;
    using static core;

    partial class XedImport
    {
        public class InstBlockReceiver : IInstBlockReceiver
        {
            ConcurrentDictionary<InstForm,LineInterval<InstForm>> Received = new();

            ConcurrentDictionary<InstForm,string> Data = new();

            ConcurrentBag<InstBlockImport> Imports = new();

            SortedLookup<InstForm,uint> FormSeq;

            ConcurrentDictionary<InstForm,string> Descriptions = new();

            ConcurrentDictionary<InstForm,string> Headers = new();

            /*
                amd_3dnow_opcode: None
                attributes: LOCKABLE
                avx512_tuple: None
                avx512_vsib: None
                avx_vsib: None
                broadcast_allowed: False
                category: BINARY
                cpl: 3
                cpuid: ['N/A']
                default_64b: False
                easz: aszall
                element_size: None
                eosz: oszall
                explicit_operands: ['MEM', 'IMM']
                extension: BASE
                f2_required: False
                f3_required: False
                flags: MUST [ of-mod sf-mod zf-mod af-mod pf-mod cf-tst cf-mod ]
                has_imm8: True
                has_imm8_2: False
                has_immz: False
                has_modrm: True
                iclass: ADC
                iform: ADC_MEMv_IMMb
                imm_sz: 1
                implicit_operands: ['none']
                isa_set: I86
                lower_nibble: 3
                map: 0
                memop_rw: mem-rw
                mod_required: 00/01/10
                mode_restriction: unspecified
                no_prefixes_allowed: False
                ntname: INSTRUCTIONS
                opcode: 0x83
                opcode_base10: 131
                operand_list: ['MEM0:rw:v', 'IMM0:r:b:i8']
                operands: MEM0:rw:v IMM0:r:b:i8
                osz_required: False
                parsed_operands: [<opnds.operand_info_t object at 0x00000169CB35D730>, <opnds.operand_info_t object at 0x00000169CB35D760>]
                partial_opcode: False
                pattern: 0x83 MOD[mm] MOD!=3 REG[0b010] RM[nnn] MODRM() SIMM8() LOCK=0
                real_opcode: Y
                reg_required: 2
                rexw_prefix: unspecified
                rm_required: unspecified
                scalar: False
                sibmem: False
                space: legacy
                undocumented: False
                upper_nibble: 8
                vl: n/a
                EOSZ_LIST: [16, 32, 64]
            */

            readonly AppServices AppSvc;

            XedPaths XedPaths;

            public InstBlockReceiver(AppServices svc)
            {
                AppSvc = svc;
                XedPaths = XedPaths.Service;
            }

            public void Accept(InstDataBlock block)
            {
                Received.TryAdd(block.Range.Id, block.Range);
                var emitter = text.emitter();
                block.Render(emitter);
                var emitted = emitter.Emit();
                Data.TryAdd(block.Range.Id, emitted);
            }

            void Process(InstForm form)
            {
                var record = InstBlockImport.Empty;
                record.Seq = FormSeq[form];
                record.Form = form;
                var range = Received[form];
                var content = Data[form];
                Descriptions[form] = content;
                Headers[form] = string.Format("{0,-64} | Source[{1:D6}, {2:D6}]", form, (uint)range.MinLine, (uint)range.MaxLine);
                Imports.Add(record);
            }

            Index<InstForm> CalcFormSeq()
            {
                var keys = Data.Keys.Index().Sort();
                var dst = dict<InstForm,uint>();
                for(var i=0u; i<keys.Count; i++)
                    dst[keys[i]] = i;
                FormSeq = dst;
                return keys;
            }

            public void Emit()
            {
                var forms = CalcFormSeq();
                iter(forms,Process,true);
                var dst = XedPaths.Imports().Path("instblocks", FileKind.Txt);
                using var writer = dst.AsciWriter();
                var emitting = AppSvc.EmittingFile(dst);
                for(var i=0u; i<forms.Count; i++)
                {
                    ref readonly var key = ref forms[i];
                    if(key.IsEmpty)
                        continue;

                    writer.AppendLine(Headers[key]);
                    writer.WriteLine(RP.PageBreak120);
                    writer.AppendLine(Descriptions[key]);
                    writer.WriteLine();
                }

                AppSvc.EmittedFile(emitting, forms.Count);
            }
        }
    }
}