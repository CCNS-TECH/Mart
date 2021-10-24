using System.Collections.Generic;
using System.Linq;

namespace resm_app.ViewModels
{
    public class DataTableViewModel
    {
        public int DT_RowId { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string position { get; set; }
        public string office { get; set; }
        public string start_date { get; set; }
        public string salary { get; set; }
    }
    public static class DataViewModel{
        public static List<DataTableViewModel> GetDataTableViewModels()
        {
            var list = new List<DataTableViewModel>
            {
             new DataTableViewModel   {
              DT_RowId = 1,
              first_name= "Airi",
              last_name= "Satou",
              position= "Accountant",
              office= "Tokyo",
              start_date= "28th Nov 08",
              salary= "$162,700"
            },
             new DataTableViewModel  {
                  DT_RowId= 2,
                  first_name= "Angelica",
                  last_name= "Ramos",
                  position= "Chief Executive Officer (CEO)",
                  office= "London",
                  start_date= "9th Oct 09",
                  salary= "$1,200,000"
                },
             new DataTableViewModel {
                  DT_RowId= 3,
                  first_name= "Ashton",
                  last_name= "Cox",
                  position= "Junior Technical Author",
                  office= "San Francisco",
                  start_date= "12th Jan 09",
                  salary= "$86,000"
                },
             new DataTableViewModel {
                  DT_RowId= 4,
                  first_name= "Bradley",
                  last_name= "Greer",
                  position= "Software Engineer",
                  office= "London",
                  start_date= "13th Oct 12",
                  salary= "$132,000"
                },
             new DataTableViewModel {
                  DT_RowId= 5,
                  first_name= "Brenden",
                  last_name= "Wagner",
                  position= "Software Engineer",
                  office= "San Francisco",
                  start_date= "7th Jun 11",
                  salary= "$206,850"
                },
             new DataTableViewModel {
                  DT_RowId= 6,
                  first_name= "Brielle",
                  last_name= "Williamson",
                  position= "Integration Specialist",
                  office= "New York",
                  start_date= "2nd Dec 12",
                  salary= "$372,000"
                },
             new DataTableViewModel {
                  DT_RowId= 7,
                  first_name= "Bruno",
                  last_name= "Nash",
                  position= "Software Engineer",
                  office= "London",
                  start_date= "3rd May 11",
                  salary= "$163,500"
                },
             new DataTableViewModel {
                  DT_RowId= 8,
                  first_name= "Caesar",
                  last_name= "Vance",
                  position= "Pre-Sales Support",
                  office= "New York",
                  start_date= "12th Dec 11",
                  salary= "$106,450"
                },
             new DataTableViewModel {
                  DT_RowId= 9,
                  first_name= "Cara",
                  last_name= "Stevens",
                  position= "Sales Assistant",
                  office= "New York",
                  start_date= "6th Dec 11",
                  salary= "$145,600"
                },
             new DataTableViewModel {
                  DT_RowId= 10,
                  first_name= "Cedric",
                  last_name= "Kelly",
                  position= "Senior Javascript Developer",
                  office= "Edinburgh",
                  start_date= "29th Mar 12",
                  salary= "$433,060"
                }
            }.ToList();

            return list;
        }
    }
}