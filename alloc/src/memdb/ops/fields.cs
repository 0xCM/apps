//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        public static ClrRecordFields fields(Type a, Type b)
            => (Tables.fields(a).Index() + Tables.fields(b).Index()).Storage;
    }
}