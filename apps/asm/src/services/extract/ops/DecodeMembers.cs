//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static core;

    partial class ApiExtractor
    {
        Index<AsmRoutine> DecodeMembers(ApiHostCode code)
        {
            var data = code.Parsed.View;
            var count = data.Length;
            var buffer = alloc<AsmRoutine>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var member = ref skip(data,i);
                var outcome = Decoder.DecodeRoutine(member, out var decoded);
                if(outcome)
                {
                    seek(dst,i) = decoded;
                    Channel.Raise(new MemberDecodedEvent(member, decoded));
                }
                else
                {
                    Error(outcome.Message);
                }
            }
            return buffer;
        }
    }
}