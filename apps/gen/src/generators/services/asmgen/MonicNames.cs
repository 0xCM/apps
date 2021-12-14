//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmModelGen
    {
        public static string MonicFactoryName(AsmMnemonic src)
        {
            var identifier = src.Format(MnemonicCase.Lowercase);
            return identifier switch{
                "in" => "@in",
                "out" => "@out",
                "int" => "@int",
                "lock" => "@lock",
                _ => identifier
            };
        }
    }
}