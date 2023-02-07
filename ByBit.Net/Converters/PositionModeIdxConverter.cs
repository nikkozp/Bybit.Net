using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Converters
{
    internal class PositionModeIdxConverter : BaseConverter<PositionModeIdx>
    {
        public PositionModeIdxConverter() : this(true) { }
        public PositionModeIdxConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<PositionModeIdx, string>> Mapping => new List<KeyValuePair<PositionModeIdx, string>>
        {
            new KeyValuePair<PositionModeIdx, string>(PositionModeIdx.OneWay, "0"),
            new KeyValuePair<PositionModeIdx, string>(PositionModeIdx.HedgeBuy, "1"),
            new KeyValuePair<PositionModeIdx, string>(PositionModeIdx.HedgeSell, "2"),
        };
    }
}
