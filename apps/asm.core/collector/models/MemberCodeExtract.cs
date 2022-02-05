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

        public MemberCodeExtract(in RawMemberCode raw, BinaryCode extracted)
        {
            Token = raw.Token;
            StubCode = raw.StubCode;
            Disp = raw.Disp;
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

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => TargetExtract.Size;
        }

        public Label Sig
        {
            [MethodImpl(Inline)]
            get => Token.Sig;
        }
    }
}