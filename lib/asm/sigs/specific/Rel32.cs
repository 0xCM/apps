//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigs
    {
        public readonly struct Rel32 : IAsmSigOp<Rel32,RelToken>
        {
            public RelToken Token => RelToken.rel32;

            public string Name => "rel32";

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }
    }
}