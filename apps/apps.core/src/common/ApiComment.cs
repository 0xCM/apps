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
        public ApiCommentTarget Target;

        [Render(140)]
        public string TargetName;

        [Render(1)]
        public string Description;

        [MethodImpl(Inline)]
        public ApiComment(ApiCommentTarget target, string name, string desc)
        {
            Target = target;
            TargetName = ApiCommentDataset.TypeDisplayName(name);
            Description = desc;
        }
    }
}