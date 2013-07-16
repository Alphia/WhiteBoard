//using System.Collections.Generic;
//using FluentAssertions;
//using RestSharp;
//using Xunit;
//using WhiteBorad.Models;
//
//
//namespace WhiteBorad.Tests
//{
//    class PersonFacts
//    {
//        [Fact]
//        public void should_get_studuents_given_a_valid_request()
//        {
//            var names = new[] { "He Gang", "Liu Jing", "Zhang He" };
//            new SelfHostServer().Serv();
//            var restClient = new RestClient("http://localhost:8085/api");
//            var restResponse = restClient.Execute<List<Student>>(new RestRequest("students"));
//            var students = restResponse.Data;
//            students.ForEach(s => names.Should().Contain(s.Name));
//        }
//    }
//}
