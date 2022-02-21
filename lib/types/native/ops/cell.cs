//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NativeTypes
    {
        [MethodImpl(Inline)]
        public static NativeType cell(NativeSize size, ScalarClass @class)
            => new NativeType(NativeCellType.define(size,@class));
    }
}