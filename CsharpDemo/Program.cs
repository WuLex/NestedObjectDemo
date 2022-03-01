using CsharpDemo.Common;
using CsharpDemo.Model;
using Newtonsoft.Json;

string jsonstr = "";
jsonstr += "{" +
           "    \"response\": {" +
           "        \"result\": {" +
           "            \"errmsg\": \"Success.\"," +
           "            \"code\": \"0\"" +
           "        }," +
           "        \"number\": \"27\"," +
           "        \"peopleList\": {" +
           "            \"people\": [" +
           "                {" +
           "                    \"bornTime\": \"\"," +
           "                    \"country\": \"\"," +
           "                    \"createTime\": \"1644807612798\"," +
           "                    \"credentialType\": \"0\"," +
           "                    \"description\": \"\"," +
           "                    \"faceList\": {" +
           "                        \"face\": [" +
           "                            {" +
           "                                \"faceId\": \"27595292588606721\"," +
           "                                \"face-state\": \"0\"," +
           "                                \"fileId\": \"6209c5b1f71fc35ebc9b9240\"" +
           "                            }" +
           "                        ]" +
           "                    }," +
           "                    \"gender\": \"-1\"," +
           "                    \"group\": {" +
           "                        \"groupid\": \"6209b7099f5c4c42707db4bf\"," +
           "                        \"groupname\": \"SZY-黑名单\"," +
           "                        \"owner\": \"true\"" +
           "                    }," +
           "                    \"name\": \"目标3\"," +
           "                    \"nationality\": \"\"," +
           "                    \"occupation\": \"\"," +
           "                    \"peopleId\": \"6209c5bc9f5c4c42707db4c1\"," +
           "                    \"state\": \"0\"," +
           "                    \"type\": \"2\"" +
           "                }," +
           "                {" +
           "                    \"bornTime\": \"\"," +
           "                    \"country\": \"\"," +
           "                    \"createTime\": \"1644807573987\"," +
           "                    \"credentialType\": \"0\"," +
           "                    \"description\": \"\"," +
           "                    \"faceList\": {" +
           "                        \"face\": [" +
           "                            {" +
           "                                \"faceId\": \"27595291951056128\"," +
           "                                \"face-state\": \"0\"," +
           "                                \"fileId\": \"6209c588f71fc35ebc9b923e\"" +
           "                            }" +
           "                        ]" +
           "                    }," +
           "                    \"gender\": \"-1\"," +
           "                    \"group\": {" +
           "                        \"groupid\": \"6209b7099f5c4c42707db4bf\"," +
           "                        \"groupname\": \"SZY-黑名单\"," +
           "                        \"owner\": \"true\"" +
           "                    }," +
           "                    \"name\": \"mubiao\"," +
           "                    \"nationality\": \"\"," +
           "                    \"occupation\": \"\"," +
           "                    \"peopleId\": \"6209c595d7338e072921d091\"," +
           "                    \"state\": \"0\"," +
           "                    \"type\": \"2\"" +
           "                }" +
           "            ]" +
           "        }" +
           "    }" +
           "}";

string resultstrCompress = JsonHelper.Compress(jsonstr);

try
{
    ReturnSearchBwdata ptt = JsonConvert.DeserializeObject<ReturnSearchBwdata>(resultstrCompress);
    var code = Convert.ToInt32(ptt.Response.Result.Code);
    var meessage = ptt.Response.Result.Errmsg;
    List<PeopleBwdatas> datas = new List<PeopleBwdatas>();


    var peopleCount = ptt.Response.PeopleList.People.Count;
    for (int i = 0; i < peopleCount; i++)
    {
        PeopleBwdatas data = new PeopleBwdatas();

        var peopleItem = ptt.Response.PeopleList.People[i];

        data.bornTime = peopleItem.bornTime;
        data.country = peopleItem.country;
        data.CreateTime = peopleItem.CreateTime;
        data.CredentialType = peopleItem.CredentialType;
        data.Description = peopleItem.Description;
        for (int j = 0; j < peopleItem.FaceList.Face.Count; j++)
        {
            data.FaceList.Face.Add(new FaceBwdata()
            {
                FaceId = peopleItem.FaceList.Face[j].FaceId,
                FaceState = peopleItem.FaceList.Face[j].FaceState,
                FileId = peopleItem.FaceList.Face[j].FileId,
            });
            //data.FaceList.Face[i].faceId = peopleItem.faceList.face[j].faceId;
            //data.FaceList.Face[i].face_state = peopleItem.faceList.face[j].face_state;
            //data.FaceList.Face[i].fileId = peopleItem.faceList.face[j].fileId;

            //FaceFaceByFaceIds face = new FaceFaceByFaceIds();
            //face.faceId = peopleItem.FaceList.Face[j].FaceId;
            //face.face_state = peopleItem.FaceList.Face[j].FaceState;
            //face.fileId = peopleItem.FaceList.Face[j].FileId;
        }

        data.Gender = peopleItem.Gender;
        //GroupBwdata group = new GroupBwdata();
        //group.groupid = peopleItem.group.groupid;
        //group.groupname = peopleItem.group.groupname;
        //group.owner = peopleItem.group.owner;
        data.Group = new GroupBwdata
        {
            Groupid = peopleItem.Group.Groupid,
            Groupname = peopleItem.Group.Groupname,
            Owner = peopleItem.Group.Owner
        };

        data.Name = peopleItem.Name;
        data.Nationality = peopleItem.Nationality;
        data.Occupation = peopleItem.Occupation;
        data.PeopleId = peopleItem.PeopleId;
        data.State = peopleItem.State;
        data.Type = peopleItem.Type;
        datas.Add(data);
    }
}
catch (Exception ex)
{
    // ignored
}

Console.Write(resultstrCompress);

Console.ReadKey(); 

