using CommandParamtersDemo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandParamtersDemo
{
    class ViewModel
    {
        private ICommand refreshDesignCommand; // 向上传递这个Command：View-->ViewModel-->Controller
        public ICommand RefreshDesignCommand
        {
            get { return refreshDesignCommand; }
            set {  refreshDesignCommand=value; }
        }      

        private ObservableCollection<GoodsJsonData> dataList = null;
        public ObservableCollection<GoodsJsonData> DataList
        {
            get { return dataList; }
            set { dataList = value; }
        }

        
        public ViewModel()
        {
            dataList = new ObservableCollection<GoodsJsonData>();
            dataList.Add(goods1);
        }
        GoodsJsonData goods1 = new GoodsJsonData() { id = "1", icon = "https://www.vcg.com/creative/1151677840?utm_source=baidu&utm_medium=cpc&utm_campaign=%E9%80%9A%E7%94%A8%E8%AF%8D&utm_content=%E5%B9%BF%E6%B3%9B&utm_term=%E5%9B%BE%E7%89%87%E5%BA%93&sort=best_match&rand=", image = "d:", model = "s" };
    }
}

    
