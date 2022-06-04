//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedOpCodes
    {
        [Op]
        public static OpCodeClass @class(OpCodeIndex src)
            => @class(kind(src));

        [Op]
        public static OpCodeClass @class(OpCodeKind src)
            => (OpCodeClass)(byte)src;
    }
}