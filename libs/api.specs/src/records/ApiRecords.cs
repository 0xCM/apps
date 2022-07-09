//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class ApiRecords
    {


    }

    public interface IApiRecordSpec
    {


    }

    public interface IApiRecordSpec<R> : IApiRecordSpec
        where R : IApiRecordSpec<R>, new()
    {


    }

    public abstract record class ApiRecordSpec<R> : IApiRecordSpec<R>
        where R : ApiRecordSpec<R>, new()
    {

    }
}