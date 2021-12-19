//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static core;

    partial class ApiQuery
    {
        public static Index<ApiDataFlow> dataflows(Assembly[] src)
        {
            var types = src.Types().Concrete().Tagged<DataFlowAttribute>();
            var count = types.Length;
            var buffer = alloc<ApiDataFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                var f = type.Field("Instance");
                seek(buffer,i) = new ApiDataFlow((IDataFlow)f.GetValue(null));
            }
            return buffer;
        }
    }
}