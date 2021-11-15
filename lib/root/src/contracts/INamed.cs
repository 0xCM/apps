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
        string Name {get;}

        string ITextual.Format()
            => Name;
    }

    public interface INamed<F> : INamed
        where F : struct, INamed<F>
    {
        string INamed.Name
            => typeof(F).Name;
    }
}