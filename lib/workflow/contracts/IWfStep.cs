//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Describes a workflow step
    /// </summary>
    [Free]
    public interface IWfStep
    {
        WfStepId StepId {get;}
    }

    /// <summary>
    /// Describes a workflow step
    /// </summary>
    [Free]
    public interface IWfStep<C> : IWfStep
        where C : IWfStep<C>, new()
    {
        WfStepId IWfStep.StepId
            => new WfStepId<C>();
    }
}