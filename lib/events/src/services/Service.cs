//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class Service<H> : IService
        where H : Service<H>, new()
    {
        /// <summary>
        /// Instantites the serice without initialization
        /// </summary>
        [MethodImpl(Inline)]
        protected static H @new() => new H();

        public EnvData Env {get; protected set;}

        /// <summary>
        /// Creates and initializes the service
        /// </summary>
        /// <param name="wf">The source workflow</param>
        public static H create(IServiceContext ctx)
        {
            var service = @new();
            service.Init(ctx);
            return service;
        }

        protected IEnvPaths Paths {get; private set;}

        protected IServiceContext Context {get; private set;}

        protected IServiceContext Wf => Context;

        EventSignal Signal;

        public void Init(IServiceContext ctx)
        {
            Context = ctx;
            Env = ctx.Env;
            Paths = new EnvPaths(Env);
            Signal = EventSignals.signal(ctx.EventSink, typeof(H));
            Initializer((H)this);
            Initialized();
        }

        protected virtual void Initialized() {}

        protected Service()
        {
            Initializer = (svc) => {};
        }

        Action<H> Initializer;

        protected Service(Action<H> init)
        {
            Initializer = init;
        }

        protected BabbleEvent<T> Babble<T>(T src)
            => Signal.Babble(src);

        protected StatusEvent<T> Status<T>(T src)
            => Signal.Status(src);

        protected WarnEvent<T> Warn<T>(T src)
        {
            return Signal.Warn(src);
        }

        protected ErrorEvent<T> Error<T>(T src)
        {
            return Signal.Error(src);
        }

        protected ProcessingFileEvent Processing(FS.FilePath src)
        {
            return Signal.Processing(src);
        }

        protected RunningEvent Running()
            => Signal.Running();

        protected RunningEvent<T> Running<T>(T data)
            => Signal.Running(data);

        protected RanEvent<T> Ran<T>(RunningEvent<T> e, T data)
            => Signal.Ran(data);

        protected RanEvent<T> Ran<T>(RunningEvent<T> e)
            => Signal.Ran(e.Payload.Data);

        protected RanEvent<RunningEvent> Ran(RunningEvent e)
            => Signal.Ran(e);

        protected ProcessedFileEvent Processed(ProcessingFileEvent e)
            => Signal.Processed(e.SourcePath);

        protected EmittingFileEvent Emitting(FS.FilePath src)
            => Signal.EmittingFile(src);

        protected EmittedFileEvent Emitted(EmittingFileEvent e, Count metric)
            => Signal.EmittedFile(metric, e.Target);

        protected DataEvent<T> Write<T>(in T src, FlairKind? flair = null)
            => Signal.Data(src,flair);

        protected void Write<T>(string name, T value, FlairKind flair)
            => Signal.Data(RP.attrib(name, value), flair);
    }
}