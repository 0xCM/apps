//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static PdbModel;

    partial struct PdbServices
    {
        [MethodImpl(Inline), Op]
        public static HResult<Method> method(PdbReader reader, CliToken token)
        {
            HResult result = reader.Provider.GetMethod((int)token, out var accessor);
            if(result)
                return adapt(accessor);
            else
                return result;
        }
    }
}