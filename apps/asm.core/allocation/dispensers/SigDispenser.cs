//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SigDispenser : Dispenser<SigDispenser>
    {
        const uint Capacity = PageBlock.PageSize*8;

        readonly MemoryDispenser Memory;

        readonly StringDispenser Strings;

        readonly LabelDispenser Labels;

        readonly ConcurrentDictionary<Hex64,NativeSig> Sigs;

        object locker;

        bool OwnsDispensers;

        static long Id;

        [MethodImpl(Inline)]
        static uint NextId()
            => (uint)inc(ref Id);

        internal SigDispenser(uint capacity = Capacity)
            : base(AllocationKind.Sig)
        {
            locker = new();
            Memory = new MemoryDispenser(capacity);
            Strings = new StringDispenser(capacity);
            Labels = new LabelDispenser(capacity);
            Sigs = new();
            OwnsDispensers = true;
        }

        internal SigDispenser(MemoryDispenser mem, StringDispenser strings, LabelDispenser labels)
            : base(AllocationKind.Sig)
        {
            locker = new();
            Memory = mem;
            Strings = strings;
            Labels = labels;
            Sigs = new();
            OwnsDispensers = false;
        }

        public override void Dispose()
        {
            if(OwnsDispensers)
            {
                (Memory as IDisposable).Dispose();
                (Strings as IDisposable).Dispose();
                (Labels as IDisposable).Dispose();
            }
        }

        [MethodImpl(Inline)]
        NativeOperand operand(string name, NativeType type, NativeOpMod mod = default)
            => new NativeOperand(Labels.Label(name), type, mod);

        public NativeSig NativeSig(string scope, string opname, NativeType ret, params NativeOperandSpec[] opspecs)
        {
            var id = NextId();
            var count = (byte)opspecs.Length;
            var size = size<byte>() + size<StringRef>() + (count + 1)*NativeOperand.StorageSize;
            var data = Memory.DispenseMemory(size);
            var dst = new NativeSig(id, data);
            dst.Scope = Strings.String(scope);
            dst.Name = Strings.String(opname);
            dst.OperandCount = count;
            dst.Return = operand("return", ret);

            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref skip(opspecs,i);
                dst[i] = operand(spec.Name, spec.Type, spec.Mod);
            }

            return dst;
        }
    }
}