//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Concurrent;
    using static core;

    using Asm;

    partial class LlvmDataLoader
    {
        public Index<string> LoadAsmMnemonicNames()
        {
            return (Index<string>)DataSets.GetOrAdd("AsmMnemonicNames", key => Load());

            Index<string> Load()
            {
                return LoadAsmVariations().Where(x => x.Mnemonic.IsNonEmpty).Map(x => x.Mnemonic.Format()).Distinct().Sort();
            }
        }
    }
}