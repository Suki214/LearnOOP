using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CommandParamtersDemo
{
    class WebImageController
    {
        private readonly DelegateCommand refreshDesignCommand;  // 缩略图的点击回调

        // [ImportingConstructor]
        public WebImageController()
        {
            refreshDesignCommand = new DelegateCommand(p => RefreshDesignCommand((Button)p));
        }

        private void RefreshDesignCommand(Button btn)
        {
            // 方法一：将DataContext打印字符串，截取出目标数据
            string dataContext = btn.DataContext.ToString();
            System.Console.WriteLine(dataContext);          // id = 000201 , icon = http://192.168.1.222/mjl/4-01.png , image = 2/造型/4-01.png , model = xml/qiang07.xml
                                                            // 截取字符串来获得目标数据。

            // 方法二：将DataContext强转为ItemSource对应的实体类类型
            GoodsJsonData data = (GoodsJsonData)btn.DataContext;
            // do what you want !
        }
    }

   
}
