//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static PdbModel;

    public sealed class PdbIndex : GlobalService<PdbIndex,PdbDataStore>
    {
        public uint Include(ReadOnlySpan<Document> src)
            => State.Include(src);

        protected override PdbIndex Init(out PdbDataStore state)
        {
            state = new();
            return this;
        }

        public ReadOnlySpan<Document> Documents
            => State.Documents;
    }
}