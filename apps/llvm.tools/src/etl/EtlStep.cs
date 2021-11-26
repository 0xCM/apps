//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class EtlStepAttribute : Attribute
    {

    }

    [EtlStep]
    public abstract class EtlStep
    {
        public abstract void Run(IContext context);
    }

    public abstract class EtlStep<S,C,T> : EtlStep
        where C : IContext
    {
        public abstract void Run(C context);

        public override void Run(IContext context)
            => Run((C)context);
    }

    public abstract class ToolStep : EtlStep
    {

    }

}
