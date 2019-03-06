using System;

namespace SQLDB
{
    //TODO:3 connect to DB
    class ConnectToDB
    {
        //TODO:4 import data 
        public List<person> ImportPeople()
        {
            //load people
            using (fvsfdsdfEntities context = new fvsfdsdfEntities())
            {
                //return temp storage
                List<person> temp = new List<person>();
                var queryPeople = (from pe in context.people select pe);

                foreach (var p in queryPeople)
                {
                    //Console.WriteLine($"{p.ID}  {p.name}  {p.rank}  {p.unit01.name}"); 
                    temp.Add(p);
                }
                return temp;
            }
        }

        //TODO:5 export data
        //create temp sorage to hold data

        public void ExportToDB(List<person> outPut)
        {
            using (fvsfdsdfEntities server = new fvsfdsdfEntities())
            {
                foreach (var person in outPut)
                {
                    var queryPerson = (from p in server.people
                                       where p.ID == person.ID
                                       select p);

                    foreach (var perp in queryPerson)
                    {
                        perp.ID = person.ID;
                        perp.name = person.name;
                        perp.rank = person.rank;
                        perp.unit01 = person.unit01;
                        perp.unitID = person.unitID;
                    }
                }


            }
        }

    }


}

