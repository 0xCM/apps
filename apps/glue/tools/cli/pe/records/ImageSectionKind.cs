//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct PeRecords
    {
        [DocRef("http://www.hexacorn.com/blog/2016/12/15/pe-section-names-re-visited/")]
        public enum ImageSectionKind : byte
        {
            Unknown = 0,

            [Symbol(".data")]
            Data,

            [Symbol(".rsrc")]
            ResourceSection,

            [Symbol(".text")]
            Text,

            [Symbol(".reloc")]
            RelocationTable,

            [Symbol(".debug")]
            Debug,

            [Symbol(".tls")]
            ThreadLocalStorage,

            [Symbol(".drectve")]
            Directive,

            [Symbol(".edata")]
            ExportData,

            [Symbol(".idata")]
            InitializedData,

            [Symbol(".rdata")]
            ReadOnlyData,

            [Symbol(".pdata")]
            ExceptionData,

            [Symbol(".cormeta")]
            ClrMetadata,
        }
    }
}