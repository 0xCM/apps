//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Linq;

    using static Root;
    using static core;
    using static XedModels;

    partial class IntelXed
    {
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

        Outcome EmitIsaForms(ChipCode code)
        {
            var result = LoadChipMap(out var map);
            if(result.Fail)
                return result;

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

            var dst = XedPaths.IsaFormsPath(code);
            TableEmit(matches.ViewDeposited(), XedFormImport.RenderWidths, dst);
            return result;
        }

        public Outcome EmitIsaForms(string chip)
        {
            var result = Outcome.Success;
            var symbols = ChipCodes();
            if(!symbols.Lookup(chip, out var code))
                return (false, string.Format("Chip '{0}' not found", chip));

            return EmitIsaForms(code);
        }
    }
}
