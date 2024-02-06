using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    public enum SelfTradePreventionMode
    {
        /// <summary>
        /// No STP
        /// </summary>
        None,

        /// <summary>
        /// expire taker order when STP triggers
        /// </summary>
        Expire_taker,

        /// <summary>
        /// expire taker order when STP triggers
        /// </summary>
        Expire_maker,

        /// <summary>
        /// expire both orders when STP triggers
        /// </summary>
        Expire_both
    }
}
