//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;

    partial class XedRender
    {
        static EnumRender<BCast8Kind> BCast8 = new();

        static EnumRender<BCast16Kind> BCast16 = new();

        static EnumRender<BCast32Kind> BCast32 = new();

        static EnumRender<BCast64Kind> BCast64 = new();

        static EnumRender<ModeKind> ModeKinds = new();

        static EnumRender<VisibilityKind> VisKind = new();

        static EnumRender<VexClass> VexClasses = new();

        static EnumRender<VexKind> VexKinds = new();

        static EnumRender<VexMapKind> VexMap = new();

        static EnumRender<LegacyMapKind> LegacyMap = new();

        static EnumRender<EvexMapKind> EvexMap = new();

        static EnumRender<AttributeKind> AttribKinds = new();

        static EnumRender<OpCodeIndex> OcKindIndex = new();

        static EnumRender<RuleOpKind> RuleOpKinds = new();

        static EnumRender<RuleMacroKind> MacroKinds = new();

        static EnumRender<RuleOpModKind> OpModKinds = new();

        static EnumRender<FieldKind> FieldKinds = new();
    }
}