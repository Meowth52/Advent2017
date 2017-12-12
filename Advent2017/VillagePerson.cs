using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class VillagePerson
    {
        int ID;
        List<VillagePerson> Connections = new List<VillagePerson>();
        public VillagePerson(int id, Dictionary<int, string> villageConnections, List<int> visitedPeople)
        {
            ID = id;
            int TryParseInt = 0;
            string ConnectionString = villageConnections[ID].Replace(", ", ",");
            string[] ConnectionStrings = ConnectionString.Split(',');
            visitedPeople.Add(ID);
            foreach (string c in ConnectionStrings)
            {
                Int32.TryParse(c, out TryParseInt);
                if (!visitedPeople.Contains(TryParseInt))
                {
                    Connections.Add(new VillagePerson(TryParseInt, villageConnections, visitedPeople));
                }
            }
        }
        public int CountConnections()
        {
            int ConnectionCounter = 0;
            foreach (VillagePerson i in Connections)
            {
                    ConnectionCounter += i.CountConnections();
                    ConnectionCounter++;  
            }
            return ConnectionCounter;
        }
        public int getID()
        {
            return ID;
        }
        public List<int> getVisitedPeople(List<int> visitedPeople)
        {
            visitedPeople.Add(ID);
            foreach(VillagePerson v in Connections)
            {
                v.getVisitedPeople(visitedPeople);
            }
            return visitedPeople;
        }
    }
}
