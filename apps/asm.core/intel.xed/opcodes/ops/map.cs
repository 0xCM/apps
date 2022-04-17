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
        public static OpCodeMap map(OpCodeKind src)
            => new OpCodeMap(src, @class(src), index(src), symbol(src), selector(src));

        [MethodImpl(Inline), Op]
        public static OpCodeMap map(OpCodeIndex src)
            => map(kind(src));
   }
}