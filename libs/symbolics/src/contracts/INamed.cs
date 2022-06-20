//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes something with a name
    /// </summary>
    public interface INamed : ITextual
    {
        Name Name {get;}

        string ITextual.Format()
            => Name;
    }

    [Free]
    public interface INamed<T> : INamed
        where T : unmanaged
    {
        new T Name {get;}

        Name INamed.Name
            => Name.ToString();

        string ToString()
            => Name.ToString();

        string ITextual.Format()
            => ToString();
    }
}