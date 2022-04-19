//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Constructs a set of markers from a type that defines literal string values and/or static <see cref='TextMarker'/> properties
        /// </summary>
        /// <param name="provider">The type to query</param>
        [Op]
        public static TextMarkers markers(Type provider)
        {
            var fields = provider.LiteralFields(typeof(string)).Tagged<TextMarkerAttribute>().ToReadOnlySpan();
            var count = fields.Length;
            if(count == 0)
                return TextMarkers.Empty;

            var buffer = alloc<TextMarker>(count);
            ref var dst = ref first(buffer);
            var j=0;
            for(var i=0; i<count; i++, j++)
            {
                ref readonly var field = ref skip(fields,i);
                seek(dst,j) = marker(field.Name, (string)field.GetRawConstantValue());

            }
            return new TextMarkers(buffer);
        }
    }
}