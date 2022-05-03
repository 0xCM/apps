//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedOperands
    {
        [MethodImpl(Inline)]
        public static OpWidthInfo describe(OpWidthCode code)
            => code == 0 ? OpWidthInfo.Empty : _WidthLookup[code];

        public static OpWidth width(MachineMode mode, OpWidthCode code)
        {
            var dst = OpWidth.Empty;
            if(code == 0)
                return dst;
            else if(_WidthLookup.Find(code, out var info))
            {
                switch(mode.Class)
                {
                    case ModeClass.Mode16:
                        dst = new OpWidth(code, info.Width16);
                    break;
                    case ModeClass.Not64:
                    case ModeClass.Mode32:
                        dst = new OpWidth(code, info.Width32);
                    break;

                    default:
                        dst = new OpWidth(code, info.Width64);
                    break;
                }
            }
            else
                Errors.Throw(code.ToString());
            return dst;
        }
    }
}