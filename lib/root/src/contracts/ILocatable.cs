//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILocatable : ITextual
    {
        dynamic Locator {get;}
    }

    public interface ILocatable<T> : ILocatable
        where T : struct
    {
        new T Locator => (T)this;

        dynamic ILocatable.Locator
            => Locator;
    }
}