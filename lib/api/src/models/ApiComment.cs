//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ApiComment : IRecord<ApiComment>
    {
        public const string TableId = "api.comments";

        public ApiCommentTarget Kind;

        public string Identifer;

        public string Summary;

        public ApiComment(ApiCommentTarget kind, string identifier, string summary)
        {
            Kind = kind;
            Identifer = identifier;
            Summary = summary;
        }
    }
}