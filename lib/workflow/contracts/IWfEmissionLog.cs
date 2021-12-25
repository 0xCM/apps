//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IWfEmissionLog : IDisposable
    {
        ref readonly WfTableFlow<T> LogEmission<T>(in WfTableFlow<T> flow)
            where T : struct;

        ref readonly WfFileFlow LogEmission(in WfFileFlow flow);
    }
}