//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.IO;

    using static Root;

    public delegate void FileChanged(FileChange description);

    public class ArchiveMonitor : IArchiveMonitor
    {
        public static IArchiveMonitor start(FS.FolderPath path, FileChanged listener, bool recursive = true, string filter = null)
            => new ArchiveMonitor(path, listener, recursive, filter);

        public FS.FolderPath Root {get;}

        readonly FileSystemWatcher Watcher;

        readonly FS.ChangeHandler Handler;

        event FileChanged Listener;

        public ArchiveMonitor(FS.FolderPath subject, FileChanged listener, bool recursive = true, string filter = null)
        {
            Root = subject;
            Watcher = new FileSystemWatcher(subject.Name, filter ?? "*.*");
            Watcher.IncludeSubdirectories = recursive;
            Handler = SignalChange;
            Listener += listener;
            Subscribe();
            Start();
        }

        void SignalChange(FileChange change)
        {
            try
            {
                Task.Factory.StartNew(() => Listener.Invoke(change));
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        [MethodImpl(Inline)]
        public static FileChange change(FileSystemEventArgs e)
            => new FileChange(FS.path(e.FullPath), (FS.ChangeKind)e.ChangeType);

        [MethodImpl(Inline)]
        void Created(object sender, FileSystemEventArgs e)
            => Handler(change(e));

        [MethodImpl(Inline)]
        void Deleted(object sender, FileSystemEventArgs e)
            => Handler(change(e));

        [MethodImpl(Inline)]
        void Changed(object sender, FileSystemEventArgs e)
            => Handler(change(e));

        [MethodImpl(Inline)]
        void Renamed(object sender, FileSystemEventArgs e)
            => Handler(change(e));

        void Subscribe()
        {
            Watcher.Created += Created;
            Watcher.Deleted += Deleted;
            Watcher.Changed += Changed;
            Watcher.Renamed += Renamed;
            Watcher.Error += Error;
        }

        [MethodImpl(Inline)]
        public void Start()
            => Watcher.EnableRaisingEvents = true;

        [MethodImpl(Inline)]
        public void Stop()
            => Watcher.EnableRaisingEvents = false;

        public void Dispose()
            => Watcher?.Dispose();

        void Error(object sender, ErrorEventArgs e)
        {
            Console.Error.WriteLine(e.GetException());
        }
    }
}