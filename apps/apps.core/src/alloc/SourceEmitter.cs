//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SourceEmitter : ISourceEmitter
    {
        [MethodImpl(Inline)]
        public static SourceEmitter create(SourceDispenser dispenser)
            => new SourceEmitter(dispenser);

        readonly SourceDispenser Dispenser;

        readonly List<string> Dst;

        [MethodImpl(Inline)]
        public SourceEmitter(SourceDispenser d)
        {
            Dispenser = d;
            Dst = new();
        }

        public void AppendLines(params string[] src)
            => Dst.AddRange(src);

        public SourceText Emit()
        {
            var dst = Dispenser.Source(Dst.ViewDeposited());
            Dst.Clear();
            return dst;
        }
    }
}