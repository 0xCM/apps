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
            var source = list<IAsmSourcePart>();
            source.Add(AsmDirective.define(AsmDirectiveKind.DK_INTEL_SYNTAX, AsmDirectiveOp.noprefix));
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                if(form.Mnemonic == name)
                {
                    var specs = g.Concretize(form);
                    if(specs.Count == 0)
                        continue;


                    source.Add(asm.comment(string.Format("{0} | {1}", form.Sig, form.OpCode)));
                    source.Add(asm.block(asm.label(form.Name.Format()), specs));
                }
            }

            var file = asm.file(name, source.ToArray());
            var dst = file.Path(Ws.Project(ProjectNames.McModels).SrcDir("asm"));
            var emitting = EmittingFile(dst);
            EmittedFile(emitting, file.Save(dst));


            return true;
        }
   }
}