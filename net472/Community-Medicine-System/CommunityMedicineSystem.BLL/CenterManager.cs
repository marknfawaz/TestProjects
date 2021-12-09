using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.BLL
{
    public class CenterManager
    {
        CenterDBGateway aCenterDbGateway = new CenterDBGateway();

        public List<Center> GetSelectedCenters(int thanaId)
        {
            return aCenterDbGateway.GetSelectedCenters(thanaId);
        }
        public Center GetCenter(int id)
        {
            return aCenterDbGateway.GetCenter(id);
        }
        
        public List<ViewMedicineStockInCenter> GetMedicineStockInCenters(int centerId)
        {
            return aCenterDbGateway.GetMedicineStockInCenters(centerId);
        }
        public Center CheckCodePassword(Center aCenter)
        {
            return aCenterDbGateway.CheckCodePassword(aCenter);
        }


        public int Save(Center aCenter)
        {
            if (aCenterDbGateway.UniqueChecker(aCenter) == null)
            {
                int save = aCenterDbGateway.Save(aCenter);
                if (save == 1)
                {
                    aCenter.Id = Convert.ToInt16(aCenterDbGateway.Find(aCenter.Name));
                    if (aCenter.Id > 0)
                    {
                        aCenter.Code = CreateRandomCode(6);
                        aCenter.Password = CreateRandomPassword(8);
                        aCenterDbGateway.SaveCodeAndPassword(aCenter);
                        return aCenter.Id;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public List<Center> GetAllCenters()
        {
            return aCenterDbGateway.GetAllCenters();
        }

        public string CreateRandomPassword(int passwordLength)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[passwordLength];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(passwordLength);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        public string CreateRandomCode(int codeLength)
        {
            char[] chars = new char[52];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[codeLength];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(codeLength);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public void SaveCodeAndPassword(Center aCenter)
        {
            aCenterDbGateway.SaveCodeAndPassword(aCenter);
        }

        //public int FindCenter(string name)
        //{
        //    return aCenterDbGateway.Find(name);
        //}

        public Center DisplayNewCenter(int id)
        {
            return aCenterDbGateway.DisplayNewCenter(id);
        }
        public int FindCode(string code)
        {
            return aCenterDbGateway.FindCode(code);
        }

        public Center FindById(int centerId)
        {
            return aCenterDbGateway.FindById(centerId);
        }
    }
}
