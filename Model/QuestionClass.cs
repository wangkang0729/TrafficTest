using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QuestionClass
    {
        private int _classID;
        private string _className;
        private bool _isReferences;

        public int classID
        {
            set { _classID = value; }
            get { return _classID; }
        }

        public string className
        {
            set { _className = value; }
            get { return _className; }
        }

        public bool isReferences
        {
            set { _isReferences = value; }
            get { return _isReferences; }
        }
    }
}
