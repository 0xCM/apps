//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiPack : IApiPack
    {
        public readonly ApiExtractSettings ExtractSettings;

        readonly ApiCodeFiles Files;

        [MethodImpl(Inline)]
        public ApiPack(ApiCodeFiles files, ApiExtractSettings settings)
        {
            Files = files;
            ExtractSettings = settings;
        }

        public Timestamp Timestamp
            => ParseTimestamp().Data;

        ApiExtractSettings IApiPack.ExtractSettings
            => ExtractSettings;

        FS.FolderPath IRootedArchive.Root
            => ExtractSettings.ExtractRoot;

        Outcome<Timestamp> ParseTimestamp()
        {
            if(ExtractSettings.ExtractRoot.IsEmpty)
                return default;

            return ApiExtractSettings.timestamp(ExtractSettings.ExtractRoot, out _);
        }

        public string Format()
            => string.Format("{0}: {1}", ParseTimestamp(), ExtractSettings.ExtractRoot);

        public override string ToString()
            => Format();

        public FS.FilePath ProcDumpPath(Process process, Timestamp ts)
            => Files.DumpArchive.DumpPath(process,ts);
    }
}