//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Iterators;

    [ApiHost]
    public readonly struct Iterators
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static IteratorRelay<T> relay<T>(IOutputIterator<T> dst)
            => new IteratorRelay<T>(dst);

        [Op, Closures(Closure)]
        public static IteratorRelay<T> relay<T>(IReadOnlyIterator<T> dst)
            => new IteratorRelay<T>(dst);

        [Op, Closures(Closure)]
        public static IteratorRelay<T> relay<T>(IMutableIterator<T> dst)
            => new IteratorRelay<T>(dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ViewTrigger<T> trigger<T>(Receiver<T> receiver)
            => new ViewTrigger<T>(receiver);

        [Op, Closures(Closure)]
        public static OutputReceiver<T> receiver<T>(ViewTrigger<T> trigger)
            => OutputReceiver<T>.create(trigger);

        [Op, Closures(Closure)]
        public static EnumerableTarget<T> target<T>(IteratorRelay<T> relay)
            => new EnumerableTarget<T>(relay);
    }

    [ApiHost]
    public readonly struct SpanIterators
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static void run<T>(Span<T> src, IOutputIterator<T> dst)
            => relay(dst).Output(src, dst);

        [Op, Closures(Closure)]
        public static void run<T>(Span<T> src, IMutableIterator<T> dst)
            => relay(dst).Edit(src, dst);

        [Op, Closures(Closure)]
        public static void run<T>(Span<T> src, IReadOnlyIterator<T> dst)
            => relay(dst).View(src, dst);

        [Op, Closures(Closure)]
        public static void run<T>(Span<T> src, OutputReceiver<T> dst)
        {
            var traverser = new SpanIterator<T>(src);
            while(traverser.NextCell(out dst.Current))
                dst.Trigger.Raise(dst.Current);
        }
    }
}