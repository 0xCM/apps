//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISystemFormatter
    {
        string Format(object src, string spec = null);
    }

    public interface ISystemFormatter<T> : ISystemFormatter
        where T : struct
    {
        string Format(T src, string spec = null);

        string ISystemFormatter.Format(object src, string spec)
            => Format((T)src, spec);
    }

    public interface ISystemFormatter<F,T> : ISystemFormatter<T>
        where F : struct, ISystemFormatter<F,T>
        where T : struct
    {

    }
}