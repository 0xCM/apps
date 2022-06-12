//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmCodeGen : AppService<AsmCodeGen>
    {
        IntelSdm Sdm => Service(Wf.IntelSdm);

        const string TargetNamespace = "Z0.Asm";

        const string AsmSigTableName = "AsmSigST";

        const string MnemonicNameProvider = "AsmMnemonicNames";

        CsLang CsLang => Service(Wf.CsLang);

        public void Emit()
        {
            CsLang.SourceRoot(CgTarget.Intel).Clear(true);
            GenMnemonicNames();
            GenFormKinds();
            GenSigStrings();
        }

        public void GenMnemonicNames()
        {
            var src = Sdm.CalcMnemonics().Select(x => x.Format(MnemonicCase.Lowercase));
            CsLang.LiteralProviders().Emit(TargetNamespace,
                Literals.seq(MnemonicNameProvider, src.View),
                CsLang.SourceFile(MnemonicNameProvider, CgTarget.Intel)
                );
        }

        public void GenFormKinds()
        {
            var descriptors = Sdm.CalcFormDescriptors();
            var src = descriptors.CalcSymbols();
            var dst = text.buffer();
            var margin = 0u;
            dst.IndentLineFormat(margin, "namespace {0}", TargetNamespace);
            dst.IndentLine(margin, Chars.LBrace);
            margin += 4;
            CsRender.@enum(margin, src, dst);
            margin -=4;
            dst.Indent(margin, Chars.RBrace);
            CsLang.EmitFile(dst.Emit(), SdmFormDescriptors.FormKindName, CgTarget.Intel);
        }

        public void GenSigStrings()
        {
            var forms = Sdm.CalcFormDescriptors();
            var keys = forms.Keys;
            var count = keys.Length + 1;
            var sigs = alloc<string>(count);
            for(var i=0; i<count; i++)
            {
                if(i==0)
                    seek(sigs,i) = EmptyString;
                else
                    seek(sigs,i) = forms[keys[i-1]].Sig.Format();
            }

            CsLang.EmitStringTable(TargetNamespace, AsmSigTableName, SdmFormDescriptors.FormKindName, sigs, CgTarget.Intel, false);
        }
    }
}