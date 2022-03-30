//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using static XedModels;
    using static core;

    partial class XedPatterns
    {
        public readonly struct PatternSort : IComparable<PatternSort>, IComparer<InstPatternInfo>, IComparer<InstPatternSpec>
        {
            public static PatternSort comparer() => default;

            const byte OpCodeOffset = 0;

            const byte InstClassOffset = 8;

            const byte InstFormOffset = 10;

            const byte LockableOffset = 12;

            const byte LockValueOffset = 13;

            const byte DiscrimOffset = 14;

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
                @as<ushort>(seek(data.Bytes, DiscrimOffset)) = (ushort)alg.hash.marvin(src.BodyExpr.Text);
                Data = data;
            }

            [MethodImpl(Inline)]
            public PatternSort(InstPatternInfo src)
            {
                var data = ByteBlock16.Empty;
                @as<ulong>(seek(data.Bytes, OpCodeOffset)) = @as<XedOpCode,ulong>(src.OpCode);
                @as<ushort>(seek(data.Bytes, InstClassOffset)) = @as<InstClass,ushort>(src.InstClass);
                @as<ushort>(seek(data.Bytes, InstFormOffset)) = @as<InstForm,ushort>(src.InstForm);
                @as<bit>(seek(data.Bytes, LockableOffset)) = @lock(src.Body, out bit locked);
                @as<bit>(seek(data.Bytes, LockValueOffset)) = locked;
                @as<ushort>(seek(data.Bytes, DiscrimOffset)) = (ushort)alg.hash.marvin(src.Body.Format());
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
                @as<ushort>(seek(data.Bytes, DiscrimOffset)) = (ushort)alg.hash.marvin(src.BodyExpr.Text);
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

            public ref readonly ushort Discriminator
            {
                [MethodImpl(Inline)]
                get => ref @as<ushort>(seek(Data.Bytes,DiscrimOffset));
            }

            public int CompareTo(PatternSort src)
            {
                var result = InstClass.CompareTo(src.InstClass);
                if(result == 0)
                {
                    result = OpCode.CompareTo(src.OpCode);
                    if(result == 0)
                    {
                        if(!Lockable)
                        {
                            if(src.Lockable)
                                result = -1;
                            else if(!src.Lockable)
                            {
                                if(InstForm.IsNonEmpty)
                                    result = InstForm.CompareTo(src.InstForm);
                            }
                        }
                        else
                        {
                            if(Lockable && !src.Lockable)
                                result = 1;
                            else if(Lockable && src.Lockable)
                            {
                                result = InstForm.CompareTo(src.InstForm);
                                if(result == 0)
                                    result = ((byte)LockValue).CompareTo((byte)src.LockValue);
                            }
                            else
                                result = InstForm.CompareTo(src.InstForm);
                        }
                    }
                }
                if(result==0)
                    result = Discriminator.CompareTo(src.Discriminator);
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
            public int Compare(InstPatternInfo x, InstPatternInfo y)
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