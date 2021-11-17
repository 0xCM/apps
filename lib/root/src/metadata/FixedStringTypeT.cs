//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FixedStringType<T> : FixedWidthType<T>
        where T : FixedStringType<T>,new()
    {
        protected FixedStringType(BitWidth storage, BitWidth content)
            : base(storage,content)
        {

        }
    }
}