//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    using static core;
    using static XedModels;
    using static XedModels.ChipCode;

    partial class IntelXed
    {
        public Outcome EmitIsaForms(string chip)
        {
            var codes = Symbols.index<ChipCode>();
            var map = CalcChipMap();
            if(!codes.Lookup(chip, out var code))
                return (false, string.Format("Chip '{0}' not found", chip));
            EmitIsaForms(map,code);
            return true;
        }

        public void EmitIsaForms()
        {
            var map = CalcChipMap();
            var codes = new ChipCode[]{
                I86,
                I186,
                I286,
                I386,
                I486,
                PENTIUM,
                PENTIUM2,
                PENTIUM3,
                PENTIUM4,
                PENRYN,
                NEHALEM,
                P4PRESCOTT,
                IVYBRIDGE,
                BROADWELL,
                SKYLAKE,
                SKYLAKE_SERVER,
                TIGER_LAKE,
                CASCADE_LAKE,
                KNL,
                SAPPHIRE_RAPIDS
                };

            iter(codes, code => EmitIsaForms(map,code), PllExec);
        }

        void EmitIsaForms(XedChipMap map, ChipCode code)
        {
            var kinds = map[code].ToHashSet();
            var matches = list<FormImport>();
            var forms = LoadFormImports();
            var count = forms.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(forms,i);
                if(kinds.Contains(form.IsaKind))
                    matches.Add(form);
            }

            TableEmit(matches.ViewDeposited(), FormImport.RenderWidths, XedPaths.IsaFormsPath(code));
        }
    }
}