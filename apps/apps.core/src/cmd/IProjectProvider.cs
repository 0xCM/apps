//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectProvider
    {
        IProjectWs Project();

        IProjectWs Project(ProjectId id);
    }

    public interface IProjectConsumer<T>
    {
        T With(IProjectProvider provider);
    }
}