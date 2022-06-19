//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TestCaseRecords
    {
        const string Delimiter = "| ";

        const int WidthOffset = 16;

        public const uint CasePad = (uint)TestCaseField.CaseName >> WidthOffset;

        public const uint StartedPad = (uint)TestCaseField.Started >> WidthOffset;

        public const uint FinishedPad = (uint)TestCaseField.Finished >> WidthOffset;

        public const uint DurationPad = (uint)TestCaseField.Duration >> WidthOffset;

        public const uint PassedPad = (uint)TestCaseField.Passed >> WidthOffset;

        public const uint MessagePad = (uint)TestCaseField.Message >> WidthOffset;

        public static void render(in TestCaseRecord src, ITextBuffer dst)
        {
            dst.AppendPadded(src.CaseName, CasePad, Delimiter);
            dst.AppendPadded(src.Passed, PassedPad, Delimiter);
            dst.AppendPadded(src.Duration, DurationPad, Delimiter);
            dst.AppendPadded(src.Started, StartedPad, Delimiter);
            dst.AppendPadded(src.Finished, FinishedPad, Delimiter);
            dst.AppendPadded(src.Message, MessagePad, Delimiter);
        }

        public static string format(in TestCaseRecord src)
        {
            var dst = text.buffer();
            render(src, dst);
            return dst.Emit();
        }
    }
}