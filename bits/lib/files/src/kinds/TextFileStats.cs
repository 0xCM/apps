//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct TextFileStats : IRecord<TextFileStats>
    {
        public uint MaxLineLength;

        public uint LineCount;

        public uint CharCount;
    }
}