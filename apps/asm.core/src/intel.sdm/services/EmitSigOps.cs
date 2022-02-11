//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Outcome EmitSigOps(ReadOnlySpan<AsmFormRecord> forms)
        {
            const string RP = "{0,-8} | {1,-16} | {2,-6} | {3,-48} | {4}";
            var result = Outcome.Success;
            var details = LoadImportedOpcodes();
            var count = details.Count;
            var dst = ProjectDb.Subdir("sdm") + FS.file("sdm.sigs.operands", FS.Csv);
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            writer.WriteLine(string.Format(RP, "FormSeq", "Mnemonic", "OpSeq", "Sig","OpCode"));

            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(forms,i);
                ref readonly var sig = ref form.Sig;
                ref readonly var opcode = ref form.OpCode;
                writer.WriteLine(string.Format(RP, form.Seq, sig.Mnemonic, EmptyString, sig, opcode));
                counter++;

                for(byte j=0; j<sig.OpCount; j++, counter++)
                    writer.WriteLine(string.Format(RP, i, sig.Mnemonic, j, sig[j], opcode));
            }

            if(result)
                EmittedFile(emitting,counter);

            return result;
        }
    }
}