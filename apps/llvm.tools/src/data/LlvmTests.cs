//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    public class LlvmTests
    {
        public static ReadOnlySpan<LlvmTestLogEntry> TestLog(FS.FilePath src)
        {
            using var reader = src.Utf8LineReader();
            var entries = list<LlvmTestLogEntry>();
            var entry = new LlvmTestLogEntry();
            while(reader.Next(out var line))
            {
                var content = line.Content;
                var i = text.index(content, CodeProp);
                if(i > 0)
                {
                    entry.code = text.right(content,i);
                    continue;
                }
                i = text.index(line.Content, ElapsedProp);
                if(i > 0)
                {
                    entry.elapsed = text.right(content,i);
                    continue;
                }
                i = text.index(line.Content, NameProp);
                if(i > 0)
                {
                    entry.name = text.right(content,i);
                    continue;
                }
                i = text.index(line.Content, OutputProp);
                if(i > 0)
                {
                    entry.output = text.right(content,i);
                    entries.Add(entry);
                    entry = new LlvmTestLogEntry();
                }
            }
            return entries.ViewDeposited();
        }

        const string CodeProp = CharText.Quote + nameof(LlvmTestLogEntry.code) + CharText.Quote;

        const string ElapsedProp = CharText.Quote + nameof(LlvmTestLogEntry.elapsed) + CharText.Quote;

        const string NameProp = CharText.Quote + nameof(LlvmTestLogEntry.name) + CharText.Quote;

        const string OutputProp = CharText.Quote +  nameof(LlvmTestLogEntry.output) + CharText.Quote;
    }
}