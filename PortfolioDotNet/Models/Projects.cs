using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace PortfolioDotNet.Models
{
    public class Projects
    {
		public string Name { get; set; }
		public string html_url { get; set; }

		public static List<Projects> GetProjects()
		{
			var client = new RestClient("https://api.github.com");
			var request = new RestRequest("search/repositories?q=user:irishdowd10&sort=stars:&order=asc&per_page=3", Method.GET);

			request.AddHeader("User-Agent", "irishdowd10");
			var response = new RestResponse();

			Task.Run(async () =>
			{
				response = await GetResponseContentAsync(client, request) as RestResponse;
			}).Wait();

			JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
			var projectList = JsonConvert.DeserializeObject<List<Projects>>(jsonResponse["items"].ToString());

			return projectList;
		}

		public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
		{
			var tcs = new TaskCompletionSource<IRestResponse>();
			theClient.ExecuteAsync(theRequest, response =>
			{
				tcs.SetResult(response);
			});
			return tcs.Task;
		}
	}
}
