//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    class MemberCodeExtract
    {
        public ApiToken Token;

        public AsmHexCode StubCode;

        public Disp32 Disp;

        public BinaryCode TargetExtract;

        public MemberCodeExtract(in LiveMemberCode live, BinaryCode extracted)
        {
            Token = live.Token;
            StubCode = live.StubCode;
            Disp = live.Disp;
            TargetExtract = extracted;
        }

        public MemoryAddress EntryAddress
        {
            [MethodImpl(Inline)]
            get => Token.EntryAddress;
        }

        public MemoryAddress TargetAddress
        {
            [MethodImpl(Inline)]
            get => Token.TargetAddress;
        }

        public PolarityKind DispKind
        {
            [MethodImpl(Inline)]
            get => Disp.Negative ? PolarityKind.Left : PolarityKind.Right;
        }

    }
}