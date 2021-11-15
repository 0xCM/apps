//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public sealed class LineageChecks : Checks<LineageChecks>
    {
        public override void Run()
        {
            CheckParser();
        }

        void CheckParser()
        {
            const string Case0 = "a -> b -> c -> d -> e";
            const string Case1 = "f -> g -> h -> i -> j -> k -> l -> m";
            const string Case2 = "n -> o -> p -> q -> r -> s -> t";
            const string Case3 = "u -> v -> w -> x -> y -> z";

            using var buffer = strings.buffer(Pow2.T14);
            var allocator = buffer.LabelAllocator();
            var l0 = Lineage2.parse(allocator, Case0);
            Check(Eq(l0.Format(), Case0));

            var l1 = Lineage2.parse(allocator, Case1);
            Check(Eq(l1.Format(), Case1));

            var l2 = Lineage2.parse(allocator, Case2);
            Check(Eq(l2.Format(), Case2));

            var l3 = Lineage2.parse(allocator, Case3);
            Check(Eq(l3.Format(), Case3));
        }
    }
}