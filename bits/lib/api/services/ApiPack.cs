//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiPack : IApiPack
    {
        public ApiExtractSettings ExtractSettings {get;}

        public FS.FolderPath Root
            => ExtractSettings.ExtractRoot;

        [MethodImpl(Inline)]
        public ApiPack(ApiExtractSettings settings)
        {
            ExtractSettings = settings;
        }

        public Timestamp Timestamp
            => ParseTimestamp().Data;

        public bool IsTimestamped
            => ParseTimestamp().Ok;

        Outcome<Timestamp> ParseTimestamp()
        {
            if(Root.IsEmpty)
                return default;

            return ApiExtractSettings.timestamp(Root, out _);
        }

        public string Format()
            => string.Format("{0}: {1}", ParseTimestamp(), Root);

        public override string ToString()
            => Format();
    }
}