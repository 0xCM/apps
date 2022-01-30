//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public partial class IntelSdm : AppService<IntelSdm>
    {
        CharMapper CharMapper => Service(Wf.CharMapper);

        SdmSigOpRules SdmRules => Service(() => SdmSigOpRules.create(Wf));

        IntelSdmPaths SdmPaths;

        protected override void OnInit()
        {
            SdmPaths = IntelSdmPaths.create(Wf);
        }

        public SymSet AsmSigSymbols()
        {
            var src = SdmRules.LoadTerminals();
            var count = src.Count + 1;
            var symset = SymSet.create(count);
            symset.Name = "AsmSigId";
            symset.DataType = ClrEnumKind.U16;
            symset.Flags = false;
            symset.SymbolKind = "asm";
            var descriptions = symset.Descriptions;
            var names = symset.Names;
            var symbols = symset.Symbols;
            var values = symset.Values;

            names[0] = "None";
            symbols[0] = EmptyString;
            descriptions[0] = EmptyString;
            values[0] = 0;
            for(var i=1; i<count; i++)
            {
                ref readonly var sig = ref src[i - 1];
                names[i] = sig.Name;
                descriptions[i] = sig.Source.Format();
                symbols[i] = sig.Target.Format();
                values[i] = i;
            }
            return symset;
        }

        TextMap SigNormalRules()
            => Data(nameof(SigNormalRules), () => Rules.textmap(SdmPaths.SigNormalRules()));

        TextReplace OcReplaceRules()
            => Data(nameof(OcReplaceRules), () => Rules.replace(SdmPaths.OcReplaceRules()));

        void Clear()
        {
            SdmPaths.Targets().Clear();
            ClearCache();
        }

        public Outcome Import()
        {
            var result = Outcome.Success;

            try
            {
                Clear();

                result = EmitCharMaps();
                if(result.Fail)
                    return result;

                result = ImportVolume(1);
                if(result.Fail)
                    return result;

                result = ImportVolume(2);
                if(result.Fail)
                    return result;

                result = ImportVolume(3);
                if(result.Fail)
                    return result;

                result = ImportVolume(4);
                if(result.Fail)
                    return result;

                result = EmitSdmSplits();
                if(result.Fail)
                    return result;

                result = EmitCombinedToc();
                if(result.Fail)
                    return result;

                result = EmitTocRecords();
                if(result.Fail)
                    return result;

                ImportOpCodes();

            }
            catch(Exception e)
            {
                result = e;
            }

            return result;
        }

        void ImportOpCodes()
        {
            var details = ImportOpCodeDetails();
            var result = SdmRules.EmitSigProductions(details, true);
            if(result.Fail)
            {
                Error(result.Message);
                return;
            }

            SdmRules.EmitTerminals();
        }
    }
}