using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EqTectTrestAPI.Models.CandidateModels;

namespace EqTectTrestAPI.Models
{
    public class CandidateRepository: ICandidateRepository
    {
       
            private List<Candidate> Candidates = new List<Candidate>();
            private int _nextId = 1;

            public CandidateRepository()
            {
                Add(new Candidate { Id = "3f2b12b8-2a06-45b4-b057-45949279b4e5", ApplicationId = 197104, Type = "Debit", Summary = "Payment", Amount = 58.26, PostingDate = "2016-07-01T00:00:00", IsCleared =true, ClearedDate = "2016-07-02T00:00:00" });
                Add(new Candidate { Id = "3f2b12b8-2a06-45b4-b057-45949279b4e5", ApplicationId = 197105, Type = "Credit", Summary = "Payment", Amount = 68.26, PostingDate = "2016-07-01T00:00:00", IsCleared = true, ClearedDate = "2016-07-02T00:00:00" });
                Add(new Candidate { Id = "3f2b12b8-2a06-45b4-b057-45949279b4e5", ApplicationId = 197106, Type = "Debit", Summary = "Payment", Amount = 58.56, PostingDate = "2016-07-01T00:00:00", IsCleared = true, ClearedDate = "2016-07-02T00:00:00" });
                Add(new Candidate { Id = "3f2b12b8-2a06-45b4-b057-45949279b4e5", ApplicationId = 197107, Type = "Credit", Summary = "Payment", Amount = 88.66, PostingDate = "2016-07-01T00:00:00", IsCleared = true, ClearedDate = "2016-07-02T00:00:00" });

        }

        public Candidate Add(Candidate item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Can't Add");
            }
            item.ApplicationId = _nextId++;
            Candidates.Add(item);
            return item;
        }

        public Candidate Get(int id)
        {
            return Candidates.Find(p => p.ApplicationId == id);            
        }

        public IEnumerable<Candidate> GetAll()
        {
            return Candidates;
        }

        public void Remove(int id)
        {
            Candidates.RemoveAll(p => p.ApplicationId == id);
        }

        public bool Update(Candidate item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Can't Update");
            }
            int index = Candidates.FindIndex(p => p.ApplicationId == item.ApplicationId);
            if (index == -1)
            {
                return false;
            }
            Candidates.RemoveAt(index);
            Candidates.Add(item);
            return true;
        }

        

    }
}