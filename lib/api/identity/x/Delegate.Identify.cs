//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        /// <summary>
        /// Determines whether a type is classified as an intrinsic vector
        /// </summary>
        /// <param name="t">The type to test</param>
        [Op]
        public static bool IsVector(this Type t)
            => ApiIdentity.IsVector(t);

        /// <summary>
        /// Identifies a delegate
        /// </summary>
        /// <param name="m">The method to identify</param>
        [Op]
        public static OpIdentity Identify(this Delegate m)
            => ApiIdentity.identify(m);
    }
}