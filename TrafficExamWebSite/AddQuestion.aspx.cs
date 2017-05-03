using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class AddQuestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void okbtn_Click(object sender, EventArgs e)
    {
        if (imgFileUpload.HasFile)
        {
            String filename = imgFileUpload.FileName;
            imgFileUpload.SaveAs(Server.MapPath("img\\" + filename));
        }

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml("<?xml version='1.0' encoding='gb2312'?>" +
        "<bookstore>" +
        "<book genre='fantasy' ISBN='2-3631-4'>" +
        "<title>Oberon's Legacy</title>" +
        "<author>Corets, Eva</author>" +
        "<price>5.95</price>" +
        "</book>" +
        "</bookstore>");
        xmldoc.Save(Server.MapPath("question\\"+"bookstore2.xml"));
    }
}