//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    using static FormatFunctions;

    /// <summary>
    /// Describes the outcome of a test case
    /// </summary>
    public struct TestCaseRecord : IRecord<TestCaseRecord>, ITextual
    {
        public const byte FieldCount = 6;

        public string CaseName;

        public bool Passed;

        public Timestamp Started;

        public Timestamp Finished;

        public Duration Duration;

        public string Message;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{60,14,26,26,26,5};

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