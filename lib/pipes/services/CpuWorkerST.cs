//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Threading;
    using System.Diagnostics;

    using api = CpuWorkers;

    public class CpuWorker<S,T>
        where S : struct
        where T : struct
    {
        internal CpuWorkerSettings Settings;

        IEmitter<S> Emitter;

        Func<S,T> Projector;

        IReceiver<T> Receiver;

        ProcessThread NativeThread;

        Thread ManagedThread;

        bool Continue;

        public CpuWorker(CpuWorkerSettings settings, IEmitter<S> emitter, Func<S,T> projector, IReceiver<T> receiver)
        {
            Settings = settings;
            Emitter = emitter;
            Projector = projector;
            Receiver = receiver;
        }

        public void Stop()
        {
            Continue = false;
        }

        void Execute()
        {
            NativeThread = api.thread(CurrentProcess.OsThreadId);
            NativeThread.IdealProcessor = (int)Settings.Core;
            while(Continue)
            {
                while(Emitter.Emit(out var next))
                    Receiver.Deposit(Projector(next));
                Thread.Sleep(Settings.Frequency);
            }
        }

        public void Start()
        {
            ManagedThread = new Thread(new ThreadStart(Execute));
            ManagedThread.IsBackground = true;
            ManagedThread.Name = Settings.Id.ToString();
            ManagedThread.Start();
        }
    }
}