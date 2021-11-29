//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public interface IInterval
    {
        /// <summary>
        ///  Specifies whether the interval contains its left endpoint
        /// </summary>
        bool LeftClosed {get;}

        /// <summary>
        ///  Specifies whether the interval contains its right endpoint
        /// </summary>
        bool RightClosed {get;}

        /// <summary>
        /// The interval classification
        /// </summary>
        IntervalKind Kind {get;}

        /// <summary>
        /// The interval width
        /// </summary>
        ulong Width {get;}

        /// <summary>
        ///  Specifies whether the interval is closed
        /// </summary>
        bool Closed
        {
            [MethodImpl(Inline)]
            get => Kind == IntervalKind.Closed;
        }

        /// <summary>
        ///  Specifies whether the interval is open
        /// </summary>
        bool Open
        {
            [MethodImpl(Inline)]
            get => Kind == IntervalKind.Open;
        }

        /// <summary>
        /// Specifies whether the interval is open on the right and closed on the left, denoted by [Left,Right)
        /// </summary>
        bool RightOpen
        {
            [MethodImpl(Inline)]
            get => Kind == IntervalKind.RightOpen;
        }

        /// <summary>
        /// Specifies whether the interval is open on the left and closed on the right, denoted by (Left,Right]
        /// </summary>
        bool LeftOpen
        {
            [MethodImpl(Inline)]
            get => Kind == IntervalKind.LeftOpen;
        }
    }
}