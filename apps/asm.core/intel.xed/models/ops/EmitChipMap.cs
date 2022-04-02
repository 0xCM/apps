//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelXed
    {
        public void EmitChipMap()
        {
            const string RowFormat = "{0,-12} | {1,-24} | {2}";
            var map = CalcChipMap();
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
    }
}