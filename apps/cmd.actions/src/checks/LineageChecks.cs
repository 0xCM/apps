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

            using var buffer = StringBuffers.buffer(Pow2.T14);
            var allocator = LabelAllocator.from(buffer);

            RequireEq(Lineage2.parse(allocator, Case0).Format(), Case0);
            RequireEq(Lineage2.parse(allocator, Case1).Format(), Case1);
            RequireEq(Lineage2.parse(allocator, Case2).Format(), Case2);
            RequireEq(Lineage2.parse(allocator, Case3).Format(), Case3);
        }
    }
}