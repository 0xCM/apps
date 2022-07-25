//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    using static FormatDelegates;

    /// <summary>
    /// Describes the outcome of a test case
    /// </summary>
    [Record(TableId)]
    public struct TestCaseRecord : IRecord<TestCaseRecord>, ITextual
    {
        const string TableId = "test.results";
        public const byte FieldCount = 6;

        [Render(60)]
        public string CaseName;

        [Render(14)]
        public bool Passed;

        [Render(26)]
        public Timestamp Started;

        [Render(26)]
        public Timestamp Finished;

        [Render(26)]
        public Duration Duration;

        [Render(1)]
        public string Message;

        public static FormatCell<TestCaseRecord> FormatFunction
            => TestCaseRecords.format;

        public static TestCaseRecord define(string name, bool succeeded, Duration duration)
            => new TestCaseRecord(name, succeeded, duration, EmptyString);

        public static TestCaseRecord define(string name, bool succeeded, Timestamp started, Timestamp finished, Duration duration, string msg = EmptyString)
            => new TestCaseRecord(name, succeeded, started, finished, duration, msg);

        internal TestCaseRecord(string name, bool succeeded, Timestamp started, Timestamp finished, Duration duration, string msg)
        {
            CaseName = name ?? "<missing_name>";
            Passed = succeeded;
            Duration = duration;
            Started = started;
            Message = msg;
            Finished = finished;
        }

        internal TestCaseRecord(string name, bool succeeded, Duration duration, string msg)
        {
            CaseName = name ?? "<missing_name>";
            Passed = succeeded;
            Duration = duration;
            Started = now();
            Message = msg;
            Finished = now();
        }

        public string Format()
            => TestCaseRecords.format(this);
    }
}