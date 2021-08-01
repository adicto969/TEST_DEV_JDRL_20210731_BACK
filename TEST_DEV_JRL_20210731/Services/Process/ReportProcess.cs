using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Output;
using TEST_DEV_JRL_20210731.DataAccess.Exceptions;
using TEST_DEV_JRL_20210731.Services.Interfaces;
using System.Net;
using RestSharp.Authenticators;
using System.Linq;

namespace TEST_DEV_JRL_20210731.Services.Process
{
    public class ReportProcess : IReportProcessService
    {
        private readonly IConfiguration _config;
        public ReportProcess(IConfiguration config)
        {
            this._config = config;
        }

        public ReportWithPaginate GetReport(int page = 1, int countPerPage = 20)
        {
            string token = this.AuthReport();

            var restClient = new RestClient();
            var request = new RestRequest($"{this._config["ApiReport:Url"]}customers", Method.GET);
            restClient.Authenticator = new JwtAuthenticator(token);

            var response = restClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = response.Content;

                ResponseReportDtoOutput responseReport = JsonConvert.DeserializeObject<ResponseReportDtoOutput>(responseBody);

                return new ReportWithPaginate
                {
                    TotalRecord = responseReport.Data.Count(),
                    Data = responseReport.Data.Skip(countPerPage * page).Take(countPerPage)
                };
            }

            throw new SystemValidationException("Error Report");
        }

        private string AuthReport()
        {
            var restClient = new RestClient();
            var request = new RestRequest($"{this._config["ApiReport:Url"]}login/authenticate", Method.POST);
            request.AddParameter("Username", this._config["ApiReport:Username"]);
            request.AddParameter("Password", this._config["ApiReport:Password"]);

            var response = restClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = response.Content;

                AuthReportDtoOutput auth = JsonConvert.DeserializeObject<AuthReportDtoOutput>(responseBody);

                return auth.Data;
            }

            throw new SystemValidationException("Error Report");
        }
    }
}
