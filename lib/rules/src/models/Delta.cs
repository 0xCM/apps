//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        /// <summary>
        /// Represents the magnitude of the distance between two values with respect to a contectxtual metric
        /// </summary>
        public readonly struct Delta<T>
        {
            public T Left {get;}

            public T Right {get;}

            [MethodImpl(Inline)]
            public Delta(T left, T right)
            {
                Left = left;
                Right = right;
            }

            [MethodImpl(Inline)]
            public static implicit operator Delta<T>((T left, T right) src)
                => new Delta<T>(src.left, src.right);

            [MethodImpl(Inline)]
            public static implicit operator Delta<T>(Pair<T> src)
                => new Delta<T>(src.Left, src.Right);
        }
    }
}