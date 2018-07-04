using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EqTectTrestAPI.Models;
using static EqTectTrestAPI.Models.CandidateModels;

namespace EqTectTrestAPI.Controllers
{
    [Authorize]
    public class CandidateController : ApiController
    {
        static readonly ICandidateRepository repository = new CandidateRepository();

        /// <summary>
        /// Get All Candidates
        /// </summary>
        /// <returns> json format</returns>
        [HttpGet]
        public IEnumerable<Candidate> GetAll()
        {
            return repository.GetAll();
        }

        //Get Particular Candidate value 
        [HttpGet]
        public Candidate GetCandidate(int ApplicationId)
        {
            Candidate item = repository.Get(ApplicationId);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        //insert or post candidate details 
        [HttpPost]
        public HttpResponseMessage PostCandidate(Candidate item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Candidate>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { ApplicationId = item.ApplicationId });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // put / update candidate information
        [HttpPut]
        public void PutCandidate(int ApplicationId, Candidate Candidate)
        {
            Candidate.ApplicationId = ApplicationId;
            if (!repository.Update(Candidate))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //Delete particular candidate details
        [HttpDelete]
        public void DeleteCandidate(int ApplicationId)
        {
            Candidate item = repository.Get(ApplicationId);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(ApplicationId);
        }
    }
    
}
