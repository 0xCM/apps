//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Gen.Projects
{
    public abstract class ProjectItem : IProjectItem
    {
        public string Name {get;}

        protected ProjectItem(string name)
        {
            Name = name;
        }

        public abstract string Format();
    }
}
