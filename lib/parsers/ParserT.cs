//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Parser]
    public abstract class Parser<T> : IParser<T>
    {
        public abstract Outcome Parse(string src, out T dst);
    }
}