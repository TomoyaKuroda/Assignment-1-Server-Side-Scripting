using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public interface IquestionersMock
    {
        IQueryable<questioner> questioners { get; }
        IQueryable<question> question { get; }
        questioner Save(questioner questioner);
        void Delete(questioner questioner);
    }
}
