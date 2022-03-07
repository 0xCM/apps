//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    using static core;
    using static XedModels;

    partial class IntelXed
    {
        public Outcome EmitIsaForms(string chip)
        {
            var codes = Symbols.index<ChipCode>();
            if(!codes.Lookup(chip, out var code))
                return (false, string.Format("Chip '{0}' not found", chip));
            EmitIsaForms(code);
            return true;
        }

        public void EmitIsaForms()
        {
            EmitIsaForms(ChipCode.I186);
            EmitIsaForms(ChipCode.I286);
            EmitIsaForms(ChipCode.I386);
            EmitIsaForms(ChipCode.I486);
            EmitIsaForms(ChipCode.PENTIUM);
            EmitIsaForms(ChipCode.PENTIUM2);
            EmitIsaForms(ChipCode.PENTIUM3);
            EmitIsaForms(ChipCode.PENTIUM4);
            EmitIsaForms(ChipCode.P4PRESCOTT);
            EmitIsaForms(ChipCode.BROADWELL);
            EmitIsaForms(ChipCode.SKYLAKE);
            EmitIsaForms(ChipCode.SKYLAKE_SERVER);
            EmitIsaForms(ChipCode.CASCADE_LAKE);
            EmitIsaForms(ChipCode.SAPPHIRE_RAPIDS);
        }

        void EmitIsaForms(ChipCode code)
        {
            var result = CalcChipMap(out var map);
            if(result.Fail)
                Errors.Throw(result.Message);

            var kinds = map[code].ToHashSet();
            var matches = list<XedFormImport>();
            var forms = LoadFormImports();
            var count = forms.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(forms,i);
                if(kinds.Contains(form.IsaKind))
                    matches.Add(form);
            }

            TableEmit(matches.ViewDeposited(), XedFormImport.RenderWidths, XedPaths.IsaFormsPath(code));
        }
    }
}