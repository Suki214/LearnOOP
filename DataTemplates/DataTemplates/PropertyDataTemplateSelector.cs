using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataTemplates
{
   public class PropertyDataTemplateSelector:DataTemplateSelector
    {
        public DataTemplate DefaultDataTemplate { get; set; }
        public DataTemplate EnumDataTemplate { get; set; }
        public DataTemplate BooleanDataTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DependencyPropertyInfo dpi = item as DependencyPropertyInfo;
            if (dpi.PropertyType== typeof(bool))
            {
                return BooleanDataTemplate;
            } 

            if (dpi.PropertyType.IsEnum)
            {
                return EnumDataTemplate;
            }

            return DefaultDataTemplate;
            
        }
    }
}
