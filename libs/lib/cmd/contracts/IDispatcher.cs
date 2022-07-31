//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDispatcher
    {
        Outcome Dispatch(string action, CmdArgs args);

        Outcome Dispatch(string action);

        ICmdActions Commands {get;}

        ref readonly asci32 ProviderName {get;}

        PartName Controller 
            => ExecutingPart.Id;
    }
}