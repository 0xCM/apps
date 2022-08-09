//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public class CellDispenser<T> : Dispenser<CellDispenser<T>>    
        where T : unmanaged
    {
        readonly uint CellCount;
        
        readonly ByteSize CellSize;

        readonly MemoryDispenser Dispenser;

        internal CellDispenser(uint partition)
            : base(true)
        {
            CellSize = size<T>();
            CellCount = partition;
            Dispenser = Dispense.memory(CellCount*CellSize);
        }

        [MethodImpl(Inline)]
        public ref T Cell()
            => ref @as<T>(Dispenser.Memory(CellSize).Cell(0));

        protected override void Dispose()
            => (Dispenser as IDisposable).Dispose();
    }
}