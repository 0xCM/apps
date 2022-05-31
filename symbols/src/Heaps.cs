//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free, ApiHost]
    public partial class Heaps : AppService<Heaps>
    {
        const NumericKind Closure = UnsignedInts;

        AppDb AppDb => Service(Wf.AppDb);

        AppSvcOps AppSvc => Service(Wf.AppSvc);

        static int SegCount;

        Index<SymHeapEntry> CalcHeapEntries(SymHeap src)
            => Data(Heaps.id(src),() => Heaps.entries(src));

        public void Emit(SymHeap src, FS.FilePath dst)
            => AppSvc.TableEmit(CalcHeapEntries(src), dst);

        public void Emit(SymHeap src)
            => AppSvc.TableEmit(CalcHeapEntries(src), ApiTargets().Table<SymHeapEntry>(), TextEncodingKind.Unicode);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<byte> serialize<K,O,L>(in HeapEntry<K,O,L> src)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
                => bytes(src);

        [MethodImpl(Inline)]
        public static ref HeapEntry<K,O,L> materialize<K,O,L>(ReadOnlySpan<byte> src, out HeapEntry<K,O,L> dst)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
        {
            dst = @as<HeapEntry<K,O,L>>(src);
            return ref dst;
        }

        DbTargets ApiTargets()
            => AppDb.Targets("api");
   }
}