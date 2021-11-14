//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Gen.Projects
{
    public abstract class ProjectProperty : IProjectProperty
    {
        public string Name {get;}

        public string Value {get;}

        protected ProjectProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => string.Format("<{0}>{1}</{0}>", Name, Value);
    }
}
