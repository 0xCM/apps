//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ScalarType<T> : FixedWidthType<T>
        where T : ScalarType<T>, new()
    {
        protected ScalarType(BitWidth storage, BitWidth content)
            : base(storage,content)
        {

        }
    }
}