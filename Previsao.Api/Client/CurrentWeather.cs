﻿using Previsao.Api.Model;
using Previsao.Api.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Previsao.Api.Client
{
    public class CurrentWeather
    {
        // fixando a lingua e sistema metrico
        public const string LANG = "pt";
        public const string UNIT = "metric";

        public static SingleResult<CurrentWeatherResult> GetByCityName(String city)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city))
                    return new SingleResult<CurrentWeatherResult>(null, false, "É preciso fornecer uma cidade.");
                var response = ApiClient.GetResponse("/weather?q=" + city + "&lang=" + LANG + "&units=" + UNIT);
                return Deserializer.GetWeatherCurrent(response);
            }
            catch (Exception ex)
            {
                return new SingleResult<CurrentWeatherResult> { Item = null, Success = false, Message = ex.Message };
            }
        }


        public static SingleResult<CurrentWeatherResult> GetByCityId(int id)
        {
            try
            {
                if (0 > id)
                    return new SingleResult<CurrentWeatherResult>(null, false, "É preciso fornecer uma cidade válida.");
                var response = ApiClient.GetResponse("/weather?id=" + id + "&lang=" + LANG + "&units=" + UNIT);
                return Deserializer.GetWeatherCurrent(response);
            }
            catch (Exception ex)
            {
                return new SingleResult<CurrentWeatherResult> { Item = null, Success = false, Message = ex.Message };
            }
        }
    }
}
