using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Enums
{
    public static class PlayerPosition
    {
        public enum Position
        {
            Defender,
            Forward,
            Goalie,
            Midfield
        }

        public static Position GetPositionFromString(string value)
        {
            switch (value.ToLower())
            {
                case "defender":
                    return Position.Defender;
                case "forward":
                    return Position.Forward;
                case "goalie":
                    return Position.Goalie;
                case "midfield":
                    return Position.Midfield;
            }
            throw new Exception("Cannot unmarshal type Position");
        }
    }

}
