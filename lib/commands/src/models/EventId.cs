//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct EventId : IWfEventId<EventId>
    {
        [MethodImpl(Inline)]
        public static EventId define(string name, WfStepId step)
            => new EventId(name, step, CorrelationToken.Default);

        public static EventId Empty
        {
            [MethodImpl(Inline)]
            get => new EventId(EmptyString, Timestamp.Zero);
        }

        public string Identifier {get;}

        public Timestamp Ts {get;}

        const string PatternBase = "{0} | {1,-18}";

        [MethodImpl(Inline)]
        EventId(Type type)
        {
            Ts = Timestamp.now();
            Identifier = string.Format(PatternBase, Ts, type.Name);
        }

        [MethodImpl(Inline)]
        EventId(string name, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase, Ts, name);
        }

        [MethodImpl(Inline)]
        EventId(string name, CorrelationToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase, Ts, name);
        }

        [MethodImpl(Inline)]
        EventId(string name, string label, WfStepId step, CorrelationToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2} | {3}", Ts, name, label, step);
        }

        [MethodImpl(Inline)]
        EventId(string name, string label, CorrelationToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2}", Ts, name, label);
        }

        [MethodImpl(Inline)]
        EventId(string name, CmdId cmd, CorrelationToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2}", Ts, name, cmd);
        }

        [MethodImpl(Inline)]
        EventId(string name, WfStepId step, CorrelationToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2,-24}", Ts, name, step);
        }

        [MethodImpl(Inline)]
        EventId(string name, WfStepId step, EventLevel level, CorrelationToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2} | {3}", Ts, name, level, step);
        }

        [MethodImpl(Inline)]
        EventId(EventKind kind, WfStepId step, EventLevel level, CorrelationToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2} | {3}", Ts, kind, level, step);
        }

        [MethodImpl(Inline)]
        EventId(Type type, WfStepId step, CorrelationToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2}", Ts, type.Name, step);
        }

        /// <summary>
        /// The event data type name
        /// </summary>
        public string Name
            => Identifier;

        [MethodImpl(Inline)]
        public bool Equals(EventId src)
            => Identifier == src.Identifier;

        [MethodImpl(Inline)]
        public int CompareTo(EventId src)
            => Ts.CompareTo(src.Ts);

        [MethodImpl(Inline)]
        public string Format()
            => Identifier.PadRight(56);

        public uint Hashed
        {
            [MethodImpl(Inline)]
            get => FastHash.combine(Ts.Hashed, (uint)(Identifier?.GetHashCode() ?? 0));
        }

        public override int GetHashCode()
            => (int)Hashed;


        public override bool Equals(object src)
            => src is EventId i && Equals(i);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EventId((Type type, WfStepId step, CorrelationToken ct) src)
            => new EventId(src.type, src.step, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, WfStepId step, CorrelationToken ct) src)
            => new EventId(src.name, src.step, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((EventKind kind, WfStepId step, CorrelationToken ct) src)
            => new EventId(src.kind.ToString(), src.step, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((EventKind kind, CmdId cmd, CorrelationToken ct) src)
            => new EventId(src.kind.ToString(), src.cmd, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, WfStepId step, EventLevel level, CorrelationToken ct) src)
            => new EventId(src.name, src.step, src.level, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((EventKind kind, WfStepId step, EventLevel level, CorrelationToken ct) src)
            => new EventId(src.kind, src.step, src.level, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, CorrelationToken ct) src)
            => new EventId(src.name, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId(string name)
            => new EventId(name);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, string label, WfStepId step, CorrelationToken ct) src)
            => new EventId(src.name, src.label, src.step, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, string label, CorrelationToken ct) src)
            => new EventId(src.name, src.label, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, CmdId cmd, CorrelationToken ct) src)
            => new EventId(src.name, src.cmd, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId(Type row)
            => new EventId(row);
    }
}