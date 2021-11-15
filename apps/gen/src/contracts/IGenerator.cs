//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IGenerator
    {

    }

    public interface IGenerator<S,T> : IGenerator
    {
        Outcome Generate(S src, T dst);
    }
}