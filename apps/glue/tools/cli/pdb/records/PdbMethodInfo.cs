//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static PdbModel;

    public struct PdbMethodInfo : IRecord<PdbMethodInfo>
    {
        public CliToken Token;

        public Index<SequencePoint> SequencePoints;

        public Index<Document> Documents;
    }
}