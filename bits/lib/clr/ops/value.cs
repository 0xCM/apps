//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    partial struct Clr
    {
        /// <summary>
        /// Extracts a value from a field using a <see cref='TypedReference'/>
        /// </summary>
        /// <param name="field">The field definition</param>
        /// <param name="tr">The source reference</param>
        [MethodImpl(Inline), Op]
        public static object value(FieldInfo field, TypedReference tr)
            => field.GetValueDirect(tr);
    }
}