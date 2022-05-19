//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ApiComment
    {
        const string TableId = "api.comments";

        [Render(12)]
        public ApiCommentTarget Type;

        [Render(140)]
        public string Name;

        [Render(1)]
        public string Description;

        public ApiComment(ApiCommentTarget kind, string name, string desc)
        {
            Type = kind;
            Name = name;
            Description = desc;
        }
    }
}