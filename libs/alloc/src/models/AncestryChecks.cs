//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AncestryChecks : Checker<AncestryChecks>
    {
        public void CheckParser()
        {
            const string Case0 = "a -> b -> c -> d -> e";
            const string Case1 = "f -> g -> h -> i -> j -> k -> l -> m";
            const string Case2 = "n -> o -> p -> q -> r -> s -> t";
            const string Case3 = "u -> v -> w -> x -> y -> z";

            using var dispenser = Alloc.labels();
            var ancestors = Ancestors.create(dispenser);

            ancestors.Parse(Case0, out var @case0);
            ancestors.Parse(Case1, out var @case1);
            ancestors.Parse(Case2, out var @case2);
            ancestors.Parse(Case3, out var @case3);

            RequireEq(@case0.Format(), Case0);
            RequireEq(@case1.Format(), Case1);
            RequireEq(@case2.Format(), Case2);
            RequireEq(@case3.Format(), Case3);
        }
    }
}