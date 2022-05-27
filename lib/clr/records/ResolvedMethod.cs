//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResolvedMethod : ITextual, IComparable<ResolvedMethod>
    {
        public readonly OpUri Uri;

        public readonly MethodInfo Method;

        public readonly MemoryAddress EntryPoint;

        [MethodImpl(Inline)]
        public ResolvedMethod(OpUri uri, MethodInfo method, MemoryAddress address)
        {
            Uri = uri;
            Method = method;
            EntryPoint = address;
        }

        [MethodImpl(Inline)]
        public ResolvedMethod(MethodInfo method, OpUri uri, MemoryAddress address)
        {
            Uri = uri;
            Method = method;
            EntryPoint = address;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Method is null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public Assembly Component
        {
            [MethodImpl(Inline)]
            get => HostType.Assembly;
        }

        public Type HostType
        {
            [MethodImpl(Inline)]
            get => Method.DeclaringType;
        }

        public ApiMember ToApiMember()
            => new ApiMember(Uri, Method, EntryPoint);

        public string Format()
            => ApiResolver.format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(ResolvedMethod src)
            => EntryPoint.CompareTo(src.EntryPoint);

        public ApiMemberInfo Describe()
            => ApiResolver.describe(this);
    }
}