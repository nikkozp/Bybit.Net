using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Position mode idx
    /// </summary>
    public enum PositionModeIdx
    {
        /// <summary>
        /// One way
        /// </summary>
        OneWay = 0,

        /// <summary>
        /// Both Side Buy
        /// </summary>
        HedgeBuy = 1,

        /// <summary>
        /// Both Side Sell
        /// </summary>
        HedgeSell = 2
    }
}
