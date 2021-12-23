//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static SdmModels;

    using K = SdmModels.SdmTableKind;

    partial class IntelSdm
    {
        [Op]
        public static K tablekind(string name)
            => name switch {
                "OpCodes" => K.OpCodes,
                "Encoding" => K.EncodingRule,
                "BinaryFormat" => K.BinaryFormat,
                "Intrinsics" => K.Intrinsics,
                "Notes" => K.Intrinsics,
                _ => parse(name, out TableNumber dst)
                    ? K.Numbered : K.None
            };
    }
}