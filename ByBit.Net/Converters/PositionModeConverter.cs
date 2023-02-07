﻿using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class PositionModeConverter : BaseConverter<PositionMode>
    {
        public PositionModeConverter() : this(true) { }
        public PositionModeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<PositionMode, string>> Mapping => new List<KeyValuePair<PositionMode, string>>
        {
            new KeyValuePair<PositionMode, string>(PositionMode.OneWay, "MergedSingle"),
            new KeyValuePair<PositionMode, string>(PositionMode.Hedge, "BothSide")
        };
    }
}
