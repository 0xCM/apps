//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDataEmitter
    {
        object Emit();
    }

    [Free]
    public interface IDataEmitter<T> : IDataEmitter
    {
        new T Emit();

        object IDataEmitter.Emit()
            => Emit();
    }

    [Free]
    public interface ISourceEmitter : IDataEmitter<SourceText>
    {

    }
}