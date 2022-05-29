//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Checker]
    public abstract class Checker<T> : AppService<T>, ICheckService
        where T : Checker<T>, new()
    {
        readonly Index<MethodInfo> Methods;

        readonly Index<Name> CheckNames;

        protected IPolySource Random;

        readonly EventQueue Queue;

        IAppDb AppDb => Wf.AppDb();

        AppSvcOps AppSvc => Wf.AppSvc();

        protected Checker()
        {
            Methods = HostType.DeclaredPublicMethods().WithArity(0);
            CheckNames = Methods.Select(x => (Name)x.DisplayName());
            Queue = EventQueue.allocate(GetType(), EventRaised);
        }

        string FilePrefix => string.Format("{0}.{1}", typeof(T).Assembly.Id().Format(), typeof(T).Name);

        FS.FilePath EventLogPath
            => AppDb.Logs("checks").Path(FilePrefix + ".logs", FileKind.Log);

        FS.FilePath TablePath<R>()
            where R : struct
                => AppDb.Logs("checks").Table<R>(FilePrefix);

        FS.FilePath TablePath<R>(string label)
            where R : struct
                => AppDb.Logs("checks").Table<R>(FilePrefix + $".{label}");

        public ReadOnlySpan<Name> Checks
            => CheckNames;

        protected new void Write<X>(X src, FlairKind flair = FlairKind.Data)
            => Raise(EventFactory.data(src, flair));

        protected Action<object> Log
            => msg => Write(msg);

        protected void Raise(IWfEvent e)
            => Queue.Deposit(e);

        void EventRaised(IWfEvent e)
        {

        }

        protected void TableEmit<R>(string label, ReadOnlySpan<R> src)
            where R : struct
                => AppSvc.TableEmit(src, TablePath<R>(label));

        protected void TableEmit<R>(ReadOnlySpan<R> src)
            where R : struct
                => AppSvc.TableEmit(src, TablePath<R>());

        protected override sealed void Disposing()
        {
            Queue.Dispose();
        }

        protected sealed override void OnInit()
        {
            Random =  Rng.@default();
        }

        protected static EqualityClaim<C> Eq<C>(C actual, C expect)
            where C : IEquatable<C>
                => EqualityClaim.define(actual,expect);

        protected static void RequireEq<C>(C actual, C expect)
            where C : IEquatable<C>
        {
            require(Eq(actual,expect));
        }

        protected static void require<C>(EqualityClaim<C> claim)
            where C : IEquatable<C>
        {
            if(!claim.Actual.Equals(claim.Expect))
                Throw.message(claim.Format());
        }

        void Run(MethodInfo method)
        {
            var args = sys.empty<object>();
            var result = Outcome.Success;
            var name = method.DisplayName();
            var running = Running(name);
            var error = Z0.Error<Exception>.Empty;
            try
            {
                if(method.ReturnType == typeof(Outcome))
                {
                    if(method.IsStatic)
                        result = (Outcome)method.Invoke(null, args);
                    else
                        result = (Outcome)method.Invoke(this, args);
                }
                else if(method.ReturnType == typeof(bool))
                {
                    if(method.IsStatic)
                        result = (bool)method.Invoke(null, args);
                    else
                        result = (bool)method.Invoke(this, args);
                }
                else
                {
                    if(method.IsStatic)
                        method.Invoke(null, args);
                    else
                        method.Invoke(this, args);
                }
            }
            catch(Exception e)
            {
                result = e;
                error = e;
            }

            if(result)
                Ran(running, string.Format("{0,-32} | Pass", name), FlairKind.Status);
            else
            {
                var msg = EmptyString;
                if(error.IsNonEmpty)
                    msg = string.Format("{0,-32} | Fail | {1}", name, error);
                else
                    msg = string.Format("{0,-32} | Fail | {1}", name, result.Message);
                Ran(running, msg, FlairKind.Error);
            }
        }

        protected virtual void Prepare()
        {

        }

        protected virtual void Finish()
        {

        }

        protected virtual void Execute()
            => Execute(true);

        void Execute(bool pll)
        {
            try
            {
                iter(Methods, Run, pll);
            }
            catch(Exception e)
            {
                Error(e);
            }
        }

        void EmitLog()
        {
            var emitter = text.emitter();
            var counter = 0u;
            while(Queue.Next(out var e))
            {
                emitter.AppendLine(e.Format());
                counter++;
            }

            if(counter != 0)
                AppSvc.FileEmit(emitter.Emit(), counter, EventLogPath);
        }

        public void Run(bool pll)
        {
            EventLogPath.Delete();
            Prepare();
            Execute(pll);
            EmitLog();
            Finish();
        }

        public void Run()
            => Run(true);
    }
}