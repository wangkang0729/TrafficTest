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
    private LoadController loadController;

    protected void Page_Load(object sender, EventArgs e)
    {
        loadController = new LoadController();
        questionClassBLL = new QuestionClassBLL();
        initData(false);
    }

    private void initData(bool reload)
    {
        //List<Model.QuestionClass> claes = questionClassBLL.loadAllClasses();
        //List<Model.QuestionClass> claes = (List<Model.QuestionClass>)loadController.load("class");
        //Application["class"] = (List<Model.QuestionClass>)loadController.load("class");
        if (reload)
        {
            updateApplicationClass();
        }
        this.classes.DataSource = (List<Model.QuestionClass>)Application["class"];
        this.classes.DataBind();
        //Application["class"] = 0;
        //this.exLabel.Text = questionClassBLL.exceptionStr;
    }

    private void updateApplicationClass()
    {
        Application["class"] = (List<Model.QuestionClass>)loadController.load("class");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string className = this.classNameTextBox.Text;
        questionClassBLL.addClass(className);
        initData(true);
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
        initData(true);
    }
}