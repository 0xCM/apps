//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class NativeSigDispenser : Dispenser<NativeSigDispenser>
    {
        const uint Capacity = MemoryPage.PageSize*8;

        readonly MemDispenser Memory;

        readonly StringDispenser Strings;

        readonly LabelDispenser Labels;

        readonly ConcurrentDictionary<Hex64,NativeSig> Sigs;

        object locker;

        bool OwnsDispensers;

        static long Id;

        [MethodImpl(Inline)]
        static uint NextId()
            => (uint)inc(ref Id);

        public NativeSigDispenser(MemDispenser mem, StringDispenser strings, LabelDispenser labels)
            : base(AllocationKind.NativeSig)
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
        NativeOp Operand(string name, NativeType type, NativeOpMod mod = default)
            => new NativeOp(Labels.Label(name), type, mod);

        public NativeSig Sig(string scope, string opname, NativeType ret, params NativeOpDef[] opspecs)
        {
            var id = NextId();
            var count = (byte)opspecs.Length;
            var size = size<byte>() + size<StringRef>() + (count + 1)*NativeOp.StorageSize;
            var data = Memory.DispenseMemory(size);
            var dst = new NativeSig(id, data);
            dst.Scope = Strings.String(scope);
            dst.Name = Strings.String(opname);
            dst.OperandCount = count;
            dst.Return = Operand("return", ret);

            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref skip(opspecs,i);
                dst[i] = Operand(spec.Name, spec.Type, spec.Mod);
            }

            return dst;
        }

        public NativeSig Sig(NativeSigSpec src)
            => Sig(src.Scope, src.Name, src.ReturnType, src.Operands);
    }
}