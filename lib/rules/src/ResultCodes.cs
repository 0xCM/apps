//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct ResultCodes
    {
        public static ResultCode Ok => default;

        public static ResultCode BufferTooSmall => new ResultCode(0x01);
    }
}