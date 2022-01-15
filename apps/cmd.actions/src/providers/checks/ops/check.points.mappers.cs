//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    partial class CheckCmdProvider
    {
        [CmdOp("check/points/mappers")]
        Outcome TestPointMappers(CmdArgs args)
        {
            var result = Outcome.Success;
            var symbols = Symbols.index<ConditionCodes.Condition>();
            var symview = symbols.View;
            var map = PointFunctions.mapper<ConditionCodes.Condition,Pow2x16>(symbols, (i,k) => (Pow2x16)Pow2.pow((byte)i));
            var data = PointFunctions.serialize(map).View;
            var count = map.PointCount;
            var indices = slice(data,0, count);
            var bits = recover<ushort>(slice(data,count,count*size<Pow2x16>()));
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symview,i);
                ref readonly var entry = ref map[symbol.Kind];
                ref readonly var index = ref skip(data,i);
                Write(string.Format("{0} => {1}", entry, BitRender.format16(skip(bits,i))));
            }

            return result;
        }
    }
}