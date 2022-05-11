//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDataTypes
    {
        static object KeyLocker = new();

        static TypeKey NextKey(TypeKind kind)
        {
            lock(KeyLocker)
            {
                ref var key = ref _Keys[kind];
                key++;
                return key;
            }
        }
    }
}