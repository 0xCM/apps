//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Threading;
    using System.Collections.Concurrent;
    using Windows;

    using static core;

    public class AsmCmdArbiter : IDisposable
    {
        public static AsmCmdArbiter start(NativeBuffer buffer)
        {
            var arbiter = new AsmCmdArbiter(buffer);
            arbiter.WorkerThread = new Thread(arbiter.Run);
            arbiter.ControlThread = new Thread(arbiter.Control);
            arbiter.Start();
            return arbiter;
        }

        readonly NativeBuffer ContextBuffer;

        Thread WorkerThread;

        uint WorkerThreadId;

        OpenHandle WorkerHandle;

        Thread ControlThread;

        uint ControlThreadId;

        ConcurrentQueue<AsmCmdJob> WorkQueue;

        ConcurrentQueue<AsmCmdJob> CompletionQueue;

        bool Stopping;

        bool WorkerStopped;

        bool ControlStopped;

        bool Verbose;

        AsmCmdArbiter(NativeBuffer buffer)
        {
            ContextBuffer = buffer;
            Stopping = false;
            WorkerStopped = false;
            ControlStopped = false;
            Verbose = false;
            WorkQueue = new();
            CompletionQueue = new();
        }

        uint ExecutingThread()
            => Kernel32.GetCurrentThreadId();

        void Control()
        {
            ControlThreadId = ExecutingThread();

            if(Verbose)
                term.babble(string.Format("Thread {0}:Beginning control loop", ControlThreadId));

            while(!Stopping)
            {
                if(CompletionQueue.TryDequeue(out var job))
                {
                    CaptureContext();
                    job.Finished();
                }

                Thread.Sleep(10);
            }

            ControlStopped = true;
        }

        void Run()
        {
            WorkerThreadId = ExecutingThread();
            if(WorkerThreadId == 0)
            {
                term.error("Thread has no identity");
                return;
            }

            WorkerHandle = OpenThread(WorkerThreadId);

            if(Verbose)
                term.babble(string.Format("Thread {0}:Beginning worker loop", WorkerThreadId));

            while(!Stopping)
            {
                while(WorkQueue.TryDequeue(out var job))
                {
                    try
                    {
                        job.Worker();
                        CompletionQueue.Enqueue(job);
                    }
                    catch(Exception e)
                    {
                        term.error(e);
                    }
                }

                Thread.Sleep(10);
            }

            WorkerStopped = true;
        }

        void Start()
        {
            WorkerThread.Start();
            ControlThread.Start();
        }

        Outcome Suspend()
        {
            var result = Kernel32.SuspendThread(WorkerHandle);
            if(result != 0)
                return (false,Kernel32.GetLastError());
            else
                return true;
        }

        Outcome Resume()
        {
            var result = Kernel32.ResumeThread(WorkerHandle);
            if(result != 0)
                return (false,Kernel32.GetLastError());
            else
                return true;
        }

        public void Dispose()
        {
            Stopping = true;
            while(!WorkerStopped && !ControlStopped)
            {
                delay(10);
                if(Verbose)
                    term.babble(string.Format("{0}: Terminating threads {1} and {2}", ExecutingThread(), ControlThreadId, WorkerThreadId));
            }
            WorkerHandle.Dispose();
        }

        public void Enque(Action worker, Action complete)
        {
            WorkQueue.Enqueue(AsmCmdJob.create(worker,complete));
        }

        public unsafe void CaptureContext()
        {
            var executing = ExecutingThread();
            if(Verbose)
                term.babble(string.Format("[{0}]:Suspending command thread {1}",  executing, WorkerThreadId));

            var outcome = Suspend();
            if(outcome.Fail)
            {
                term.error(outcome.Message);
                return;
            }

            if(Verbose)
                term.babble(string.Format("[{0}]:Capuring suspended thread context", executing, WorkerThreadId));

            ContextBuffer.Clear();
            ref var context = ref @as<byte,Amd64Context>(first(ContextBuffer.Edit));
            context.ContextFlags = ContextFlags.CONTEXT_ALL;
            outcome = Kernel32.GetThreadContext(WorkerHandle, gptr(context));
            if(outcome.Fail)
                term.error(Kernel32.GetLastError());

            if(Verbose)
                term.babble(string.Format("[{0}]:Resuming thread {1}",  executing, WorkerThreadId));

            Resume();
        }

        static OpenHandle OpenThread(uint threadId)
            => Kernel32.OpenThread(ThreadAccess.THREAD_ALL_ACCESS, true, threadId);
    }
}