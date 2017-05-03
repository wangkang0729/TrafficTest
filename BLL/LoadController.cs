using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoadController
    {
        private QuestionClassBLL questionClassBLL;

        public LoadController()
        {
            this.questionClassBLL = new QuestionClassBLL();
        }

        public Object load(string what)
        {
            if (what.Equals("class"))
            {
                return questionClassBLL.loadAllClasses();
            }
            else
            {
                return null;
            }
        }
    }
}
