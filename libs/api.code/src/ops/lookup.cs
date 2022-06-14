//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static EventFactory;

    partial class ApiCode
    {
        class CollectedEncodings
        {
            readonly ConcurrentDictionary<uint,CollectedEncoding> Data;

            public CollectedEncodings()
            {
                Data = new();
            }

            public bool Include(in CollectedEncoding src)
                => Data.TryAdd(src.Token.EntryId,src);

            public Index<CollectedEncoding> Emit(bool clear = true)
            {
                var members = Data.Values.Array();
                if(clear)
                    Data.Clear();
                return members;
            }
        }
    }
}