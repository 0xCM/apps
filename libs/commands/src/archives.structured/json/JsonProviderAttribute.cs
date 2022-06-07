//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class JsonProviderAttribute : Attribute
    {
        public Type[] Supported {get;}

        public JsonProviderAttribute(params Type[] supported)
        {
            Supported = supported;
        }
    }
}