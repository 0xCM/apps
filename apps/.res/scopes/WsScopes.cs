//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public readonly struct WsScopes
    {
        public static Subject asm => "asm";

        public static Subject control => "control";

        public static Subject gen => "gen";

        public static Subject imports => "imports";

        public static Subject logs => "logs";

        public static Subject sources => "sources";

        public static Subject tables => "tables";

        public static Subject tools => "tools";
    }
}