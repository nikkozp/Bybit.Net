﻿using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using Bybit.Net.Objects.Models.CopyTrading;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.CopyTradingApi
{
    /// <inheritdoc />
    public class BybitRestClientCopyTradingApiTrading : IBybitRestClientCopyTradingApiTrading
    {
        private BybitRestClientCopyTradingApi _baseClient;

        internal BybitRestClientCopyTradingApiTrading(BybitRestClientCopyTradingApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Positions

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitCopyTradingPosition>>> GetPositionsAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            return await _baseClient.SendRequestListAsync<BybitCopyTradingPosition>(_baseClient.GetUrl("contract/v3/private/copytrading/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Close Position

        /// <inheritdoc />
        public async Task<WebCallResult> ClosePositionAsync(string symbol, PositionModeIdx positionModeIdx, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "positionIdx", JsonConvert.SerializeObject(positionModeIdx, new PositionModeIdxConverter(false)) }
            };
            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/copytrading/position/close"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Close Position

        /// <inheritdoc />
        public async Task<WebCallResult> SetLeverageAsync(string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "buyLeverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sellLeverage", sellLeverage.ToString(CultureInfo.InvariantCulture) }
            };
            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/copytrading/position/set-leverage"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Place Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCopyTradingId>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal? price = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "orderType", JsonConvert.SerializeObject(type, new OrderTypeConverter(false)) },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) }
            };

            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerType == null ? null : JsonConvert.SerializeObject(takeProfitTriggerType, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerType == null ? null : JsonConvert.SerializeObject(stopLossTriggerType, new OrderTypeConverter(false)));
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);

            return await _baseClient.SendRequestAsync<BybitCopyTradingId>(_baseClient.GetUrl("contract/v3/private/copytrading/order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set Trading Stop

        /// <inheritdoc />
        public async Task<WebCallResult> SetTradingStopAsync(string symbol, string parentOrderId, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, string? parentClientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "parentOrderId", parentOrderId }
            };

            parameters.AddOptionalParameter("price", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("price", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("price", EnumConverter.GetString(takeProfitTriggerType));
            parameters.AddOptionalParameter("price", EnumConverter.GetString(stopLossTriggerType));
            parameters.AddOptionalParameter("parentOrderLinkId", parentClientOrderId);

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/copytrading/order/trading-stop"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Get Orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitCopyTradingOrder>>> GetOrdersAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, string? copyTradeOrderType = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("copyTradeOrderType", copyTradeOrderType);
            return await _baseClient.SendRequestListAsync<BybitCopyTradingOrder>(_baseClient.GetUrl("contract/v3/private/copytrading/order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCopyTradingId>> CancelOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            if ((orderId == null && clientOrderId == null) || (orderId != null && clientOrderId != null))
                throw new ArgumentException("Either orderId or clientOrderId should be provided");

            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            return await _baseClient.SendRequestAsync<BybitCopyTradingId>(_baseClient.GetUrl("contract/v3/private/copytrading/order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Close Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCopyTradingId>> CloseOrderAsync(string symbol, string? clientOrderId = null, string? parentOrderId = null, string? parentClientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("parentOrderId", parentOrderId);
            parameters.AddOptionalParameter("parentOrderLinkId", parentClientOrderId);
            return await _baseClient.SendRequestAsync<BybitCopyTradingId>(_baseClient.GetUrl("contract/v3/private/copytrading/order/close"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
