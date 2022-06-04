//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public abstract class ApiExtractEvent<E> : IWfEvent<E>
        where E : ApiExtractEvent<E>, new()
    {
        public EventId EventId {get;}

        public FlairKind Flair {get;}

        protected ApiExtractEvent()
        {
            EventId = typeof(E);
            Flair = FlairKind.Processed;
        }

        public string Format()
        {
            return EmptyString;
        }
    }

    public abstract class ApiExtractEvent<E,P> : ApiExtractEvent<E>
        where E : ApiExtractEvent<E,P>, new()
    {

        protected ApiExtractEvent()
        {

        }

        public P Payload {get; protected set;}
    }
}