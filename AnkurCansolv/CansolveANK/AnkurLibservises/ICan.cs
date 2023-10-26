using CansolveANK.CansolveModel;

namespace CansolveANK.AnkurLibservises
{
    public interface ICan
    {/// <summary>
    /// @AnkurMall@exAdform
    /// </summary>
    /// <param name="EventTimeStart"></param>
    /// <param name="EvenntTimeEnd"></param>
    /// <returns></returns>
        Task<List<Cansolve>> GetByEvenTimeAsync(DateTime EventTimeStart , DateTime EvenntTimeEnd );
        /// <summary>
        /// @AnkurMall@exAdform
        /// </summary>
        /// <param name="Tagname"></param>
        /// <returns></returns>
        Task<Cansolve> GetByIdAsync(String Tagname);
        /// <summary>
        /// @AnkurMall@exAdform
        /// </summary>
        /// <param name="startEVENTtIME"></param>
        /// <param name="endTime"></param>
        /// <param name="TagName"></param>
        /// <param name="frequency"></param>
        /// <returns></returns>
        Task<List<AggregationModelResult>> GetAvgValue(DateTime startEVENTtIME, DateTime endTime , string[] TagName, long frequency );
    }
}
