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
        static readonly EnumParser<OpWidthCode> OpWidthParser = new();

        static readonly EnumParser<OpAction> OpActions = new();

        static readonly EnumParser<PointerWidthKind> PointerWidths = new();

        static readonly EnumParser<NontermKind> Nonterminals = new();

        static readonly EnumParser<XedRegId> Regs = new();

        static readonly EnumParser<ElementKind> ElementKinds = new();

        static readonly EnumParser<OpVisibility> OpVisKinds = new();

        static readonly EnumParser<GroupName> GroupNames = new();

        static readonly EnumParser<RuleOpModKind> OpModKinds = new();

        static readonly EnumParser<FieldKind> FieldKinds = new();

        static readonly EnumParser<FpuRegId> FpuRegs = new();

        static readonly EnumParser<IClass> Classes = new();

        static readonly EnumParser<IFormType> Forms = new();

        static readonly EnumParser<ExtensionKind> ExtensionKinds = new();

        static readonly EnumParser<FlagActionKind> FlagActionKinds = new();

        static readonly EnumParser<RegFlag> RegFlags = new();

        static readonly EnumParser<IsaKind> IsaKinds = new();

        static readonly EnumParser<CategoryKind> CategoryKinds = new();

        static readonly EnumParser<RuleOpName> RuleOpNames = new();

        static readonly EnumParser<RuleMacroKind> MacroKinds = new();

        static readonly EnumParser<VexClass> VexClasses = new();

        static readonly EnumParser<VexKind> VexKinds = new();

        static readonly EnumParser<OpCodeKind> OpCodeKinds = new();

        static readonly EnumParser<ErrorKind> ErrorKinds = new();

        static readonly EnumParser<ChipCode> ChipCodes = new();

        static readonly EnumParser<EASZ> EaszKinds = new();

        static readonly EnumParser<EOSZ> EoszKinds = new();

        static readonly EnumParser<ModeKind> ModeKinds = new();

        static readonly EnumParser<SMode> SModes = new();
    }
}