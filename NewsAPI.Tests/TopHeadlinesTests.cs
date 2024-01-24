﻿using System;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI.Tests.TestData;

namespace NewsAPI.Tests
{
	public class TopHeadlinesTests : NewsApiTest
	{

        [Theory]
        [ClassData(typeof(TopHeadlinesTestCases))]
        public async Task GetTopHeadlines_ValidParameters_Ok(
            TopHeadlinesRequest request, string expectedUrl)
        {
            var newsApi = Arrange();

            var response = await newsApi.GetTopHeadlinesAsync(request);

            Assert.NotNull(response);
            Assert.Equal(expectedUrl, MessageHandler.RequestedUrl);
            Assert.Equal(Options.ApiKey, MessageHandler.SubmittedApiKey);
        }
    }
}
/*
[TestMethod]
public void BasicTopHeadlinesRequestWorks()
{
    var topHeadlinesRequest = new TopHeadlinesRequest();

    topHeadlinesRequest.Sources.Add("techcrunch");

    var result = NewsApiClient.GetTopHeadlines(topHeadlinesRequest);

    Assert.AreEqual(Statuses.Ok, result.Status);
    Assert.IsTrue(result.TotalResults > 0);
    Assert.IsTrue(result.Articles.Count > 0);
    Assert.IsNull(result.Error);
}

[TestMethod]
public void BadTopHeadlinesRequestReturnsError()
{
    var topHeadlinesRequest = new TopHeadlinesRequest();

    var brokenClient = new NewsApiClient("nokey");

    topHeadlinesRequest.Sources.Add("techcrunch");

    var result = brokenClient.GetTopHeadlines(topHeadlinesRequest);

    Assert.AreEqual(Statuses.Error, result.Status);
    Assert.IsNull(result.Articles);
    Assert.IsNotNull(result.Error);
    Assert.AreEqual(ErrorCodes.ApiKeyInvalid, result.Error.Code);
}

[TestMethod]
public void BadTopHeadlinesRequestReturnsError2()
{
    var topHeadlinesRequest = new TopHeadlinesRequest();

    topHeadlinesRequest.Sources.Add("techcrunch");
    topHeadlinesRequest.Country = Countries.AU;
    topHeadlinesRequest.Language = Languages.EN;

    var result = NewsApiClient.GetTopHeadlines(topHeadlinesRequest);

    Assert.AreEqual(Statuses.Error, result.Status);
    Assert.IsNull(result.Articles);
    Assert.IsNotNull(result.Error);
    Assert.AreEqual(ErrorCodes.ParametersIncompatible, result.Error.Code);
}*/