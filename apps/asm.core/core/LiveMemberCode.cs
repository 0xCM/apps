//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public struct LiveMemberCode
    {
        public ApiToken Token;

        public MemoryAddress Entry;

        public MemoryAddress Target;

        public Disp32 Disp;

        public AsmHexCode StubCode;

        public OpUri Uri;

        public JmpStub Stub;
    }
}