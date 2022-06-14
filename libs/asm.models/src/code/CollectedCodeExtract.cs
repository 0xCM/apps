//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class CollectedCodeExtract
    {
        public ApiToken Token;

        public AsmHexCode StubCode;

        public Disp32 Disp;

        public BinaryCode TargetExtract;

        public CollectedCodeExtract(in RawMemberCode raw, BinaryCode extracted)
        {
            Token = raw.Token;
            StubCode = raw.StubCode;
            Disp = raw.Disp;
            TargetExtract = extracted;
        }
    }
}