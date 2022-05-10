//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Msil;

    using static core;

    [ApiHost]
    public readonly partial struct Cil
    {
        public static ILVisualizer visualizer()
            => ILVisualizer.service();

        [Op]
        public static string format(CliSig src)
            => DefaultMsilFormatProvider.Instance.SigByteArrayToString(src);

        public static ReadOnlySpan<CilOpCode> opcodes()
        {
            var buffer = span<CilOpCode>(300);
            var count = OpCodeLoader.load(ref first(buffer));
            return slice(buffer,0,count);
        }
    }
}