//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    partial class AsmModelGen
    {
        ReadOnlySpan<string> LoadMnemonicNames()
            => Wf.IntelXed().ClassNames();
    }
}