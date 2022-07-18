//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public abstract class ProjectItem : IProjectItem
        {
            public Identifier Name {get;}

            protected ProjectItem(string name)
            {
                Name = name;
            }

            public abstract string Format();
        }
    }
}