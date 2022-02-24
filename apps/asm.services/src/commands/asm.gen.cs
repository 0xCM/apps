//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using Asm;

    using static core;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/gen/code")]
        Outcome GenIntel(CmdArgs args)
        {
            AsmCodeGen.Emit();

            return true;
        }


        [CmdOp("asm/forms/query")]
        Outcome AsmFormQuery(CmdArgs args)
        {
            var forms = Sdm.CalcForms();
            var count = forms.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                ref readonly var opcode = ref form.OpCode;
                if(AsmOpCodes.imm(opcode, out var token))
                {
                    Write(string.Format("{0} | {1}", token, form));
                }
            }


            return true;
        }

        [CmdOp("asm/gen/specs")]
        Outcome GenInstData(CmdArgs args)
        {
            var g = AsmGen.generator();
            var forms = Sdm.CalcForms();
            var count = forms.Count;
            var buffer = text.buffer();
            var counter = 0u;
            var mnemonics = hashset("and", "or", "xor");
            var sources = dict<string,List<IAsmSourcePart>>();
            iter(mnemonics, name => sources[name] = new());
            iter(mnemonics, mnemonic => sources[mnemonic].Add(AsmDirective.define(AsmDirectiveKind.DK_INTEL_SYNTAX, AsmDirectiveOp.noprefix)));

            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                var mnemonic = form.Mnemonic.Format();
                if(mnemonics.Contains(mnemonic))
                {
                    var specs = g.Concretize(form);
                    Require.invariant(specs.Count > 0);
                    sources[mnemonic].Add(asm.comment(string.Format("{0} | {1}", form.Sig, form.OpCode)));
                    sources[mnemonic].Add(asm.block(asm.label(form.Name.Format()), specs));
                }
            }

            foreach(var mnemonic in sources.Keys)
            {
                var file = asm.file(mnemonic, sources[mnemonic].ToArray());
                var dst = file.Path(Ws.Project(ProjectNames.McModels).SrcDir("asm"));
                EmittedFile(EmittingFile(dst), file.Save(dst));
            }

            return true;
        }
    }
}