using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionReferences.Domain.Models;

namespace SolutionReferences.Domain.ServiceInterfaces
{
    public interface ISolutionDatabaseService
    {
        public void AddSolutionToDatabase(Solution solution);
    }
}
