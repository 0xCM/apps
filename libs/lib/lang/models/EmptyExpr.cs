//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EmptyExpr : IExpr
    {
        public static EmptyExpr Empty => default(EmptyExpr);
        public bool IsEmpty => true;
    }
}