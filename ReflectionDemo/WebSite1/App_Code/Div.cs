using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Div
/// </summary>
public class Div:HtmlGenericControl
{
    public int ColorValue { get; set; }
    public Div(Color c) : base("div")
    {
        this.InnerHtml = String.Format("{0}<br />RGB({1},{2},{3})", c.Name, c.R, c.G, c.B);
        this.ColorValue = c.R * 256 * 256 + c.G * 256 + c.B;

        int total = c.R + c.G + c.B;
        if(total <= 255)
        {
            this.Style.Add("Color", "#eee");
        }
        this.Style.Add("Background", string.Format("rgb({0},{1},{2})", c.R, c.G, c.B));
    }
}