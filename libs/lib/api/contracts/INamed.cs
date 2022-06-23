//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes something with a name
    /// </summary>
    public interface INamed : ITextual, IDataType
    {
        Name Name {get;}

        string ToString()
            => Name.ToString();

        string ITextual.Format()
            => Name;
    }

    [Free]
    public interface INamed<T> : INamed, IDataType<T>
        where T : unmanaged, INamed<T>
    {

    }
}