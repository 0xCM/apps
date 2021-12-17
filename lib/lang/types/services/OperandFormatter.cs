//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    readonly struct OperandFormatter : IFormatter<Operand>
    {
        public static OperandFormatter Service => default;

        public string Format(Operand src)
            => string.Format("{0}:{1}", src.Name, src.Type.Format());
    }
}