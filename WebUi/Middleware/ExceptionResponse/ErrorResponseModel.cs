using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebUi.Middleware.ExceptionResponse
{
    [DataContract]
    public class ErrorResponseModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "details")]
        public List<ErrorResponseDetailModel> ErrorDetails { get; set; }
        [DataMember(Name = "debugId")]
        public string DebugId { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }

    [DataContract(Name = "details")]
    public class ErrorResponseDetailModel
    {
        [DataMember(Name = "field")]
        public string Field { get; set; }
        [DataMember(Name = "issue")]
        public string Issue { get; set; }
        [DataMember(Name = "location")]
        public string Location { get; set; }
    }
}
