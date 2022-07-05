//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        /// <summary>
        /// Gets the names of the (unique) enumeration literals
        /// </summary>
        /// <param name="e">An enum type representative</param>
        /// <typeparam name="E">The enum type</typeparam>
         [MethodImpl(Inline)]
         public static string[] names<E>()
            where E : unmanaged, Enum
                => Enum.GetNames(typeof(E));
    }
}