//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a member has a name that contains {'<' | '>'}
        /// </summary>
        /// <param name="src">The member</param>
        [MethodImpl(Inline), Op]
        public static bool HasGenericName(this MemberInfo src)
            => src.Name.Contains('<') || src.Name.Contains('>');
    }
}