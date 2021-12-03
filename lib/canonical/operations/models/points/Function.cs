//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    public abstract class Function<A,B>
    {
        public abstract B Eval(A a);
    }    
}