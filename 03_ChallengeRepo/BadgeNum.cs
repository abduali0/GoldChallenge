using System;

namespace _03_ChallengeRepo
{
    {
    public class BadgeNum
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }

        public BadgeNum() { }

        public BadgeNum(int badgeid, List<string> doorAccess)
        {
            BadgeID = badgeid;
            DoorAccess = doorAccess;
        }
    }
}
