//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedParsers
    {
        readonly EnumParser<OperandWidthCode> OpWidthParser = new();

        readonly EnumParser<OperandAction> OpActions = new();

        readonly EnumParser<PointerWidthKind> PointerWidths = new();

        readonly EnumParser<NontermKind> Nonterminals = new();

        readonly EnumParser<XedRegId> Regs = new();

        readonly EnumParser<ElementKind> ElementKinds = new();

        readonly EnumParser<OpVisibility> OpVisKinds = new();

        readonly EnumParser<GroupName> GroupNames = new();

        readonly EnumParser<RuleOpModKind> OpModKinds = new();

        readonly EnumParser<FieldKind> FieldKinds = new();

        readonly EnumParser<FpuRegId> FpuRegs = new();

        readonly EnumParser<IClass> Classes = new();

        readonly EnumParser<IFormType> Forms = new();

        readonly EnumParser<ExtensionKind> ExtensionKinds = new();

        readonly EnumParser<FlagActionKind> FlagActionKinds = new();

        readonly EnumParser<RegFlag> RegFlags = new();

        readonly EnumParser<IsaKind> IsaKinds = new();

        readonly EnumParser<CategoryKind> CategoryKinds = new();

        readonly EnumParser<RuleOpName> RuleOpNames = new();

        readonly EnumParser<RuleMacroKind> MacroKinds = new();

        readonly EnumParser<VexClass> VexClasses = new();

        readonly EnumParser<VexKind> VexKinds = new();

        readonly EnumParser<OpCodeKind> OpCodeKinds = new();

        readonly EnumParser<ErrorKind> ErrorKinds = new();

        readonly EnumParser<ChipCode> ChipCodes = new();

        readonly EnumParser<EASZ> EaszKinds = new();

        readonly EnumParser<EOSZ> EoszKinds = new();

        readonly EnumParser<ModeKind> ModeKinds = new();

        readonly EnumParser<SMode> SModes = new();
    }
}