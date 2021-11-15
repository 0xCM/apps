//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigs
    {
        public readonly struct Rel16: IAsmRel<Rel16>
        {
            public RelToken Kind => RelToken.rel16;

            public string Name => "rel16";

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }
    }
}