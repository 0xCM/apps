//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Relations;

    [ApiHost]
    public class RelationChecks
    {
        const NumericKind Closure = UnsignedInts;

        public static Checks create(IWfRuntime wf)
            => Checks.create(wf);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarValue<T> scalar<T>(T src, BitWidth content = default)
            where T : unmanaged, IEquatable<T>
                => new ScalarValue<T>(src,content);

        public class Checks : Checker<Checks>
        {
            Outcome Check()
            {
                var result = Outcome.Success;

                var v1 = Terms.var("a");
                var v2 = Terms.var("b");
                var a1 = scalar((byte)22);
                var b1 = scalar((byte)12);
                var a2 = scalar((byte)16);
                var b2 = scalar((byte)87);
                var context = expr.context();
                context.Inject((v1,a1), (v2,b1));
                var eval1 =  v1.Eval<ScalarValue<byte>>(context);
                var eval2 = v2.Eval<ScalarValue<byte>>(context);
                result = (eval1 == a1 && eval2 == b1);

                var eq1 = Relations.eq(a1,b1);
                context.Inject((v1,a2), (v2,b2));
                var eval3 = v1.Eval(context);
                var eval4 = v2.Eval(context);
                var eq2 = Relations.eq(a2,b2);

                return result;
            }
        }
    }
}