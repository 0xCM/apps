//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Ccv
    {
        public struct cc<T> : ICallCv<cc<T>>
        {
            readonly Ptr8 Spec;

            public CcvKind Kind {get;}

            [MethodImpl(Inline)]
            internal cc(CcvKind kind, Ptr8 src)
            {
                Spec = src;
                Kind = kind;
            }
        }
    }
}