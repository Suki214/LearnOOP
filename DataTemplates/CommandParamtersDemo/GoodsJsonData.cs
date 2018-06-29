using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParamtersDemo
{
    public class GoodsJsonData
    {
        public string id { get; set; } // 还可用于图片被点击调时，标记出是哪个缩略图被点击
        public string icon { get; set; } // 缩略图
        public string image { get; set; } // 大图
        public string model { get; set; } // 该商品对应的模型XML

        public override string ToString()
        {
            return "id = " + id + " , icon = " + icon + " , image = " + image + " , model = " + model;
        }
    }
}
