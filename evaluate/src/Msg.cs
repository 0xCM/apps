//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    struct Msg
    {
        public static AppMsg BufferSizeError(ApiMemberCode code, BufferToken buffer)
            => AppMsg.info($"There are {buffer.BufferSize} available buffer bytes but at least {code.Length} is required by {code.Member.Id}");

    }
}