//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public class ApiServices : AppService<ApiServices>
    {

        public ApiComments Comments => Service(Wf.ApiComments);

    }
}