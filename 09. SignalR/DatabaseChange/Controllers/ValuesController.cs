using DatabaseChange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatabaseChange.Controllers
{
    public class ValuesController : ApiController
    {
        JobInfoRepository objRepo = new JobInfoRepository();

        // GET api/values
        public IEnumerable<JobInfo> Get()
        {
            return objRepo.GetData();
        }
    }
}
