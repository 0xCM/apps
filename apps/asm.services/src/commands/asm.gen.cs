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

        /*
        | dec_m16        | dec m16  | FF /1            | Decrement r/m16 by 1.
        | dec_m32        | dec m32  | FF /1            | Decrement r/m32 by 1.
        | dec_m64        | dec m64  | REX.W + FF /1    | Decrement r/m64 by 1.
        | dec_m8         | dec m8   | FE /1            | Decrement r/m8 by 1.
        | dec_m8_rex     | dec m8   | REX + FE /1      | Decrement r/m8 by 1.
        | dec_r16_rex    | dec r16  | 48 +rw           | Decrement r16 by 1.
        | dec_r16        | dec r16  | FF /1            | Decrement r/m16 by 1.
        | dec_r32_rex    | dec r32  | 48 +rd           | Decrement r32 by 1.
        | dec_r32        | dec r32  | FF /1            | Decrement r/m32 by 1.
        | dec_r64        | dec r64  | REX.W + FF /1    | Decrement r/m64 by 1.
        | dec_r8         | dec r8   | FE /1            | Decrement r/m8 by 1.
        | dec_r8_rex     | dec r8   | REX + FE /1      | Decrement r/m8 by 1.
        */
        [CmdOp("asm/gen/src")]
        Outcome GenAsmCode(CmdArgs args)
        {
            var forms = Sdm.CalcForms().View;
            var buffer = dict<AsmMnemonic,List<AsmForm>>();
            for(var i=0; i<forms.Length; i++)
            {
                ref readonly var form = ref skip(forms,i);
                if(buffer.TryGetValue(form.Mnemonic, out var fl))
                {
                    fl.Add(form);
                }
                else
                {
                    buffer[form.Mnemonic] = new();
                    buffer[form.Mnemonic].Add(form);
                }

            }

            var lookup = buffer.Keys.Map(x => (x,  (Index<AsmForm>)buffer[x].ToArray().Sort())).ToConstLookup();
            var mnemonics = array<AsmMnemonic>("dec");
            var sources = dict<AsmMnemonic,List<IAsmSourcePart>>();
            var g = AsmGen.generator();

            for(var i=0; i<mnemonics.Length; i++)
            {
                ref readonly var mnemonic = ref skip(mnemonics,i);
                if(lookup.Find(mnemonic, out var selected))
                {
                    sources[mnemonic] = new();
                    sources[mnemonic].Add(AsmDirectives.define(AsmDirectiveKind.DK_INTEL_SYNTAX, AsmDirectiveOp.noprefix));
                    var count = selected.Count;
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var form = ref selected[j];
                        //Write(string.Format("{0,-16} | {1,-16} | {2,-24} | {3,-24}", form.Mnemonic, form.Name, form.Sig, form.OpCode));
                        var specs = g.Concretize(form);
                        Require.invariant(specs.Count > 0);
                        sources[mnemonic].Add(asm.comment(string.Format("{0} | {1}", form.Sig, form.OpCode)));
                        sources[mnemonic].Add(asm.block(asm.label(form.Name.Format()), specs));

                    }

                }
            }

            foreach(var mnemonic in sources.Keys)
            {
                var file = asm.file(mnemonic.Format(), sources[mnemonic].ToArray());
                var dst = file.Path(Ws.Project(ProjectNames.McModels).SrcDir("asm"));
                EmittedFile(EmittingFile(dst), file.Save(dst));
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
            iter(mnemonics, mnemonic => sources[mnemonic].Add(AsmDirectives.define(AsmDirectiveKind.DK_INTEL_SYNTAX, AsmDirectiveOp.noprefix)));

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