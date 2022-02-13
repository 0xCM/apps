//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<AsmFormRecord> EmitForms(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var forms = CalcForms(src);
            EmitFormDetails(forms);
            return Emit(forms);
        }

        public Index<AsmForm> CalcForms()
            => CalcForms(LoadImportedOpcodes());

        public Index<AsmForm> CalcForms(ReadOnlySpan<SdmOpCodeDetail> details)
        {
            var result = Outcome.Success;
            var count = details.Length;
            var counter = 0u;
            var forms = list<AsmForm>(count*2);
            var modified = list<AsmForm>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref skip(details,i);
                result = AsmSigs.parse(detail.Sig, out var sig);
                if(result.Fail)
                    break;

                result = AsmOpCodes.parse(detail.OpCode, out var opcode);
                if(result.Fail)
                    break;

                var terms = AsmSigs.terminate(AsmForm.define(sig,opcode));
                var kTerms = terms.Count;
                for(var j=0; j<kTerms; j++)
                {
                    ref readonly var term = ref terms[j];
                    forms.Add(term);
                    if(AsmSigs.modified(term.Sig))
                        modified.Add(term);
                }
            }

            var _unmodified = AsmSigs.unmodify(forms.ViewDeposited());
            var _final = list<AsmForm>();
            _final.AddRange(_unmodified);
            _final.AddRange(modified);
            var sorted = _final.ToArray().Sort();

            return sorted;
        }

        Index<AsmFormRecord> Emit(ReadOnlySpan<AsmForm> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmFormRecord>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var form = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                dst.Seq = i;
                dst.Sig = form.Sig;
                dst.OpCode = form.OpCode;
            }
            TableEmit(@readonly(buffer), AsmFormRecord.RenderWidths, SdmPaths.Forms());
            return buffer;
        }

        void EmitFormDetails(ReadOnlySpan<AsmForm> forms)
        {
            var count = forms.Length;
            var path = SdmPaths.FormDetailPath();
            var lookup = dict<Identifier,AsmFormDetail>();
            var buffer = alloc<AsmFormDetail>(count);

            for(var i=0u; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var form = ref skip(forms,i);
                ref readonly var sig = ref form.Sig;
                ref readonly var opcode = ref form.OpCode;
                dst.Seq = i;
                dst.Sig = sig;
                dst.OpCode = opcode;
                dst.IsRex = AsmOpCodes.rex(opcode);
                dst.IsVex = AsmOpCodes.vex(opcode);
                dst.IsEvex = AsmOpCodes.evex(opcode);

                var name = AsmSigs.identify(sig);
                var rex = AsmOpCodes.rex(opcode);
                var vex = AsmOpCodes.vex(opcode);
                var evex = AsmOpCodes.evex(opcode);
                if(lookup.TryGetValue(name, out var prior))
                {
                    if(rex)
                        name = string.Format("{0}_{1}", name, "rex");
                    else if(vex)
                        name = string.Format("{0}_{1}", name, "vex");
                    else if(evex)
                        name = string.Format("{0}_{1}", name, "evex");
                    else
                    {
                        if(AsmOpCodes.diff(prior.OpCode, opcode, out var token))
                        {
                            if(token.Kind == AsmOcTokenKind.Hex8)
                                name = string.Format("{0}_x{1}", name, token);
                            else
                                name = string.Format("{0}_{1}", name, token);
                        }
                        else
                            name = string.Format("{0}_duplicate", name);
                    }
                }
                dst.Name = name;
            }

            TableEmit(@readonly(buffer), AsmFormDetail.RenderWidths, SdmPaths.FormDetailPath());
        }
    }
}