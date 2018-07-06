using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalSpringDemo
{
    public class AdoNetUserInfoDal : IUserInfoDal
    {
        public AdoNetUserInfoDal(string name, UserInfo userInfo)
        {
            Name = name;
            UserInfo = userInfo;
        }

        public UserInfo UserInfo { get; set; }
        public string Name { get; set; }

        public void Show()
        {
            Console.WriteLine("我是 AdoNet Dal, 属性注入：Name="+Name);
            Console.WriteLine("UserInfo, name=" + UserInfo.Name + " Age=" + UserInfo.Age);
        }
    }
}
