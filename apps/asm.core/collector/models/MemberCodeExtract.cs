//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;
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
    }

    class MemberCodeExtracts : IEnumerable<MemberCodeExtract>
    {
        readonly List<MemberCodeExtract> Data;

        public MemberCodeExtracts(params MemberCodeExtract[] src)
        {
            Data = new(src);
        }

        public IEnumerator<MemberCodeExtract> GetEnumerator()
            => ((IEnumerable<MemberCodeExtract>)Data).GetEnumerator();

        public void Include(MemberCodeExtract src)
            => Data.Add(src);

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable)Data).GetEnumerator();

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }
    }
}