//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DevNull : IWfEventSink
    {
        public static IWfEventSink BlackHole => default(DevNull);

        public void Deposit(IWfEvent src){ }

        public void Dispose(){ }
    }
}