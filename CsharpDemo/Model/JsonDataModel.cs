using Newtonsoft.Json;

namespace CsharpDemo.Model
{
    public class ReturnSearchBwdata
    {
        public ReturnSearchBwdata() { 
        
          Response = new BwdataResponse();  
        
        }
        public BwdataResponse Response { get; set; }
    }

    public class ResultBwdata
    {
        public string Errmsg { get; set; }

        public string Code { get; set; }
    }

    public class FaceBwdata
    {
        public string FaceId { get; set; }

        [JsonProperty(PropertyName = "face-state")]
        public string FaceState { get; set; }

        public string FileId { get; set; }
    }

    public class FaceListBwdata
    {
        public FaceListBwdata()
        {
            Face = new List<FaceBwdata>();
        }

        public List<FaceBwdata> Face { get; set; }
    }

    public class GroupBwdata
    {
        public string Groupid { get; set; }

        public string Groupname { get; set; }

        public string Owner { get; set; }
    }

    public class PeopleBwdatas
    {
        public PeopleBwdatas()
        {
            FaceList = new FaceListBwdata();
            Group = new GroupBwdata();
        }

        public string bornTime { get; set; }

        public string country { get; set; }

        public string CreateTime { get; set; }

        public string CredentialType { get; set; }

        public string Description { get; set; }

        public FaceListBwdata FaceList { get; set; }

        public string Gender { get; set; }

        public GroupBwdata Group { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public string Occupation { get; set; }

        public string PeopleId { get; set; }

        public string State { get; set; }

        public string Type { get; set; }
    }

    public class PeopleListBwdata
    {
        public PeopleListBwdata()
        { 
           People=new List<PeopleBwdatas>();
        }
        public List<PeopleBwdatas> People { get; set; }
    }

    public class BwdataResponse
    {
        public BwdataResponse()
        {
            Result=new ResultBwdata();
            PeopleList=new PeopleListBwdata();
        }
        public ResultBwdata Result { get; set; }

        public string Number { get; set; }

        public PeopleListBwdata PeopleList { get; set; }
    }
}
