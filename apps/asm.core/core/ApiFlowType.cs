//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct ApiFlowType : IComparable<ApiFlowType>
    {
        public const string TableId = "api.dataflows";

        public const byte FieldCount = 4;

        public string Actor;

        public string Source;

        public string Target;

        public string Description;

        public int CompareTo(ApiFlowType src)
        {
            var i = Actor.CompareTo(src.Actor);
            if(i==0)
            {
                var j = Source.CompareTo(src.Source);
                if(j==0)
                    return Target.CompareTo(Target);
                else
                    return j;
            }
            else
            {
                return i;
            }
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{16,16,16,1};
    }
}