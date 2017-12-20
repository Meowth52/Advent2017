using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2017
{
    class Particle
    {
        string ID;
        int px;
        int py;
        int pz;
        int vx;
        int vy;
        int vz;
        int ax;
        int ay;
        int az;
        public Particle(string input, int id)
        {
            ID = id.ToString();
            Regex theRegex = new Regex(@"-?\d+");
            MatchCollection theMatch = theRegex.Matches(input);
            Int32.TryParse(theMatch[0].Value, out px);
            Int32.TryParse(theMatch[1].Value, out py);
            Int32.TryParse(theMatch[2].Value, out pz);
            Int32.TryParse(theMatch[3].Value, out vx);
            Int32.TryParse(theMatch[4].Value, out vy);
            Int32.TryParse(theMatch[5].Value, out vz);
            Int32.TryParse(theMatch[6].Value, out ax);
            Int32.TryParse(theMatch[7].Value, out ay);
            Int32.TryParse(theMatch[8].Value, out az);
        }
        public long AccelerationSum()
        {
            return Math.Abs(ax) + Math.Abs(ay) + Math.Abs(az);
        }
        public string GetID()
        {
            return ID;
        }
        public void UpdatePosition()
        {
            vx += ax;
            vy += ay;
            vz += az;
            px += vx;
            py += vy;
            pz += vz;
        }
        public string GetPositionString()
        {
            return px.ToString()+","+py.ToString()+","+pz.ToString();
        }
    }
}
