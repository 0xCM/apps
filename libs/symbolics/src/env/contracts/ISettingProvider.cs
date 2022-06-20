//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISettingProvider
    {
        string Name {get;}

        T Value<T>(string name)
            where T : IEquatable<T>;

        bool Value<T>(string name, out T dst)
            where T : IEquatable<T>;

        ReadOnlySpan<string> Names {get;}

        ReadOnlySpan<object> Values {get;}

        string ToString();

        string Format() => ToString();
    }

    [Free]
    public interface ISettingProvider<D> : ISettingProvider

    {
    }
}