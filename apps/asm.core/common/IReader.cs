//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IReader<T>
    {
        bool Next(out T dst);

        ref readonly T Next();

        bool HasNext();

        bool Advance();
    }


    public interface ICachedReader<T> : IReader<T>
    {
        ref readonly T ViewNext();

        bool ViewNext(out T dst);
    }
}