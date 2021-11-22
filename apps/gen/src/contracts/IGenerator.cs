//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IGenerator<T>
    {
        T Generate(dynamic src);
    }

    public interface IGenerator<S,T> : IGenerator<T>
    {
        T Generate(S src);

        T IGenerator<T>.Generate(dynamic src)
            => Generate((S)src);
    }
}