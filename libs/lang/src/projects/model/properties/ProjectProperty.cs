//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsProjects
    {
        public abstract class ProjectProperty : IProjectProperty
        {
            public Identifier Name {get;}

            public dynamic Value {get;}

            protected ProjectProperty(string name, dynamic value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => string.Format("<{0}>{1}</{0}>", Name, Value);

            public override string ToString()
                => Format();
        }
    }
}