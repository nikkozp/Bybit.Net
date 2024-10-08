﻿using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums.V5
{
    /// <summary>
    /// Copy trading type
    /// </summary>
    public enum CopyTradingType
    {
        /// <summary>
        /// Regardless of normal account or UTA account, this trading pair does not support copy trading
        /// </summary>
        [Map("none")]
        None,

        /// <summary>
        /// For both normal account and UTA account, this trading pair supports copy trading
        /// </summary>
        [Map("both")]
        Both,

        /// <summary>
        /// Only for UTA account,this trading pair supports copy trading
        /// </summary>
        [Map("utaOnly")]
        UtaOnly,

        /// <summary>
        /// Only for normal account, this trading pair supports copy trading
        /// </summary>
        [Map("normalOnly")]
        Normal
    }
}
