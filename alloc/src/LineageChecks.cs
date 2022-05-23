//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class LineageChecks : Checker<LineageChecks>
    {
        public void CheckLineageParser()
        {
            const string Case0 = "a -> b -> c -> d -> e";
            const string Case1 = "f -> g -> h -> i -> j -> k -> l -> m";
            const string Case2 = "n -> o -> p -> q -> r -> s -> t";
            const string Case3 = "u -> v -> w -> x -> y -> z";

            // using var buffer = StringBuffers.buffer(Pow2.T14);
            // var allocator = Alloc.labels(buffer);
            using var dispenser = Alloc.labels();

            RequireEq(Lineage2.parse(Case0, dispenser).Format(), Case0);
            RequireEq(Lineage2.parse(Case1, dispenser).Format(), Case1);
            RequireEq(Lineage2.parse(Case2, dispenser).Format(), Case2);
            RequireEq(Lineage2.parse(Case3, dispenser).Format(), Case3);
        }
    }
}