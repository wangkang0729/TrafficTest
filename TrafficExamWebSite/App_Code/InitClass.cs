using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for InitClass
/// </summary>
public class InitClass
{
    private static LoadController loadController = new LoadController();

	public InitClass()
	{
		//
		// TODO: Add constructor logic here
		//
        //loadController = new LoadController();
       
	}

    public static void appInitialize()
    {
        //List<Model.QuestionClass> claes = (List<Model.QuestionClass>)loadController.load("class");
        //new Page().Application["class"] = claes;
    }  
}