//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;


    using static TmpTables;

    using C = AsciLetterUpCode;

    public class ExpressionChecks : Checker<ExpressionChecks>
    {
        [CmdOp("check/points/mappers")]
        Outcome TestPointMappers(CmdArgs args)
        {
            var result = Outcome.Success;
            var symbols = Symbols.index<DecimalDigitValue>();
            var symview = symbols.View;
            var map = PointFunctions.mapper<DecimalDigitValue,Pow2x16>(symbols, (i,k) => (Pow2x16)Pow2.pow((byte)i));
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

        [CmdOp("check/points/fx")]
        unsafe Outcome FT(CmdArgs args)
        {
            var src = recover<C,byte>(Source);
            ref var f = ref PointFunctions.fx<AsciCode>(n8, src, Target, out _);

            byte x = 0;

            x = skip(src,0);
            Write(f.Map(x));

            x = skip(src,1);
            Write(f.Map(x));

            x = skip(src,2);
            Write(f.Map(x));

            x = skip(src,3);
            Write(f.Map(x));

            x = skip(src,4);
            Write(f.Map(x));

            return true;
        }


        public Outcome CheckRelationalExpressions()
        {
            var result = Outcome.Success;

            var v1 = Terms.var("a");
            var v2 = Terms.var("b");
            var a1 = expr.scalar((byte)22);
            var b1 = expr.scalar((byte)12);
            var a2 = expr.scalar((byte)16);
            var b2 = expr.scalar((byte)87);
            var context = expr.context();
            context.Inject((v1,a1), (v2,b1));
            var eval1 =  v1.Eval<ScalarValue<byte>>(context);
            var eval2 = v2.Eval<ScalarValue<byte>>(context);
            result = (eval1 == a1 && eval2 == b1);

            var eq1 = ScalarOps.eq(a1,b1);

            context.Inject((v1,a2), (v2,b2));
            var eval3 = v1.Eval(context);
            var eval4 = v2.Eval(context);
            var eq2 = ScalarOps.eq(a2,b2);

            return result;
        }

        public Outcome CheckTypeSyntax()
        {
            var result = Outcome.Success;

            Write(typeof(Span<int>).Spec());
            return result;
        }
    }

   readonly struct TmpTables
    {
        const byte PointCount = 5;

        public static ReadOnlySpan<C> Source
            => new C[PointCount]{C.Y, C.B, C.X, C.R, C.W};

        public static ReadOnlySpan<AsciCode> Target
            => new AsciCode[PointCount]{AsciCode.Y, AsciCode.B, AsciCode.X, AsciCode.R, AsciCode.W};
    }
}