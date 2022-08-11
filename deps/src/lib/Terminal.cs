//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Lib
{
    using System.Text;

    class Terminal
    {
        public static ref readonly Terminal service
            => ref Instance;

        static readonly Terminal Instance = new Terminal();

        readonly object TermLock;

        readonly object ErrLock;

        readonly object StdLock;

        Terminal()
        {
             TermLock = new object();
             ErrLock = new object();
             StdLock = new object();
             Console.OutputEncoding = new UnicodeEncoding();
             Console.CancelKeyPress += Terminate;
        }


        void Receiver(ConsoleCancelEventArgs e)
        {

        }

        void Terminate(object sender, ConsoleCancelEventArgs args)
            => Receiver(args);

        public void WriteLine<T>(T msg)
        {
            lock(TermLock)
                Console.WriteLine(msg);
        }

        public void WriteLine(string format, params object?[]? args)
        {
            lock(TermLock)
                Console.WriteLine(format,args);
        }

        public void WriteLine()
        {
            lock(TermLock)
                Console.WriteLine();
        }

    }
}
