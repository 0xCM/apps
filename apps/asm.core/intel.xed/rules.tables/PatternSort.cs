//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public readonly struct PatternSort : IComparable<PatternSort>, IComparer<InstPatternRecord>, IComparer<InstPatternSpec>
        {
            public static PatternSort comparer() => default;

            const byte OpCodeOffset = 0;

            const byte InstClassOffset = 8;

            const byte InstFormOffset = 10;

            const byte LockableOffset = 12;

            const byte LockValueOffset = 13;

            const byte ModeOffset = 14;

            const byte ModOffset = 15;

            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public PatternSort(InstPattern src)
            {
                var data = ByteBlock16.Empty;
                @as<ulong>(seek(data.Bytes,OpCodeOffset)) = @as<XedOpCode,ulong>(src.OpCode);
                @as<ushort>(seek(data.Bytes,InstClassOffset)) = @as<InstClass,ushort>(src.InstClass);
                @as<ushort>(seek(data.Bytes,InstFormOffset)) = @as<InstForm,ushort>(src.InstForm);
                @as<bit>(seek(data.Bytes,LockableOffset)) = @lock(src.Body, out bit locked);
                @as<bit>(seek(data.Bytes,LockValueOffset)) = locked;
                @as<MachineMode>(seek(data.Bytes, ModeOffset)) = src.Mode;
                mod(src.Body, out @as<ModKind>(seek(data.Bytes, ModeOffset)));
                Data = data;
            }

            [MethodImpl(Inline)]
            public PatternSort(InstPatternRecord src)
            {
                var data = ByteBlock16.Empty;
                @as<ulong>(seek(data.Bytes, OpCodeOffset)) = @as<XedOpCode,ulong>(src.OpCode);
                @as<ushort>(seek(data.Bytes, InstClassOffset)) = @as<InstClass,ushort>(src.InstClass);
                @as<ushort>(seek(data.Bytes, InstFormOffset)) = @as<InstForm,ushort>(src.InstForm);
                @as<bit>(seek(data.Bytes, LockableOffset)) = @lock(src.Body, out bit locked);
                @as<bit>(seek(data.Bytes, LockValueOffset)) = locked;
                @as<MachineMode>(seek(data.Bytes, ModeOffset)) = src.Mode;
                mod(src.Body, out @as<ModKind>(seek(data.Bytes, ModeOffset)));
                Data = data;
            }

            [MethodImpl(Inline)]
            public PatternSort(InstPatternSpec src)
            {
                var data = ByteBlock16.Empty;
                @as<ulong>(data.Bytes) = @as<XedOpCode,ulong>(src.OpCode);
                @as<ushort>(seek(data.Bytes,8)) = @as<InstClass,ushort>(src.InstClass);
                @as<ushort>(seek(data.Bytes,10)) = @as<InstForm,ushort>(src.InstForm);
                @as<bit>(seek(data.Bytes,LockableOffset)) = @lock(src.Body, out bit locked);
                @as<bit>(seek(data.Bytes,LockValueOffset)) = locked;
                @as<MachineMode>(seek(data.Bytes, ModeOffset)) = src.Mode;
                mod(src.Body, out @as<ModKind>(seek(data.Bytes, ModeOffset)));
                Data = data;
            }

            readonly ref readonly XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => ref @as<XedOpCode>(seek(Data.Bytes,OpCodeOffset));
            }

            public readonly ref readonly bit Lockable
            {
                [MethodImpl(Inline)]
                get => ref @as<bit>(seek(Data.Bytes,LockableOffset));
            }

            public readonly bit LockValue
            {
                [MethodImpl(Inline)]
                get => @as<bit>(seek(Data.Bytes,LockValueOffset));
            }

            public ref readonly InstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref @as<InstClass>(seek(Data.Bytes,InstClassOffset));
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref @as<InstForm>(seek(Data.Bytes,InstFormOffset));
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref @as<MachineMode>(seek(Data.Bytes,ModeOffset));
            }

            public ref readonly ModKind Mod
            {
                [MethodImpl(Inline)]
                get => ref @as<ModKind>(seek(Data.Bytes, ModOffset));
            }

            LockSort LockSort
            {
                [MethodImpl(Inline)]
                get => new (Lockable,LockValue);
            }

            public int CompareTo(PatternSort src)
            {
                var result = InstClass.CompareTo(src.InstClass);
                if(result == 0)
                {
                    result = OpCode.CompareTo(src.OpCode);

                    if(result == 0 && InstForm.IsNonEmpty && src.InstForm.IsNonEmpty)
                        result = InstForm.CompareTo(src.InstForm);

                    if(result == 0 && Mod.IsNonEmpty && src.Mod.IsNonEmpty)
                        result = Mod.CompareTo(src.Mod);

                    if(result == 0)
                        result = LockSort.CompareTo(src.LockSort);

                    if(result == 0)
                        result = Mode.CompareTo(src.Mode);
                }
                return result;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Data.Hash;
            }

            public override int GetHashCode()
                => Hash;

            public string Format()
                => Hash.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(PatternSort src)
                => Data == src.Data;

            public override bool Equals(object src)
                => src is PatternSort x && Equals(x);

            [MethodImpl(Inline)]
            public int Compare(InstPatternRecord x, InstPatternRecord y)
                => x.Sort().CompareTo(y.Sort());

            [MethodImpl(Inline)]
            public int Compare(InstPatternSpec x, InstPatternSpec y)
                => x.Sort().CompareTo(y.Sort());

            [MethodImpl(Inline)]
            public int Compare(InstPattern x, InstPattern y)
                => x.Sort().CompareTo(y.Sort());
        }
    }
}