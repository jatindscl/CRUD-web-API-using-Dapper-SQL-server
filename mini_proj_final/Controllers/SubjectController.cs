using System;
using System.Collections.Generic;
using System.Linq;
// using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mini_proj_final.Model;
namespace mini_proj_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectRepository subjectRepository;
        public SubjectController()
        {
            subjectRepository =new SubjectRepository();
        }

        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            return subjectRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Subject Get(int id)
        {
            return subjectRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Subject sub)
        {
            if(ModelState.IsValid)
                {
                    subjectRepository.Add(sub);
                }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Subject sub)
        {
            sub.Code=id;
            if(ModelState.IsValid)
                {
                    subjectRepository.Update(sub);
                }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            subjectRepository.Delete(id);
        }
    }
}
