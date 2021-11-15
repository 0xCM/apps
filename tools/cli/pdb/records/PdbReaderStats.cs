//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct PdbReaderStats : IRecord<PdbReaderStats>
    {
        public uint SeqPointCount;

        public uint MethodCount;

        public uint DocCount;
    }
}