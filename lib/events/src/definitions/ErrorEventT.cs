//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Event(Kind)]
    public readonly struct ErrorEvent<T> : ILevelEvent<ErrorEvent<T>,T>, IErrorEvent
    {
        public const string EventName = GlobalEvents.Error;

        public const EventKind Kind = EventKind.Error;

        public LogLevel EventLevel => LogLevel.Error;

        public EventId EventId {get;}

        public Option<Exception> Exception {get;}

        public EventOrigin Source {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Error;

        public string Summary {get;}

        [MethodImpl(Inline)]
        public ErrorEvent(CmdId cmd, T data, EventOrigin source)
        {
            EventId = (Kind, cmd, CorrelationToken.Default);
            Exception = Option.none<Exception>();
            Payload = data;
            Source = source;
            Summary = Payload.Format();
        }

        [MethodImpl(Inline)]
        public ErrorEvent(Exception error, T data, EventOrigin source)
        {
            EventId = (EventName, CorrelationToken.Default);
            Exception = error;
            Payload = data;
            Source = source;
            Summary = Exception ? Exception.Value.ToString() : Payload.Format();
        }

        [MethodImpl(Inline)]
        public ErrorEvent(string label, T data,  EventOrigin source)
        {
            EventId = (EventName, label, CorrelationToken.Default);
            Exception = Option.none<Exception>();
            Payload = data;
            Source = source;
            Summary = Payload.Format();
        }

        [MethodImpl(Inline)]
        public ErrorEvent(WfStepId step, T data, EventOrigin source)
        {
            EventId = (EventName, step, CorrelationToken.Default);
            Exception = Option.none<Exception>();
            Payload = data;
            Source = source;
            Summary = Payload.Format();
        }

        public string Format()
        {
            var buffer = text.buffer();

            if(this is ErrorEvent<Exception> e)
                 format(e, buffer);
            else
                buffer.Append(text.format(RP.PSx3, EventId, Source, Summary));
            return buffer.Emit();

        }

        public override string ToString()
            => Format();

        [Op]
        public static void format(ErrorEvent<Exception> error, ITextBuffer dst)
        {
            const string ErrorTrace = "{0} | {1} | {2} | Outer | {3} | {4} | {5}";
            const string InnerTrace = "{0} | {1} | {2} | Inner | {3} | {4} | {5} | {6}";

            var exception = error.Payload;
            var eType = exception.GetType();
            var outer = string.Format(ErrorTrace, error.EventId, error.Summary, error.Source, eType.Name, exception.Data.Message, exception.Data.StackTrace);
            dst.AppendLine(outer);

            int level = 0;

            var e = exception.Data.InnerException;
            while (e != null)
            {
                dst.AppendLine(string.Format(InnerTrace, error.EventId, error.Summary, error.Source, level, eType.Name, e.Message, e.StackTrace));
                e = e.InnerException;
                level += 1;
            }
        }
    }
}