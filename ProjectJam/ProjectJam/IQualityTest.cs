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
       
    }
}