//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using Asm;

    using static core;

    partial class CodeGenProvider
    {
        LlvmDataProvider LlvmData => Service(Wf.LlvmDataProvider);

        AsmCodeGen AsmCodeGen => Service(Wf.AsmCodeGen);


        [CmdOp("gen/asm/code")]
        Outcome GenIntel(CmdArgs args)
        {
            AsmCodeGen.Emit();

            return true;
        }

        [CmdOp("gen/asm/specs")]
        Outcome GenInstData(CmdArgs args)
        {
            var g = AsmGen.generator();
            var forms = Sdm.CalcForms();
            var count = forms.Count;
            var buffer = text.buffer();
            var counter = 0u;
            var name = "and";
            var blocks = list<AsmBlockSpec>();
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                if(form.Mnemonic == name)
                {
                    var specs = g.Concretize(form);
                    if(specs.Count == 0)
                        continue;

                    var margin = 4u;
                    buffer.AppendLine(asm.comment(string.Format("{0} | {1}", form.Sig, form.OpCode)));
                    buffer.AppendLine(asm.label(form.Name.Format()));
                    for(var j=0; j<specs.Count; j++)
                    {
                        ref readonly var spec = ref specs[j];
                        buffer.IndentLine(margin, spec.Format());
                        counter++;
                    }
                    buffer.IndentLine(margin,"ret");
                    buffer.AppendLine();
                }
                //Write(string.Format("{0,-8} | {1,-38} | {2,-48} | {3}", i, form.Name, form.Sig, form.OpCode));
            }

            //var file = asm.file(name,)

            var dst = Ws.Project(ProjectNames.McModels).SrcDir("asm") + FS.file("and", FS.Asm);
            FileEmit(buffer.Emit(), counter, dst, TextEncodingKind.Asci);

            return true;
        }
   }
}