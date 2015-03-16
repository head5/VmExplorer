using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.B_Entity
{
    public class Location
    {
        private int _id;
        private string _location;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Parameterized Construction to instantiate Location object with details
        /// </summary>
        /// <param name="id">location id</param>
        /// <param name="locationName">location</param>
        public Location(int id, string locationName)
        {
            _id = id;
            _location = locationName;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string LocationName
        {
            get { return _location; }
            set { _location = value; }
        }
    }

    public class VMRequestStatus
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public VMRequestStatus()
        {
        }

        /// <summary>
        /// Parameterized Constructor accepting
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="status">Status</param>
        public VMRequestStatus(int id, string status)
        {
            _statusid = id;
            _status = status;
        }

        /// <summary>
        /// Private Data Members
        /// </summary>
        private int _statusid;
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int StatusID
        {
            get { return _statusid; }
            set { _statusid = value; }
        }
    }

    public class InstanceSize
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public InstanceSize()
        {
        }

        /// <summary>
        /// Parameterize Constructor to accept
        /// VM Instance Size, Core Count and Memory
        /// </summary>
        /// <param name="name">VM Instance Size</param>
        /// <param name="core">Core Count</param>
        /// <param name="memory">Memory</param>
        /// <param name="active">Is Active</param>
        public InstanceSize(int id, string name, string memory, string core, bool active)
        {
            _id = id;
            _name = name;
            _memory = memory;
            _core = core;
            _isactive = active;
        }

        /// <summary>
        /// Private Members
        /// </summary>
        private int _id;
        private string _name;
        private bool _isactive;
        private string _memory;
        private string _core;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Memory
        {
            get { return _memory; }
            set { _memory = value; }
        }

        public string Core
        {
            get { return _core; }
            set { _core = value; }
        }

        public bool IsActive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }

        /// <summary>
        /// Overriding ToString()
        /// </summary>
        /// <returns>Instance Size Type Core/Memory</returns>
        public override string ToString()
        {
            return string.Format("{0}\t({1} / {2})", _name, _core, _memory);
        }
    }

    public class RequestStatus
    {
        private int _requestid;
        private int _requeststatusid;
        private int _updatedbymid;
        private DateTime _updatedat;

        public RequestStatus()
        {
        }

        public int RequestID
        {
            get { return _requestid; }
            set { _requestid = value; }
        }

        public int RequestStatusID
        {
            get { return _requeststatusid; }
            set { _requeststatusid = value; }
        }

        public int UpdatedByMID
        {
            get { return _updatedbymid; }
            set { _updatedbymid = value; }
        }

        public DateTime UpdatedAt
        {
            get { return _updatedat; }
            set { _updatedat = value; }
        }
    }
}
