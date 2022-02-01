//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EncodedMembers
    {
        readonly ConcurrentDictionary<uint,EncodedMember> Data;

        public EncodedMembers()
        {
            Data = new();
        }

        public bool Include(in EncodedMember src)
            => Data.TryAdd(src.Token.EntryId,src);

        public Index<EncodedMember> Emit(bool clear = true)
        {
            var members = Data.Values.Array();
            if(clear)
                Data.Clear();
            return members;
        }
    }
}