//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NativeTypes
    {
        [MethodImpl(Inline)]
        public static NativeType vector(NativeCellType cellType, byte cellCount)
            => new NativeType(NativeVectorType.define(cellType, cellCount));
    }
}