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

        static EnumRender<RuleTableKind> RuleTableKinds = new();

        static EnumRender<EASZ> EaszKinds = new();

        static EnumRender<EOSZ> EoszKinds = new();

        static EnumRender<DispExprKind> DispKinds = new();

        static EnumRender<NontermKind> NontermKinds = new();

        static EnumRender<GroupName> EncodingGroups = new();

        static EnumRender<ROUNDC> RoundingKinds = new();

        static EnumRender<SMode> SModes = new();

        static EnumRender<MASK> MaskCodes = new();

        static EnumRender<CellDataKind> CellDataKinds = new();

        static Symbols<ChipCode> ChipCodes;

        static Symbols<XedRegId> XedRegs;

        static EnumRender<RuleOperator> RuleOps = new();

        static Symbols<ConstraintKind> ConstraintKinds;

        static Symbols<OperandAction> OpActions;

        static Symbols<OperandWidthCode> OpWidthKinds;

        static Symbols<ElementKind> ElementTypes;

        static Symbols<RuleOpName> OpNames;

        static Symbols<OpVisibility> OpVis;

        static Symbols<IClass> Classes;

        static XedRender()
        {
            ChipCodes = Symbols.index<ChipCode>();
            XedRegs = Symbols.index<XedRegId>();
            OpWidthKinds = Symbols.index<OperandWidthCode>();
            ConstraintKinds = Symbols.index<ConstraintKind>();
            OpActions = Symbols.index<OperandAction>();
            OpNames = Symbols.index<RuleOpName>();
            OpVis = Symbols.index<OpVisibility>();
            ElementTypes = Symbols.index<ElementKind>();
            Classes = Symbols.index<IClass>();
        }
    }
}