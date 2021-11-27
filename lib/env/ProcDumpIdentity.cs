//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Diagnostics;

    using static Root;

    public readonly struct ProcDumpIdentity : IIdentified
    {
        public static ProcDumpIdentity from(FS.FilePath src)
        {
            if(src.IsEmpty)
                return Empty;

            var identifier = src.FileName.WithoutExtension.Format();
            var name = identifier.LeftOfFirst(Chars.Dot);
            var result = Time.parse(identifier.RightOfFirst(Chars.Dot), out var ts);
            if(result)
                return create(name,ts);
            else
                return Empty;
        }

        [MethodImpl(Inline)]
        public static ProcDumpIdentity create(Process process, Timestamp ts)
            => new ProcDumpIdentity(process.ProcessName, ts);

        [MethodImpl(Inline)]
        public static ProcDumpIdentity create(string name, Timestamp ts)
            => new ProcDumpIdentity(name, ts);

        public string ProcessName {get;}

        public Timestamp CaptureTime {get;}

        [MethodImpl(Inline)]
        public ProcDumpIdentity(string name, Timestamp ts)
        {
            ProcessName = name;
            CaptureTime = ts;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(ProcessName) && CaptureTime.IsNonZero;
        }

        public string IdentityText
            => string.Format("{0}.{1}", ProcessName, CaptureTime.Format());

        public Identifier Identifier
            => IdentityText;

        public string Format()
            => Identifier;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ProcDumpIdentity((string name, Timestamp ts) src)
            => new ProcDumpIdentity(src.name, src.ts);

        [MethodImpl(Inline)]
        public static implicit operator ProcDumpIdentity((Process proc, Timestamp ts) src)
            => create(src.proc, src.ts);

        public static ProcDumpIdentity Empty
        {
            [MethodImpl(Inline)]
            get => new ProcDumpIdentity(EmptyString, Timestamp.Zero);
        }
    }
}