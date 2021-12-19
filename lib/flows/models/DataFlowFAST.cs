//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataFlow]
    public abstract class DataFlow<F,A,S,T> : DataFlow<A,S,T>
        where S : IType
        where T : IType
        where A : IActor
        where F : DataFlow<F,A,S,T>, new()
    {
        public static F Instance = new();

        [MethodImpl(Inline)]
        protected DataFlow(A actor, S src, T dst)
            : base(actor,src,dst)
        {

        }
    }
}