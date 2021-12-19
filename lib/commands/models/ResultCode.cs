//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ResultCode
    {
        public uint Value {get;}

        [MethodImpl(Inline)]
        public ResultCode(uint value)
        {
            Value = value;
        }

        public bool Ok
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator ResultCode(uint value)
            => new ResultCode(value);

        [MethodImpl(Inline)]
        public static bool operator true(ResultCode src)
            => src.Ok;

        [MethodImpl(Inline)]
        public static bool operator false(ResultCode src)
            => !src.Ok;
    }
}