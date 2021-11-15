//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum XedDatasetKind : byte
    {
        None,

        [Alias("all-chip-models")]
        ChipModels,

        [Alias("all-conversion-tables")]
        ConversionTables,

        [Alias("all-cpuid")]
        Cpuid,

        [Alias("all-dec-instructions")]
        DecInstructions,

        [Alias("all-dec-patterns")]
        DecPatterns,

        [Alias("all-element-type-base")]
        ElementTypeBase,

        [Alias("all-element-types")]
        ElementTypes,

        [Alias("all-enc-dec-patterns")]
        EncDecPatterns,

        [Alias("all-enc-instructions")]
        EncInstructions,

        [Alias("all-enc-patterns")]
        EncPatterns,

        [Alias("all-extra-widths")]
        ExtraWidths,

        [Alias("all-fields")]
        Fields,

        [Alias("all-map-descriptions")]
        MapDescriptions,

        [Alias("all-pointer-names")]
        PointerNames,

        [Alias("all-registers")]
        Registers,

        [Alias("all-state")]
        State,

        [Alias("all-widths")]
        Widths,

        [Alias("xed-cdata")]
        CData,

        [Alias("xed-idata")]
        IData,
    }
}