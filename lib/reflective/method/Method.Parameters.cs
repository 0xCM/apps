//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects the method parameters that satisfy a predicate
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="predicate">The predicate to match</param>
        [MethodImpl(Inline), Op]
        public static ParameterInfo[] Parameters(this MethodInfo src)
            => src.GetParameters();

        /// <summary>
        /// Selects the method parameters that satisfy a predicate
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="predicate">The predicate to match</param>
        [Op]
        public static ParameterInfo[] Parameters(this MethodInfo src, Func<ParameterInfo,bool> predicate)
            => src.Parameters().Where(predicate);

        /// <summary>
        /// Selects the methods from a stream where at least one parameter satisfies a specified predicate
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="predicate">The predicate to match</param>
        [Op]
        public static MethodInfo[] WithParameter(this MethodInfo[] src, Func<ParameterInfo,bool> predicate)
            => from m in src where m.Parameters(predicate).Count() != 0 select m;
    }
}