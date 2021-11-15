//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    using static Root;
    using static core;

    public abstract class Interpreter<H> : IAppService<H>, IInterpreter
        where H : Interpreter<H>, new()
    {
        public IWfRuntime Wf {get; private set;}

        public static H create()
            => new H();

        public static H create(IWfRuntime wf)
        {
            var host = new H();
            host.Init(wf);
            return host;
        }

        protected Interpreter()
        {
            Name = typeof(H).Name;
            Frequency = new TimeSpan(0, 0, 0, 0, 50);
            CommandQueue = new ConcurrentQueue<string>();
            ExecLog = new ConcurrentDictionary<ulong,ExecToken>();
            DispatchKeys = new ConcurrentBag<Guid>();
            Tokens = TokenDispenser.create();
            Running = false;
            Initialized = false;
        }

        public Name Name {get;}

        Duration Frequency;

        bool Running;

        bool Initialized;

        Process Worker;

        Task SpinTask;

        ExecToken Token;

        TokenDispenser Tokens;

        readonly ConcurrentQueue<string> CommandQueue;

        readonly ConcurrentBag<Guid> DispatchKeys;

        readonly ConcurrentDictionary<ulong,ExecToken> ExecLog;

        public void Submit(string command)
        {
            try
            {
                var key = Guid.NewGuid();
                DispatchKeys.Add(key);
                CommandQueue.Enqueue(string.Format("echo dispatching:{0}", key));
                CommandQueue.Enqueue(command);
                CommandQueue.Enqueue(string.Format("echo executed:{0}", key));
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
        }

        protected virtual string StartupArgs {get;}
            = EmptyString;

        protected abstract FS.FilePath ExePath {get;}

        public Task Run()
        {
            if(!Initialized)
                throw new Exception("Not initialized!");

            Worker.Start();
            Worker.BeginOutputReadLine();
            Worker.BeginErrorReadLine();
            Running = true;
            SpinTask = core.run(() => Spin());
            return SpinTask;
        }

        public void Init(IWfRuntime wf)
        {
            try
            {
                Wf = wf;
                Worker = new Process();

                var start = new ProcessStartInfo(ExePath.Name, StartupArgs)
                {
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    ErrorDialog = false,
                    CreateNoWindow = true,
                };

                Worker.StartInfo = start;
                Worker.OutputDataReceived += OnStatus;
                Worker.ErrorDataReceived += OnError;
                Worker.EnableRaisingEvents = true;
                Worker.Exited += Exited;
                Initialized = true;
            }
            catch(Exception e)
            {
                wf.Error(e);
                throw e;
            }
        }

        public virtual void SubmitStop()
        {
            exit();
        }

        void Exited(object sender, EventArgs e)
        {
            Wf.Status("Process exit event received");
        }

        void OnStatus(object sender, DataReceivedEventArgs e)
        {
            if(e != null && e.Data != null)
                Wf.Status(e.Data);
        }

        void OnError(object sender, DataReceivedEventArgs e)
        {
            if(e != null && e.Data != null)
            {
                Wf.Error(e.Data);
            }
        }

        public void Dispose()
        {
            if(Worker != null)
                Worker.Close();
        }

        void Dispatch()
        {
            if(Running)
            {
                if(CommandQueue.TryDequeue(out var cmd))
                {
                    var token = Tokens.Open();
                    ExecLog[token.StartSeq] = token;
                    Worker.StandardInput.WriteLine(cmd);
                    Dispatch();
                }
            }
        }

        void Spin()
        {
            while(true && Running)
            {
                Dispatch();
                delay(Frequency);
            }
        }

        public ExecToken WaitForExit()
        {
            SubmitStop();
            Worker.WaitForExit();
            return Token;
        }

        public void exit()
            => Submit("exit");
    }
}