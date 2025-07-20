using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.DTO
{
    public class AuditoryData
    {
        public int IdEntity { get; set; }
        public string NameTable { get; set; }

        public AuditoryData() { }
        public AuditoryData (int id, string nameTable)
        {
            IdEntity = id;
            NameTable = nameTable;
        }

    }
}
