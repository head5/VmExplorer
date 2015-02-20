using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRole.B_Entity
{
    public class VMInstanceSize
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public VMInstanceSize()
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
        public VMInstanceSize(int id, string name, string memory, string core, bool active)
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
}
