//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Clr
    {
        // public static Index<ReflectedByteSpan> bytespans(Type[] src)
        // {
        //     var props = src.StaticProperties().Where(p => p.GetGetMethod() != null && p.PropertyType == typeof(ReadOnlySpan<byte>)).ToReadOnlySpan();
        //     var count = props.Length;
        //     var dst = alloc<ReflectedByteSpan>(count);
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var prop = ref skip(props,i);
        //         //ref var target = ref seek(buffer,i);
        //         var method = prop.GetGetMethod();
        //         seek(dst,i) = new ReflectedByteSpan(method.Artifact(), method.GetMethodBody().GetILAsByteArray());
        //         // target.Source = m.Artifact();
        //         // target.Content = m.GetMethodBody().GetILAsByteArray();

        //     }
        //     return dst;
        // }
    }
}