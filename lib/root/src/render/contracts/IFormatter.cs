//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFormatter
    {
        string Format(object src);
    }

    public interface IFormatter<T> : IFormatter
    {
        string Format(T src);

        string IFormatter.Format(object src)
            => Format((T)src);
    }
}