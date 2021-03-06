//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures state machine execution metrics
    /// </summary>
    [Record(TableId)]
    public struct FsmStats : IRecord<FsmStats>
    {
        public const string TableId = "fsm.stats";
        /// <summary>
        /// Identifies the machine within the executing process
        /// </summary>
        public string MachineId;

        /// <summary>
        /// The time the machine received the start signal
        /// </summary>
        public ulong? StartTime;

        /// <summary>
        /// The time the machine workflow completed
        /// </summary>
        public ulong? EndTime;

        /// <summary>
        /// The number of received events
        /// </summary>
        public ulong ReceiptCount;

        /// <summary>
        /// The number of state transitions that have occurred
        /// </summary>
        public uint TransitionCount;

        /// <summary>
        /// The time spent during active execution
        /// </summary>
        public Duration Runtime;

        public override int GetHashCode()
            => MachineId.GetHashCode();
    }
}