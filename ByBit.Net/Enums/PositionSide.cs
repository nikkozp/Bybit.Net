using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Side of a position
    /// </summary>
    public enum PositionSide
    {
        /// <summary>
        /// Buy
        /// </summary>
        [Map("Buy")]
        Long,
        /// <summary>
        /// Sell
        /// </summary>
        [Map("Sell")]
        Short,
        /// <summary>
        /// None
        /// </summary>
        [Map("")]
        None
    }
}
