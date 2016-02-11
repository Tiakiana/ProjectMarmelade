using System;
using System.Data;

namespace Domain
{
    internal interface IQualityTest
    {
        int getID();
        void setComment(string comment);
        void setResult(string results);
        void setDone(bool cHecked);
        void setApproved(bool done);
        string[] ToString2();
        DateTime getCheckedDate();
        string getQTA();
        string getER();
        string getEmployee();
        string getComment();
        string getResult();
        bool getDone();
        bool getApproved();
    }
}