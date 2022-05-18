﻿using System.Text.Json.Serialization;

namespace DemoCodeFirst.Data.ViewModels.City
{
    public class CityInsertModel
    {
        [JsonPropertyName("state_id")]
        public int StateId { get; set; }
        public string Name { get; set; }
    }
}
