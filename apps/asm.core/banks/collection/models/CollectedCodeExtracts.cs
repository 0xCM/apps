//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;
    using Asm;

    class CollectedCodeExtract
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

    class CollectedCodeExtracts : IEnumerable<CollectedCodeExtract>
    {
        readonly List<CollectedCodeExtract> Data;

        public CollectedCodeExtracts(params CollectedCodeExtract[] src)
        {
            Data = new(src);
        }

        public IEnumerator<CollectedCodeExtract> GetEnumerator()
            => ((IEnumerable<CollectedCodeExtract>)Data).GetEnumerator();

        public void Include(CollectedCodeExtract src)
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