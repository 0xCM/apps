//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class BuildResponseHandler : AppService<BuildResponseHandler>
    {
        public void HandleBuildResponse(ToolCmdFlow flow, bool runexe)
        {
            if(flow.TargetPath.FileName.Is(FS.Exe) && runexe)
            {
                var running = Running(string.Format("Executing {0}", flow.TargetPath.ToUri()));
                var result = OmniScript.Run(flow.TargetPath, CmdVars.Empty, quiet: true, out var response);
                if (result.Fail)
                    Error(result.Message);
                else
                {
                    for (var i=0; i<response.Length; i++)
                        Babble(skip(response, i).Content);
                    Ran(running, string.Format("Executed {0}", flow.TargetPath.ToUri()));
                }
            }
        }
    }
}