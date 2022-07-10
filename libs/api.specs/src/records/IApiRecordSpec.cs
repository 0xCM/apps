//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiRecordSpec
    {


    }

    [Free]
    public interface IApiRecordSpec<R> : IApiRecordSpec
        where R : IApiRecordSpec<R>, new()
    {


    }

    [Free]
    public abstract record class ApiRecordSpec<R> : IApiRecordSpec<R>
        where R : ApiRecordSpec<R>, new()
    {

    }
}