//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;

    partial class MsBuild
    {
        public class ProjectItem : IProjectItem
        {
            public Identifier Name {get;}

            readonly E.ProjectItem Data;

            public string Type
                => Data.ItemType;

            protected ProjectItem(string name)
            {
                Name = name;
            }

            internal ProjectItem(E.ProjectItem src)
            {
                Data = src;
            }

            public virtual string Format()
            {
                return Type;
            }


            public override string ToString()
                => Format();

        }
    }
}