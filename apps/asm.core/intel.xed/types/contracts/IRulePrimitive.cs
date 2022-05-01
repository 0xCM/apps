//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [Free]
        public interface IRulePrimitive : IRuleType
        {

        }

        [Free]
        public interface IRulePrimitive<T> : IRulePrimitive
            where T : unmanaged, IRulePrimitive<T>
        {

        }
    }
}