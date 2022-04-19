//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataType("grid.region<t:{0}>")]
    public readonly struct GridRegion<T>
        where T : unmanaged
    {
        public GridPoint<T> UpperLeft {get;}

        public GridPoint<T> LowerRight {get;}

        [MethodImpl(Inline)]
        public GridRegion(GridPoint<T> upper, GridPoint<T> lower)
        {
            UpperLeft = upper;
            LowerRight = lower;
        }

        [MethodImpl(Inline)]
        public static implicit operator GridRegion<T>((GridPoint<T> upper, GridPoint<T> lower) src)
            => new GridRegion<T>(src.upper,src.lower);
    }
}