using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.B_Entity
{
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
}
