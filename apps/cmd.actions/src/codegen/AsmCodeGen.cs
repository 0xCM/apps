//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public partial class AsmCodeGen : AppService<AsmCodeGen>
    {
        IntelSdm Sdm => Service(Wf.IntelSdm);

        CgSvc CodeGen => Service(Wf.CodeGen);

        const string Ops1Pattern = "{0}";

        const string Ops2Pattern = "{0}, {1}";

        const string Ops3Pattern = "{0}, {1}, {2}";

        const string Ops4Pattern = "{0}, {1}, {2}, {3}";

        const string Ops5Pattern = "{0}, {1}, {2}, {3}, {4}";

        const string FormKindName = "AsmFormKind";

        const string TargetNamespace = "Z0.Asm";

        const string AsmSigTableName = "AsmSigST";

        const string MnemonicNameProvider = "AsmMnemonicNames";

        Index<string> OpsPatterns()
        {
            return state(nameof(OpsPatterns), Load);

            Index<string> Load()
            {
                var dst = alloc<string>(5);
                var i=0;
                seek(dst,i++) = Ops1Pattern;
                seek(dst,i++) = Ops2Pattern;
                seek(dst,i++) = Ops3Pattern;
                seek(dst,i++) = Ops4Pattern;
                seek(dst,i++) = Ops5Pattern;
                return dst;
            }
        }

        public void Emit()
        {
            CodeGen.SourceRoot(CgTarget.Intel).Clear(true);
            GenMnemonicNames();
            GenFormKinds();
            GenSigStrings();
        }

        public void GenMnemonicNames()
        {
            var g = CodeGen.LiteralProvider();
            var src = Sdm.LoadSigs().Select(x => x.Mnemonic.Format(Asm.MnemonicCase.Lowercase)).Distinct();
            var dst = CodeGen.SourceFile(MnemonicNameProvider, CgTarget.Intel);
            var names = src.View;
            var values = src.View;
            var literals = Literals.seq(MnemonicNameProvider, names, values);
            g.Emit(TargetNamespace, literals, dst);
        }

        SymSet CalcFormSymbols()
        {
            var forms = Sdm.CalcForms();
            var identifiers = forms.Keys;
            var count = (uint)identifiers.Length + 1;
            var dst = SymSet.create(count);
            dst.DataType = ClrEnumKind.U16;
            dst.Name = FormKindName;
            dst.Description ="Defines asm form classifiers";
            dst.Flags = false;
            dst.SymbolKind = "asm";
            var symbols = dst.Symbols;
            var values = dst.Values;
            var descriptions = dst.Descriptions;
            var names = dst.Names;
            var kinds = dst.Kinds;
            for(ushort i=0; i<count; i++)
            {
                ref var name = ref names[i];
                ref var symbol = ref symbols[i];
                ref var value = ref values[i];
                ref var desc = ref descriptions[i];
                ref var kind = ref kinds[i];
                if(i == 0)
                {
                    name = "None";
                    symbol = EmptyString;
                    value = 0;
                    desc = EmptyString;
                    kind = EmptyString;
                }
                else
                {
                    ref readonly var id = ref skip(identifiers,i - 1);
                    var form = forms[id];

                    name = id == "lock" ? "@lock" : id;
                    symbol = form.Sig.Format();
                    value = i;
                    kind = form.OpCode.Format();
                    desc = string.Format("{0} | {1} | {2}", symbol, kind, form.Description);
                }
            }
            return dst;
        }

        public void GenFormKinds()
        {
            var g = CodeGen.EnumGen();
            var src = CalcFormSymbols();
            var dst = text.buffer();
            var margin = 0u;
            dst.IndentLineFormat(margin, "namespace {0}", TargetNamespace);
            dst.IndentLine(margin, Chars.LBrace);
            margin += 4;
            g.Emit(margin, src, dst);
            margin -=4;
            dst.IndentLine(margin, Chars.RBrace);
            CodeGen.EmitFile(dst.Emit(), FormKindName, CgTarget.Intel);
        }

        public void GenSigStrings()
        {
            var forms = Sdm.CalcForms();
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

            CodeGen.GenStringTable(TargetNamespace, AsmSigTableName, FormKindName, sigs, CgTarget.Intel);
        }
    }
}