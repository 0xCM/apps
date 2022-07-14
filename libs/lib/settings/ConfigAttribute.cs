//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ConfigAttribute : Attribute
    {
        public ConfigAttribute(string name)
        {
            Name = name;
        }

        public Name Name {get;}
    }
}