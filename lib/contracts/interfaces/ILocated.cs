//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILocated : ITextual
    {
        Name Name {get;}

        string ITextual.Format()
            => Name;
    }

    public interface ILocated<T> : ILocated
        where T : ITextual
    {
        T Location {get;}

        Name ILocated.Name
            => Location.Format();
    }
}