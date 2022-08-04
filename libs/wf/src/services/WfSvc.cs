//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfSvc
    {
        static IProjectWorkspace Project;

        public static ref readonly IProjectWorkspace project()
        {
            if(Project == null)
                Errors.Throw("Project is null");
            return ref Project;
        }

        [MethodImpl(Inline)]
        public static ref readonly IProjectWorkspace project(IProjectWorkspace src)
        {
            Project = src;
            return ref Project;
        }
    }
}