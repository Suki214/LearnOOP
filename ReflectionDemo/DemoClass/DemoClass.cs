using RecordAttributeDemo;
namespace DemoClass
{
    //Normal Comments --this part will not show in IL
    //RecordAttribute can be shorten to Record
    [RecordAttribute("更新", "Matthew", "2008-1-20", Memo = "修改 ToString()方法")]
    [Record("更新", "Jimmy", "2008-1-18")]
    [Record("创建", "张子阳", "2008-1-15")]
    
    class DemoClass
    {
        [Record("Modify", "Suki", "2018-6-15")]
        public override string ToString()
        {
            return "this is a demo class";
        }
    }
}
