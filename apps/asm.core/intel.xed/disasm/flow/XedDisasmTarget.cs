//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedDisasm;

    public class XedDisasmTarget : AppServiceClient<XedDisasmTarget>, IXedDisasmTarget
    {
        FileRef Source;

        void ProcessingFile()
        {
            Write($"Processing {Source.Path.ToUri()}");
        }

        public Task Running(in FileRef src)
        {
            Source = src;
            return run(ProcessingFile);
        }

        public Task Computed(in DisasmFile src)
        {
            return run(() => {});
        }

        public Task Computed(in DetailBlock src)
        {
            return run(() => {});
        }

        public Task Computed(in DisasmSummaryDoc src)
        {
            return run(() => {});
        }

        public Task Computed(in RuleState src)
        {
            return run(() => {});
        }

        public Task Computed(in XDis src)
        {
            return run(() => {});
        }

        public Task Computed(in DisasmProps src)
        {
            return run(() => {});
        }

        public Task Computed(in Fields src)
        {
            return run(() => {});
        }

        public Task Computed(in EncodingExtract src)
        {
            return run(() => {});
        }

        public Task Computed(ReadOnlySpan<FieldKind> src)
        {
            return run(() => {});
        }

        public Task Completed()
        {
            return run(() => {});
        }
    }
}