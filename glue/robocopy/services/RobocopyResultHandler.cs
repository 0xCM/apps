//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class RobocopyResultHandler : IToolResultHandler
    {
        readonly IEnvPaths Paths;

        public ToolId Tool => Toolspace.robocopy;

        void Status(TextLine src)
            => term.babble(src);

        void Found(string marker)
            => term.inform(marker);

        public RobocopyResultHandler(IEnvPaths paths)
        {
            Paths = paths;
        }

        public bool Handle(TextLine src)
        {
            var @continue = true;
            var content = src.Content;
            if(content.Contains(CopySummaryMarker))
            {
                Found(nameof(CopySummaryMarker));
                Status(src);
            }
            else if(content.Contains(CopyFinishedMarker))
            {
                Found(nameof(CopyFinishedMarker));
                Status(src);

                @continue = false;
            }
            else
                Status(src);


            return @continue;
        }

        public bool CanHandle(TextLine src)
            => src.Content.Contains(Logo);

        const string Logo = "Robust File Copy for Windows";

        const string CopySummaryMarker = "Total    Copied   Skipped  Mismatch    FAILED    Extras";

        const string CopyFinishedMarker = "Ended :";
    }
}