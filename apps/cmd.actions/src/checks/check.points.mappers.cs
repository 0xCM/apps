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

        Outcome CheckStatics(CmdArgs args)
        {

            return true;
        }
    }

    public interface IAdditive2<T>
        where T : unmanaged
    {
        static abstract T Add(T a, T b);
    }

    public readonly struct Additive<T> : IAdditive2<Additive<T>>
        where T : unmanaged
    {
        readonly T Value;

        public Additive(T value)
        {
            Value = value;
        }

        public static Additive<T> Add(Additive<T> a, Additive<T> b)
            => gmath.add(a.Value,b.Value);

        public static implicit operator Additive<T>(T value)
            => new Additive<T>(value);
    }

    public readonly struct Additives
    {
        public static T add<T>(T a, T b)
            where T : unmanaged, IAdditive2<T>
        {
            return T.Add(a,b);
        }
    }
}