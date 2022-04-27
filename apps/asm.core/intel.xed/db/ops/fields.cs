//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDb
    {
        public static ClrRecordFields fields(Type a, Type b)
            => (Tables.fields(a).Index() + Tables.fields(b).Index()).Storage;
    }
}