using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Drawing;

public partial class ColorShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Div> list = new List<Div>();
        Type t = typeof(Color);

        PropertyInfo[] properties = t.GetProperties(BindingFlags.Static | BindingFlags.Public);
        Div div;
        foreach (PropertyInfo p in properties)
        {
            Color c = (Color)t.InvokeMember(p.Name, BindingFlags.GetProperty, null, null, null);
            div = new Div(c);
            list.Add(div);
        }
        list = list.OrderBy(x => x.ColorValue).ToList();
        foreach (Div item in list)
        {
            pnColors.Controls.Add(item);
        }
    }
}