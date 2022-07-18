//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
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
        [CmdOp("gen/asm/models")]
        Outcome GenAsmCode(CmdArgs args)
        {
            var forms = Sdm.CalcForms().View;
            var buffer = dict<AsmMnemonic,List<SdmForm>>();
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

            var lookup = buffer.Keys.Map(x => (x,  (Index<SdmForm>)buffer[x].ToArray().Sort())).ToConstLookup();
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
                        var specs = g.Concretize(form);
                        Require.invariant(specs.Count > 0);
                        sources[mnemonic].Add(asm.comment(string.Format("{0} | {1}", form.Sig, form.OpCode)));
                        sources[mnemonic].Add(asm.block(asm.label(form.Name.Format()), specs));
                    }
                }
            }

            foreach(var mnemonic in sources.Keys)
            {
                var file = AsmFileSpec.define(mnemonic.Format(), sources[mnemonic].ToArray());
                var dst = file.Path(AppDb.LlvmModels("mc.models.g").SrcDir("asm"));
                EmittedFile(EmittingFile(dst), file.Save(dst));
            }

            return true;
        }
    }
}