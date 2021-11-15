//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    public abstract class Checker<T> : AppService<T>
        where T : Checker<T>, new()
    {

        readonly Index<MethodInfo> Checkers;

        protected IPolyrand Random;

        protected Checker()
        {
            Checkers = HostType.DeclaredPublicMethods().WithArity(0);
        }

        public Type HostType => typeof(T);

        protected override void OnInit()
        {
            Random =  Rng.@default();
        }

        protected virtual void Prepare()
        {

        }

        public void Run()
        {
            Babble(string.Format("Running {0} {1} checks", Checkers.Count, typeof(T).Name));
            Prepare();
            var count = Checkers.Count;
            var args = sys.empty<object>();
            for(var i=0; i<count; i++)
            {
                ref readonly var checker = ref Checkers[i];
                var result = Outcome.Success;
                var name = checker.Name;

                try
                {
                    if(checker.ReturnType == typeof(Outcome))
                    {
                        if(checker.IsStatic)
                        {
                            result = (Outcome)checker.Invoke(null, args);
                        }
                        else
                        {
                            result = (Outcome)checker.Invoke(this, args);
                        }
                    }
                    else
                    {
                        if(checker.IsStatic)
                        {
                            checker.Invoke(null, args);
                        }
                        else
                        {
                            checker.Invoke(this, args);
                        }

                    }
                }
                catch(Exception e)
                {
                    result = e;
                }

                if(result)
                {
                    Status(string.Format("{0,-32} | Pass", name));
                }
                else
                {
                    Error(string.Format("{0,-32} | Fail | {1}", name, result.Message));
                }
            }
        }
    }
}