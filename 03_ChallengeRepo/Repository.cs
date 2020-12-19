using System;
using System.Collections.Generic;
using System.Text;

namespace _03_ChallengeRepo
{
    public class Repository
    {
        private Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>(); // New up dictonary

        public Dictionary<int, List<string>> GetDictonary() //Get List
        {
            return _doorAccess;
        }

        public void AddBadge(BadgeNum badge) //Create a dictionary of badges
        {
            _doorAccess.Add(badge.BadgeID, badge.DoorAccess);
        }

        public void GiveAccess(int badgeid, string doorAccess) // Adds a door to a badge
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Add(doorAccess);
        }

        public void RemoveAccess(int badgeid, string doorAccess) // Remove a door from a badge
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Remove(doorAccess);
        }
    }
}
