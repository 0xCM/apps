//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct TimeSeries<T> : ITimeSeries<T>
        where T : unmanaged
    {
        public long Id {get;}

        /// <summary>
        /// Specifies the observation domain
        /// </summary>
        public Interval<T> Domain {get;}

        public SeriesTerm<T> Observed {get; private set;}

        [MethodImpl(Inline)]
        public TimeSeries(long id, Interval<T> domain, SeriesTerm<T> first)
        {
            Id = id;
            Domain = domain;
            Observed = first;
        }

        [MethodImpl(Inline)]
        public void Witnessed(SeriesTerm<T> term)
            => Observed = term;

        [MethodImpl(Inline)]
        public TimeSeries<T> Snapshot()
            => new TimeSeries<T>(Id, Domain, Observed);
    }
}