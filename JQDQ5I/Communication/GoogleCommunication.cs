﻿using Newtonsoft.Json;
using GoogleBooks.Model;
using System.Configuration;
namespace GoogleBooks.Communication;

public class GoogleCommunication
{
    private readonly string baseUrl;
    //private readonly string apiKey;


    public GoogleCommunication()
    {
        baseUrl = ConfigurationManager.AppSettings["Google.Api.BaseUrl"];
        //apiKey = ConfigurationManager.AppSettings["Google.ApiKey"];
    }

    public GoogleApiSearchResult GoogleResultByParameters(string parameter)
    {
        var uri = new Uri(baseUrl + "volumes/?q=" + parameter);


        var response = RestCommunication.RestApiCommunication(uri, RestSharp.Method.Get);

        var results = JsonConvert.DeserializeObject<GoogleApiSearchResult>(response.Content);

        return results;
    }
}