//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IExecSpec
    {

    }

    public interface IExecSpec<E> : IExecSpec
    {

    }

    /// <summary>
    /// Characterizes an executable command
    /// </summary>
    [Free]
    public interface IExecCmd
    {

    }

    [Free]
    public interface IExecCmd<C,E> : IExecCmd
        where C : IExecCmd<C,E>
        where E : IExecSpec

    {

    }
}