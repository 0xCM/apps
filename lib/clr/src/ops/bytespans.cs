//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial struct Clr
    {
        public static ReadOnlySpan<ReflectedByteSpan> bytespans(Type[] src)
        {
            var props = src.StaticProperties().Where(p => p.GetGetMethod() != null && p.PropertyType == typeof(ReadOnlySpan<byte>)).ToReadOnlySpan();
            var count = props.Length;
            var buffer = span<ReflectedByteSpan>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var prop = ref skip(props,i);
                ref var target = ref seek(buffer,i);
                var m = prop.GetGetMethod();
                target.Source = m.Artifact();
                target.Content = m.GetMethodBody().GetILAsByteArray();

            }
            return buffer;
        }
    }
}