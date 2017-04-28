using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuestionClassManagement : System.Web.UI.Page
{
    private static QuestionClassBLL questionClassBLL;

    protected void Page_Load(object sender, EventArgs e)
    {
        questionClassBLL = new QuestionClassBLL();
        initData();
    }

    private void initData()
    {
        List<Model.QuestionClass> claes = questionClassBLL.loadAllClasses();
        this.classes.DataSource = claes;
        this.classes.DataBind();
        //this.exLabel.Text = questionClassBLL.exceptionStr;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string className = this.classNameTextBox.Text;
        questionClassBLL.addClass(className);
        initData();
    }

    protected void linkbtnDelete_Click(object sender, EventArgs e)
    {
        string classID = (((LinkButton)sender).CommandArgument.ToString()).ToString();

        if (classID != "")
        {
            if (!questionClassBLL.checkIsReference(classID))
            {
                questionClassBLL.deleteClass(classID);
            }
            
        }
        initData();
    }
}