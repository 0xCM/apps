//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelXed
    {
        public Outcome EmitChipMap()
        {
            const string RowFormat = "{0,-12} | {1,-24} | {2}";

            var outcome = LoadChipMap(out var map);
            if(outcome.Fail)
                Error(outcome.Message);
            else
            {
                var dst = XedPaths.ChipMapTarget();
                var emitting = EmittingFile(dst);
                var counter = 0u;
                var writer = dst.AsciWriter();
                writer.WriteLine(string.Format(RowFormat, "Sequence", "ChipCode", "Isa"));
                var kinds = map.Kinds;
                var codes = map.Chips;
                foreach(var code in codes)
                {
                    var mapped = map[code];
                    foreach(var kind in mapped)
                        writer.WriteLine(string.Format(RowFormat, counter++ , code, kind));
                }
                EmittedFile(emitting,counter);
            }

            return outcome;
        }
    }
}