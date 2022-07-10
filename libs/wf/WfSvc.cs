//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfSvc
    {
        static IWsProject Project;

        public static ref readonly IWsProject project()
        {
            if(Project == null)
                Errors.Throw("Project is null");
            return ref Project;
        }

        [MethodImpl(Inline)]
        public static ref readonly IWsProject project(IWsProject src)
        {
            Project = src;
            return ref Project;
        }
    }
}