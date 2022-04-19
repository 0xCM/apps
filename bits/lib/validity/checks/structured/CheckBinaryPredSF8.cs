//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CheckBinaryPredSF8<T> : ICheckSF<T,T,bool>
        where T : unmanaged
    {
        public ITestContext Context {get;}

        public bool ExcludeZero {get;}

        [MethodImpl(Inline)]
        public CheckBinaryPredSF8(ITestContext context, bool xz = false)
        {
            Context = context;
            ExcludeZero = xz;
        }
    }
}