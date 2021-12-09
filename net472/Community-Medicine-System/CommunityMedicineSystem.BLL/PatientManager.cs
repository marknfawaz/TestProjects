using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using CommunityMedicineSystem.DAL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.BLL
{
    public class PatientManager
    {
        PatientDBGateway aPatientDbGateway = new PatientDBGateway();
        public Patient GetInfoFromWebService(string voterId)
        {
            Patient aPatient = new Patient();
            using (
                XmlReader reader =
                    XmlReader.Create(@"http://nerdcastlebd.com/web_service/voterdb/index.php/voters/voter/" +
                                     HttpUtility.UrlEncode(voterId)))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                           
                            case "name":
                                aPatient.Name = reader.ReadString();
                                break;

                            case "address":
                                aPatient.Address = reader.ReadString();
                                break;

                            case "date_of_birth":
                                DateTime birthDay = Convert.ToDateTime(reader.ReadString());
                                DateTime today = DateTime.Today;
                                int age = (today - birthDay).Days/365;
                                aPatient.Age = age;
                                break;
                        }
                    }
                }
                return aPatient;
            }
        }

        public void SaveService(Patient aPatient)
        {
            aPatientDbGateway.SaveService(aPatient);
        }

        public int GetServiceTakenId()
        {
            return aPatientDbGateway.GetServiceTakenId();
        }

        public int GetTotalNumberOfService(long voterId)
        {
            return aPatientDbGateway.GetTotalNumberOfService(voterId);
        }

        public DataTable GetData(long voterId)
        {
            return aPatientDbGateway.GetData(voterId);
        }

        public List<ViewPatientHistory> GetPatient(long voterId)
        {
            return aPatientDbGateway.GetPatient(voterId);
        }
    }
}
