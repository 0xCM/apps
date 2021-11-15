//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a correlated message, accompanied by arbitrary content,
    /// that describes an occurrence of something interesting
    /// </summary>
    [Free]
    public interface IAppEvent : ICorrelated, ITextual, IChronic
    {
        FlairKind Flair
            => FlairKind.Status;

        bool IsError
            => Flair == FlairKind.Error;
    }

    /// <summary>
    /// Characterizes a reified application event
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    [Free]
    public interface IAppEvent<F> : IAppEvent, INullary<F>, ICorrelated, IChronic
        where F : IAppEvent<F>, new()
    {
        F INullary<F>.Zero
            => new F();
    }
}