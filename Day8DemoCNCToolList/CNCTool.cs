//CNCTools.cs
//Programmer: Rob Garner (rgarner7@cnm.edu)
//Date: 4 Feb 2021
//Purpose: Store information about CNC tools

using System;
using System.Collections.Generic;
using System.Text;

namespace Day8DemoCNCToolList
{
    public class CNCTool
    {
        //TODO: Hey rob is this how we chain constructors? JS
        public CNCTool():this(-1, "New Tool created on " + DateTime.Now.ToString("s"),
            "Flat endmill",3.0f,.25f,1.5f)
        {
        }

        /// <summary>
        /// Create a CNC tool setting some common parameters.
        /// </summary>
        /// <param name="id">Unique id for the tool</param>
        /// <param name="name">Name for the tool</param>
        /// <param name="type">Type example "Flat" or "Round"</param>
        /// <param name="length">Total length of the tool</param>
        /// <param name="diameter">Diameter of cutting part of tool</param>
        /// <param name="lengthCuttingEdge">Length of just the cutting edge</param>
        public CNCTool(int id, string name, string type, float length,
            float diameter, float lengthCuttingEdge):this(id,name,type,length,diameter,
                lengthCuttingEdge, 2000.0f,3.0f,4)
        {
        }

        public CNCTool(int id, string name, string type, float length,
            float diameter, float lengthCuttingEdge, float rpm, 
            float feedRate, int numberOfFlutes)
        {
            Id = id;
            Name = name;
            Type = type;
            Length = length;
            Diameter = diameter;
            LengthCuttingEdge = lengthCuttingEdge;
            this.rpm = rpm;
            this.feedRate = feedRate;
            this.numberOfFlutes = numberOfFlutes;
            CalcChipLoad();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Length { get; set; }
        public float Diameter { get; set; }
        public float LengthCuttingEdge { get; set; }

        private float rpm;
        public float RPM
        {
            get { return rpm; }
            set { rpm = value; CalcChipLoad(); }
        }

        private float feedRate;
        public float FeedRate
        {
            get { return feedRate; }
            set { feedRate = value; CalcChipLoad(); }
        }

        private int numberOfFlutes;
        public int NumberOfFlutes
        {
            get { return numberOfFlutes; }
            set { numberOfFlutes = value; CalcChipLoad(); }
        }

        public float ChipLoad { get; private set; }

        //public float ChipLoad
        //{
        //    get { return FeedRate / (rpm * numberOfFlutes); }
        //}


        private void CalcChipLoad()
        {
            ChipLoad = FeedRate/(rpm* numberOfFlutes);
        }

        public override string ToString()
        {
            string str = Name;
            str += " " + Type;
            str += " " + Diameter +" in diameter";
            str += " " + numberOfFlutes + " flutes";
            return str;
        }

    }
}
