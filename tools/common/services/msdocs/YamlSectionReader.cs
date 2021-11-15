//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft Corporation. All rights reserved.
// License     :  MIT
// Origin      : https://github.com/microsoft/CsWin32/src/ScrapeDocs/Program.cs
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System;
    using System.IO;

    partial struct MsDocs
    {
        class YamlSectionReader : TextReader
        {
            readonly StreamReader Reader;

            bool FirstLineRead;

            bool LastLineRead;

            internal YamlSectionReader(StreamReader reader)
            {
                Reader = reader;
            }

            static void Expect(string? expected, string? actual)
            {
                if (expected != actual)
                {
                    throw new InvalidOperationException($"Expected: \"{expected}\" but read: \"{actual}\".");
                }
            }

            public override string? ReadLine()
            {
                if (LastLineRead)
                    return null;

                if (!FirstLineRead)
                {
                    Expect("---", Reader.ReadLine());
                    FirstLineRead = true;
                }

                string? line = Reader.ReadLine();
                if(line == "---")
                {
                    LastLineRead = true;
                    return null;
                }

                return line;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                    Reader.Dispose();

                base.Dispose(disposing);
            }
        }
    }
}