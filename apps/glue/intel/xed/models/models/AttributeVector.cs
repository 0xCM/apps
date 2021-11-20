//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public struct AttributeVector
        {
            readonly Cell128 Data;

            [MethodImpl(Inline)]
            internal AttributeVector(Cell128 data)
            {
                Data = data;
            }

            [MethodImpl(Inline)]
            public bit Test(AttributeKind index)
            {
                var i = (byte)index;
                if((byte)index <= 63)
                    return bit.test(Data.Lo, i);
                else
                    return (bit.test(Data.Hi, (byte)(i - 64)));
            }
        }
    }
}