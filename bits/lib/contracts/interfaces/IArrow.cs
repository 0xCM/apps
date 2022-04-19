//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IArrow : ITextual
    {
        dynamic Source {get;}

        dynamic Target {get;}
    }

    /// <summary>
    /// Characterizes an association between two parties of heterogenous type
    /// </summary>
    /// <typeparam name="S">The first party type</typeparam>
    /// <typeparam name="T">The second party type</typeparam>
    [Free]
    public interface IArrow<S,T> : IArrow
    {
        new S Source {get;}

        new T Target {get;}

        dynamic IArrow.Source
            => ((IArrow<S,T>)this).Source;

        dynamic IArrow.Target
            => ((IArrow<S,T>)this).Target;

        string ITextual.Format()
            => string.Format(RP.Arrow, Source, Target);
    }

    [Free]
    public interface IArrow<T> : IArrow<T,T>
    {

    }

    [Free]
    public interface IArrow<S,T,K> : IArrow<S,T>
    {
        K Kind {get;}
   }
}