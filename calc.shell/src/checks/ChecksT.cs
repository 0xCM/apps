//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public abstract class Checks<T> : Service<T>
        where T : Checks<T>, new()
    {
        public abstract void Run();

        void Pass<C>(C claim)
            where C : IClaim
        {
            Write(string.Format("Pass | {0}", claim.Format()), FlairKind.Status);
        }

        void Fail<C>(C claim)
            where C : IClaim
        {
            Write(string.Format("Fail | {0}", claim.Format()), FlairKind.Error);
        }

        protected EqualityClaim<C> Eq<C>(C actual, C expect)
            where C : IEquatable<C>
                => EqualityClaim.define(actual,expect);

        protected void Check<C>(EqualityClaim<C> claim)
            where C : IEquatable<C>
        {
            try
            {
                if(claim.Actual.Equals(claim.Expect))
                {
                    Pass(claim);
                }
                else
                {
                    Fail(claim);
                }
            }
            catch(Exception e)
            {
                Error(e.Message);
            }
        }
    }
}