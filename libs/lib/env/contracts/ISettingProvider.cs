//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISettingProvider
    {
        VarName Name {get;}

        ReadOnlySpan<VarName> Names {get;}


        string ToString();

        string Format() => ToString();
    }

    [Free]
    public interface ISettingProvider<V> : ISettingProvider
    {
        V Value(VarName name);

        bool Value(VarName name, out V value);


        ReadOnlySpan<V> Values {get;}
    }
}