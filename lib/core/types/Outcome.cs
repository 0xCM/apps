//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Outcomes;

    /// <summary>
    /// Defines the outcome of an operation/process
    /// </summary>
    public readonly struct Outcome : IOutcome
    {
        [MethodImpl(Inline)]
        internal static Outcome combine(Outcome a, Outcome b)
            => (a.Ok && b.Ok, string.Format("{0}\r\r{1}",a.Message, b.Message));

        [MethodImpl(Inline)]
        public static Outcome fail(string msg)
            => (false,msg);

        public bool Ok {get;}

        public string Message {get;}

        public ulong MessageCode {get;}

        public bool Fail => !Ok;

        [MethodImpl(Inline)]
        public Outcome(bool success)
        {
            Ok = success;
            Message = success ? EmptyString : "Bad";
            MessageCode = api.u8(Ok);
        }

        [MethodImpl(Inline)]
        public Outcome(bool success, string message)
        {
            Ok = success;
            Message = message;
            MessageCode = api.u8(Ok);
        }

        [MethodImpl(Inline)]
        public Outcome(bool success, string message, ulong code)
        {
            Ok = success;
            Message = message;
            MessageCode = code;
        }

        public Outcome(Exception e)
        {
            Ok = false;
            Message = e.ToString();
            MessageCode = api.u8(Ok);
        }

        public Outcome(Exception e, string msg)
        {
            Ok = false;
            Message = string.Format("{0} - {1}", msg, e);
            MessageCode = api.u8(Ok);
        }

        [MethodImpl(Inline)]
        Outcome(ulong code)
        {
            Ok = false;
            Message = EmptyString;
            MessageCode = code;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => MessageCode == ulong.MaxValue;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Message;

        public override string ToString()
            => Format();

        public void Require()
        {
            if(Fail)
                throw new Exception(Message ?? "An eggregious blunder");
        }

        public static Outcome operator +(Outcome a, Outcome b)
            => combine(a,b);

        public static Outcome operator &(Outcome a, Outcome b)
            => combine(a,b);

        [MethodImpl(Inline)]
        public static implicit operator Outcome(bool src)
            => new Outcome(src);

        [MethodImpl(Inline)]
        public static implicit operator bool(Outcome src)
            => src.Ok;

        [MethodImpl(Inline)]
        public static implicit operator Outcome(Exception e)
            => new Outcome(e);

        [MethodImpl(Inline)]
        public static implicit operator Outcome((Exception e, string msg) src)
            => new Outcome(src.e,src.msg);

        [MethodImpl(Inline)]
        public static implicit operator Outcome((bool success, string msg) src)
            => new Outcome(src.success, src.msg);

        [MethodImpl(Inline)]
        public static bool operator true(Outcome src)
            => src.Ok == true;

        [MethodImpl(Inline)]
        public static bool operator false(Outcome src)
            => src.Ok == false;

        public static Outcome Success
        {
            [MethodImpl(Inline)]
            get => new Outcome(true);
        }

        public static Outcome Failure
        {
            [MethodImpl(Inline)]
            get => new Outcome(false);
        }

        public static Outcome Empty
        {
            [MethodImpl(Inline)]
            get => new Outcome(ulong.MaxValue);
        }
    }
}