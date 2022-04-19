//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RangeModel<T,W>
        where W : unmanaged
    {
        public T Id {get;}

        public ClosedInterval<W> Width {get;}

        [MethodImpl(Inline)]
        public RangeModel(T id, ClosedInterval<W> width)
        {
            Id = id;
            Width = width;
        }

        /// <summary>
        /// The minimum content width
        /// </summary>
        public W MinWidth
        {
            [MethodImpl(Inline)]
            get => Width.Min;
        }

        /// <summary>
        /// The maximum content width
        /// </summary>
        public W MaxWidth
        {
            [MethodImpl(Inline)]
            get => Width.Max;
        }
    }
}