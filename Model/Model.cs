using System;

namespace Model
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string UserImg { get; set; }
    }
    public class Activity
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public DateTime EndTime { get; set; }
        public string ActivityPicture { get; set; }
        public string ActivityIntroduction { get; set; }
        public string Summary { get; set; }
        public string ActivityVerify { get; set; }
        public string ActivityStatus {get;set;}
        public string UserName { get; set; }//请自己添加Activity表其他字段
    }
}
