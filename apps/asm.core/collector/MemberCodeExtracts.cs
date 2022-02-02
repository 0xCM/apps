//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;

    class MemberCodeExtracts : IEnumerable<MemberCodeExtract>
    {
        readonly List<MemberCodeExtract> Data;

        public MemberCodeExtracts(params MemberCodeExtract[] src)
        {
            Data = new(src);
        }

        public IEnumerator<MemberCodeExtract> GetEnumerator()
        {
            return ((IEnumerable<MemberCodeExtract>)Data).GetEnumerator();
        }

        public void Include(MemberCodeExtract src)
        {
            Data.Add(src);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Data).GetEnumerator();
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }
    }
}