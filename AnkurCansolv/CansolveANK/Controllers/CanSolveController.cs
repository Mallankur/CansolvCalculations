using CansolveANK.AnkurLibservises;
using CansolveANK.CansolveModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CansolveANK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanSolveController : ControllerBase
    {
        private readonly ICan _Servises;
        public CanSolveController(ICan servises)
        {
            _Servises = servises;
        }
     /// <summary>
     /// @AnkurMall 
     /// </summary>
     /// <param name="EventTimestart"></param>
     /// <param name="EventTimeEnd"></param>
     /// <returns></returns>
        [HttpGet]
        public async Task<List<FilterModelcs>> GetAsync(DateTime EventTimestart , DateTime EventTimeEnd)
        {
            var  result2  = new List<FilterModelcs>();
            var result = await _Servises.GetByEvenTimeAsync(EventTimestart,EventTimeEnd);
            foreach (var item in result)
            {
               var res =  new FilterModelcs 
                {
                   id = item.Id,    
                    TagName = item.TagName,
                    Value = item.DoubleValue,
                    EventTime = item.EventTime,
                    
                };


                

                 result2.Add(res);
            }

          
            return result2; 

        }

        [HttpGet("{StartEventTimeAvgCalculations}")]
        public async Task<List<AggregationModelResult>> GetAvgValue(DateTime StartEventTimeAvgCalculations, DateTime endTimeForCalculations,
            string[] TagName, long frequency)
        {
            return await _Servises.GetAvgValue(StartEventTimeAvgCalculations, endTimeForCalculations, TagName, frequency);
        }
        /// <summary>
        /// @AnkurMall
        /// </summary>
        /// <param name="StartEventTimeAvgCalculations"></param>
        /// <param name="endTimeForCalculations"></param>
        /// <param name="frequency"></param>
        /// <param name="TagName"></param>
        /// <returns></returns>
        [HttpPost("{StartEventTimeAvgCalculations}/{endTimeForCalculations}/{frequency}")]
        public async Task<List<AggregationModelResult>> GetAvgValue(
    DateTime StartEventTimeAvgCalculations,
    DateTime endTimeForCalculations,
    long frequency,
    [FromBody] string[] TagName) 
        {
            return await _Servises.GetAvgValue(StartEventTimeAvgCalculations, endTimeForCalculations, TagName, frequency);
        }

    }
}
