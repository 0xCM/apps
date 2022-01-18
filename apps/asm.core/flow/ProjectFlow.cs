//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectFlow : FileFlow
    {
        public ProjectFlow(ProjectId project, IFileFlowType type, FS.FilePath src, FS.FilePath dst)
            : base(type,src,dst)
        {
            Project = project;
        }

        public ProjectId Project {get;}
    }
}