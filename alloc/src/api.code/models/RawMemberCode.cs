//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    struct RawMemberCode
    {
        public ApiToken Token;

        public Disp32 Disp;

        public AsmHexCode StubCode;

        public OpUri Uri;

        public JmpStub Stub;

        public MemoryAddress Entry;

        public MemoryAddress Target;
    }
}