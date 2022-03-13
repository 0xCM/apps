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
        static EnumFormatter<BCast8Kind> BCast8 = new();

        static EnumFormatter<BCast16Kind> BCast16 = new();

        static EnumFormatter<BCast32Kind> BCast32 = new();

        static EnumFormatter<BCast64Kind> BCast64 = new();

        static EnumFormatter<ModeKind> ModeKinds = new();

        static EnumFormatter<VisibilityKind> VisKind = new();

        static EnumFormatter<VexClass> VexClasses = new();

        static EnumFormatter<VexKind> VexKinds = new();

        static EnumFormatter<VexMapKind> VexMap = new();

        static EnumFormatter<LegacyMapKind> LegacyMap = new();

        static EnumFormatter<EvexMapKind> EvexMap = new();

        static EnumFormatter<AttributeKind> AttribKinds = new();

        static EnumFormatter<OpCodeIndex> OcKindIndex = new();

        static EnumFormatter<RuleOpKind> RuleOpKinds = new();
    }
}