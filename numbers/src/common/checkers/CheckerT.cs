//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Checker]
    public abstract class Checker<T> : AppService<T>, ICheckService
        where T : Checker<T>, new()
    {
        readonly Index<MethodInfo> Methods;

        readonly Index<Name> CheckNames;

        protected IPolyrand Random;

        protected Checker()
        {
            Methods = HostType.DeclaredPublicMethods().WithArity(0);
            CheckNames = Methods.Select(x => (Name)x.DisplayName());
        }

        public ReadOnlySpan<Name> Checks
            => CheckNames;

        protected override void OnInit()
        {
            Random =  Rng.@default();
        }

        protected virtual void Prepare()
        {

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
            }

            if(result)
                Ran(running,string.Format("{0,-32} | Pass", name), FlairKind.Status);
            else
                Ran(running, string.Format("{0,-32} | Fail | {1}", name, result.Message), FlairKind.Error);
        }

        public void Run()
        {
            try
            {
                Prepare();
                var count = Methods.Count;
                var args = sys.empty<object>();
                for(var i=0; i<count; i++)
                {
                    Run(Methods[i]);
                }
            }
            catch(Exception e)
            {
                Error(e);
            }
        }
    }
}