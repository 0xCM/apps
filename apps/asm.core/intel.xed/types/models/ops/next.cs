//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        public static TypeKey NextKey(TypeKind kind)
        {
            lock(KeyLocker)
            {
                ref var key = ref _Keys[kind];
                key++;
                return key;
            }
        }

        static object KeyLocker = new();
    }
}