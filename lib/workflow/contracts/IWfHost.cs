//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IWfHost : IWfStep, ITextual
    {
        Type Type {get;}

        string Name => Type.Name;

        string Identifier
            => Type.Name;
        string ITextual.Format()
            => StepId.Format();
    }

    public interface IWfHost<H> : IWfHost, IWfStep<H>
        where H : IWfHost<H>, new()
    {
        Type IWfHost.Type
            => typeof(H);

        WfStepId IWfStep.StepId
            => typeof(H);
    }

    public interface IWfHost<H,S> : IWfHost<H>
        where H : IWfHost<H,S>, new()
    {

    }

    public interface IWfHost<H,S,T> : IWfHost<H,S>
        where H : IWfHost<H,S,T>, new()
    {

    }
}