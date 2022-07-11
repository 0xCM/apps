//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfEmissionLog : IDisposable
    {
        void Close();

        ref readonly WfTableFlow<T> LogEmission<T>(in WfTableFlow<T> flow)
            where T : struct;

        ref readonly WfFileWritten LogEmission(in WfFileWritten flow);
    }
}