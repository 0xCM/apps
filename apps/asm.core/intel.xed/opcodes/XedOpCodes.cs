//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    public partial class XedOpCodes : AppService<XedOpCodes>
    {
        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

       public static Index<XedOpCode> opcodes(Index<InstPattern> src)
            => src.Map(x => x.Spec.OpCode).Sort();
    }
}