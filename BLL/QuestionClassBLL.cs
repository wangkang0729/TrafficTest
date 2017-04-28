using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuestionClassBLL
    {
        private QuestionClassDAL questionClassDAL;
        public string exceptionStr;

        public QuestionClassBLL()
        {
            this.questionClassDAL = new QuestionClassDAL();
            exceptionStr = questionClassDAL.exceptionMessage;
        }

        public List<QuestionClass> loadAllClasses()
        {
            return questionClassDAL.loadAllClasses();
        }

        public void addClass(string className)
        {
            questionClassDAL.addClass(className);
        }

        public void deleteClass(string classID)
        {
            questionClassDAL.deleteClass(classID);
        }

        public bool checkIsReference(string classID)
        {
            return questionClassDAL.checkIsReference(classID);
        }

    }
}
