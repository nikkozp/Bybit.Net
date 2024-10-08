﻿using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account status
    /// </summary>
    public enum SubAccountStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("1")]
        Normal,
        /// <summary>
        /// Login banned
        /// </summary>
        [Map("2")]
        LoginBanned,
        /// <summary>
        /// Frozen
        /// </summary>
        [Map("4")]
        Frozen
    }
}
