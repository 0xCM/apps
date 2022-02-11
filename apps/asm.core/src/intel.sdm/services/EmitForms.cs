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
            return Emit(forms);
        }

        Index<AsmForm> CalcForms(ReadOnlySpan<SdmOpCodeDetail> details)
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

                var form = AsmForm.define(sig,opcode);
                var terms = AsmSigs.terminate(form);
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
    }
}