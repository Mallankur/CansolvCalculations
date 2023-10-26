using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anurgenlib
{/// <summary>
/// Ankur@Mall@Avin@exadformLPP
/// </summary>
    public class CansolvJfrog
    {
        private IMongoCollection<BsonDocument> collection;
        /// <summary>
        /// theclientconnwction@ankur
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        /// <param name="collectionName"></param>
        public CansolvJfrog(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);
        }
       /// <summary>
       /// @AnkurMallLib
       /// </summary>
       /// <param name="startTime"></param>
       /// <param name="endTime"></param>
       /// <param name="tagNames"></param>
       /// <param name="frequency"></param>
       /// <returns></returns>
        public List<AggregationModel> CalculateAverageForTimeInterval(DateTime startTime, DateTime endTime, string[] tagNames, long frequency)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.In("TagName", tagNames),
                Builders<BsonDocument>.Filter.Gte("EventTime", startTime),
                Builders<BsonDocument>.Filter.Lte("EventTime", endTime)
            );

            var aggregation = collection.Aggregate()
                .Match(filter)
                .Group(new BsonDocument
                {
            { "_id", new BsonDocument { { "TagName", "$TagName" }, { "timeInterval", new BsonDocument("$toDate", new BsonDocument("$subtract", new BsonArray { "$EventTime", new BsonDocument("$mod", new BsonArray { new BsonDocument("$toLong", "$EventTime"), frequency }) })) } } },
            { "averageValue", new BsonDocument("$avg", "$Value") }
                })
                .Project(new BsonDocument
                {
            { "_id", 0 },
            { "TagName", "$_id.TagName" },
            { "EventTime", new BsonDocument("$concat", new BsonArray
                {
                    new BsonDocument("$dateToString", new BsonDocument("format", "%Y-%m-%dT%H:%M:%S.%LZ").Add("date", "$_id.timeInterval")),
                    " to ",
                    new BsonDocument("$dateToString", new BsonDocument("format", "%Y-%m-%dT%H:%M:%S.%LZ").Add("date", new BsonDocument("$add", new BsonArray { "$_id.timeInterval", frequency })))
                })
            },
            { "Average", "$averageValue" }
                });;

            var results = aggregation.ToList(); 
           

            var aggregationModels = results.Select(result =>
            {
                var tagName = result.GetValue("TagName").AsString;
                var eventTime = result.GetValue("EventTime").AsString;
                var averageValue = result.GetValue("Average").ToDouble();

                return new AggregationModel
                {
                    TagName = tagName,
                    EventTime = eventTime,
                    Average = averageValue
                };
            }).ToList();

            return aggregationModels;
        }

    }

}

