using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsCodeBank
    {
        public enum enMode { AddNew=0,Update=1};
        private enMode _Mode = enMode.AddNew;
        public int CodeID { set; get; }
        public string CodeTitle { set; get; }
        public string MainCode { set; get; }
        public clsCodeBank()
        {
            this.CodeID = -1;
            this.CodeTitle = "";
            this.CodeTitle = "";
            _Mode = enMode.AddNew;
        }
        private clsCodeBank(int CodeID,string CodeTitle,string MainCode)
        {
            this.CodeID = CodeID;
            this.CodeTitle = CodeTitle;
            this.MainCode = MainCode;
            _Mode = enMode.Update;
        }
        private bool _AddNewCode()
        {
            this.CodeID = clsCodeBankData.AddNewCodeToBank(this.CodeTitle, this.MainCode);
            return this.CodeID != -1;
        }
        private bool _UpdateCode()
        {
            return clsCodeBankData.UpdateCodeInBank(this.CodeID, this.CodeTitle, this.MainCode);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCode())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateCode();
                default:
                    return false;
            }
        }
        public static bool DeleteCode(int CodeID)
        {
            return clsCodeBankData.DeleteCodeInBank(CodeID);
        }
        public static clsCodeBank Find(int CodeID)
        {
            string CodeTitle = "";
            string MainCode = "";
            if (clsCodeBankData.GetCodeInfoByID(CodeID, ref CodeTitle, ref MainCode))
                return new clsCodeBank(CodeID, CodeTitle, MainCode);
            else
                return null;
        }
        public static DataTable Search(string FilterValue)
        {
            return clsCodeBankData.SearchForCodes(FilterValue);
        }
        public static DataTable GetTopTenCodes()
        {
            return clsCodeBankData.GetTopTenCodes();
        }
    }
}
