//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedModels.ChipCode;

    partial class XedRules
    {
        // public void EmitIsaForms()
        // {
        //     var codes = new ChipCode[]{
        //         I86,
        //         I186,
        //         I286,
        //         I386,
        //         I486,
        //         PENTIUM,
        //         PENTIUM2,
        //         PENTIUM3,
        //         PENTIUM4,
        //         PENRYN,
        //         NEHALEM,
        //         P4PRESCOTT,
        //         IVYBRIDGE,
        //         BROADWELL,
        //         SKYLAKE,
        //         SKYLAKE_SERVER,
        //         TIGER_LAKE,
        //         CASCADE_LAKE,
        //         KNL,
        //         SAPPHIRE_RAPIDS
        //         };

        //     EmitIsaForms(codes);
        // }

        // public void EmitIsaForms(ReadOnlySpan<ChipCode> codes)
        // {
        //     var map = Xed.Views.ChipMap;
        //     iter(codes, code => EmitIsaForms(map, code), PllExec);
        // }

        // void EmitIsaForms(ChipMap map, ChipCode code)
        // {
        //     var forms = Xed.Views.FormImports;
        //     var kinds = map[code].ToHashSet();
        //     var matches = list<FormImport>();
        //     var count = forms.Count;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var form = ref forms[i];
        //         if(kinds.Contains(form.IsaKind))
        //             matches.Add(form);
        //     }

        //     AppSvc.TableEmit(matches.ToArray().Sort().Resequence(), XedPaths.Service.IsaFormsPath(code));
        // }
    }
}