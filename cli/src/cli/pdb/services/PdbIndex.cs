//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class PdbIndex : GlobalService<PdbIndex,PdbDocuments>
    {
        public uint Include(ReadOnlySpan<PdbDocument> src)
            => State.Include(src);

        protected override PdbIndex Init(out PdbDocuments state)
        {
            state = new();
            return this;
        }

        public ReadOnlySpan<PdbDocument> Documents
            => State.Documents;
    }
}