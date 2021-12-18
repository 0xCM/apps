//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IActor : ITextual
    {
        Name Name {get;}

        IType SourceType {get;}

        IType TargetType {get;}

        string ITextual.Format()
            => string.Format("{0}:{1} -> {2}", Name, SourceType.Name, TargetType.Name);
    }

    public interface IActor<S,T> : IActor, IArrow<S,T>
        where S : IType
        where T : IType
    {
        IType IActor.SourceType
            => Source;

        IType IActor.TargetType
            => Target;
    }

    public interface IActor<K,S,T> : IActor<S,T>
        where S : IType
        where T : IType
        where K : unmanaged
    {
        K Modifier {get;}
    }
}