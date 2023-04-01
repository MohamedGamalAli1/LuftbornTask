using System;

namespace LuftbornTask.Models
{
    public class BaseObject
    {
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DeletionDate { get; set; }
        public string Deletion { get; set; }

    }
}
