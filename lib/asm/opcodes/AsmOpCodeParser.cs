//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static AsmOpCodeTokens;

    public class AsmOpCodeParser
    {
        readonly ConstLookup<AsmOcTokenKind, Index<byte>> TokenValueIndex;

        readonly Index<ushort,ushort> TokenValues;

        public AsmOpCodeParser()
        {
            var tokens = OpCodeTokenSet.create();
        }

        public Outcome Parse(string src, out AsmOpCodeSpec dst)
        {
            var result = Outcome.Success;
            dst = AsmOpCodeSpec.Empty;

            return result;
        }
    }
}