//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public AsmForms CalcForms()
            => CalcForms(LoadImportedOpcodes());

        public AsmForms CalcForms(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var result = Outcome.Success;
            var count = src.Length;
            var counter = 0u;
            var forms = list<AsmFormDescriptor>();
            var modified = list<AsmFormDescriptor>();
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref skip(src,i);
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
                    forms.Add(new AsmFormDescriptor(term,detail));
                    if(AsmSigs.modified(term.Sig))
                        modified.Add(new AsmFormDescriptor(term,detail));
                }
            }

            var tmp = list<AsmFormDescriptor>();
            tmp.AddRange(AsmFormDescriptor.unmodify(forms.ViewDeposited()));
            tmp.AddRange(modified);

            return IdentifyForms(tmp.ToArray());
        }
    }
}