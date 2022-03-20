//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct XedModels
    {
        public readonly struct OpAspect<T>
            where T : unmanaged
        {
            public readonly OpAspectIndex Kind;

            public readonly T Value;

            [MethodImpl(Inline)]
            public OpAspect(OpAspectIndex kind, T value)
            {
                Kind = kind;
                Value = value;
            }

            public static implicit operator OpAspect(OpAspect<T> src)
                => new OpAspect(src.Kind, bw16(src.Value));
        }
    }
}