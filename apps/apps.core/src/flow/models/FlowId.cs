//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct FlowId : IEquatable<FlowId>
    {
        public readonly Hex32 ActorId;

        public readonly Hex32 SourceId;

        public readonly Hex32 TargetId;

        readonly Hex32 HashCode;

        [MethodImpl(Inline)]
        public FlowId(Hex32 actor, Hex32 src, Hex32 dst)
        {
            ActorId = actor;
            SourceId = src;
            TargetId = dst;
            HashCode = alg.hash.combine(actor, src, dst);
        }

        public override int GetHashCode()
            => (int)HashCode;


        [MethodImpl(Inline)]
        public bool Equals(FlowId src)
            => ActorId == src.ActorId && SourceId == src.SourceId && TargetId == src.TargetId;

        public override bool Equals(object src)
            => src is FlowId x && Equals(x);

        public string Format()
            => string.Format("{0:x8}{1:x8}{2:x8}", (uint)ActorId, (uint)SourceId, (uint)TargetId);

        public override string ToString()
            => Format();

        public static InstructionId Empty => default;
    }
}