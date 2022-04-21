//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedMachine
    {
        [MethodImpl(Inline)]
        T Service<T>(Func<T> factory)
            => AppService.Service(factory);

        [MethodImpl(Inline)]
        void StatusWriter(object message)
            => AppService.Wf.Row(message,FlairKind.StatusData);

        public void Reset()
        {
            RuntimeState.Reset();
            Emitter.Flush();
        }
    }
}