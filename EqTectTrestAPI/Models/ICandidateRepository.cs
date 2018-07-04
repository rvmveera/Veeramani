using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EqTectTrestAPI.Models.CandidateModels;

namespace EqTectTrestAPI.Models
{
    interface ICandidateRepository
    {
        
            IEnumerable<Candidate> GetAll();
            Candidate Get(int id);
            Candidate Add(Candidate item);
            void Remove(int id);
            bool Update(Candidate item);
       
    }
}
