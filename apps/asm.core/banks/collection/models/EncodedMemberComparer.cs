//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct EncodedMemberComparer : IComparer<EncodedMemberInfo>
    {
        public static EncodedMemberComparer create(ModeKind mode)
            => new EncodedMemberComparer(mode);
        readonly ModeKind Mode;

        public enum ModeKind : byte
        {
            Entry,

            Target,
        }

        [MethodImpl(Inline)]
        EncodedMemberComparer(ModeKind mode)
        {
            Mode = mode;
        }

        [MethodImpl(Inline)]
        public int Compare(EncodedMemberInfo x, EncodedMemberInfo y)
        {
            if(Mode == ModeKind.Entry)
                return x.EntryAddress.CompareTo(y.EntryAddress);
            else
                return x.TargetAddress.CompareTo(y.TargetAddress);
        }
    }
}