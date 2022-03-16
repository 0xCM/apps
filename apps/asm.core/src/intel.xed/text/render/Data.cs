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

        static Symbols<ChipCode> ChipCodes;

        static Symbols<XedRegId> XedRegs;

        static Symbols<RuleOperator> RuleOps;

        static Symbols<DispExprKind> DispKinds;

        static Symbols<ConstraintKind> ConstraintKinds;

        static Symbols<NontermKind> Nonterminals;

        static Symbols<OperandAction> OpActions;

        static Symbols<OperandWidthCode> OpWidthKinds;

        static Symbols<ElementKind> ElementTypes;

        static Symbols<RuleOpName> OpNames;

        static Symbols<OpVisibility> OpVis;

        static Symbols<GroupName> EncodingGroups;

        static Symbols<IClass> Classes;

        static Symbols<EASZ> EaszKinds;

        static Symbols<EOSZ> EoszKinds;

        static Symbols<SaeRc> RoundingKinds;

        static XedRender()
        {
            ChipCodes = Symbols.index<ChipCode>();
            XedRegs = Symbols.index<XedRegId>();
            OpWidthKinds = Symbols.index<OperandWidthCode>();
            RuleOps = Symbols.index<RuleOperator>();
            DispKinds = Symbols.index<DispExprKind>();
            ConstraintKinds = Symbols.index<ConstraintKind>();
            Nonterminals = Symbols.index<NontermKind>();
            OpActions = Symbols.index<OperandAction>();
            OpNames = Symbols.index<RuleOpName>();
            OpVis = Symbols.index<OpVisibility>();
            ElementTypes = Symbols.index<ElementKind>();
            EncodingGroups = Symbols.index<GroupName>();
            Classes = Symbols.index<IClass>();
            EaszKinds = Symbols.index<EASZ>();
            EoszKinds = Symbols.index<EOSZ>();
            RoundingKinds = Symbols.index<SaeRc>();
        }
    }
}