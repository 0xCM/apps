//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct Msg
    {
        static RenderPattern<S,Type> TransformFailedPattern<S>()
            => "The transformation {0}->{1} failed";

        public static string TransformFailed<S,T>(S src)
            => TransformFailedPattern<S>().Format(src, typeof(T));
    }
}