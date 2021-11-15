//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;

[assembly: PartId(PartId.Lib)]

namespace Z0.Parts
{
    public sealed partial class Lib : Part<Lib>
    {

    }
}

namespace Z0
{
    using static Root;

    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = Root.UnsignedInts;
    }

    [ApiHost]
    public static partial class XApi
    {

    }

    public static partial class XSvc
    {

    }

    partial struct Msg
    {
        const NumericKind Closure = Root.UnsignedInts;


        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,ClosedInterval<T>> NotIn<T>()
            where T : unmanaged
                => "not({0} in {1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotEqual<T>()
            where T : unmanaged
                => "not({0}=={1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotGreaterThan<T>()
            where T : unmanaged
                => "not({0}>{1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotLessThan<T>()
            where T : unmanaged
                => "not({0}<{1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotGreaterThanOrEqual<T>()
            where T : unmanaged
                => "not({0}>={1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotLessThanOrEqual<T>()
            where T : unmanaged
                => "not({0}<={1})";
    }
}