using MedicalApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Interfaces
{
    public interface Entity
    {
        public AuditoryData GetAuditoryData();
    }
}
