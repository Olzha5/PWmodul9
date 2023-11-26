using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul9
{
    public abstract class Storage
    {
        private string name;
        private string model;

        protected Storage(string name, string model)
        {
            this.name = name;
            this.model = model;
        }

        public string Name => name;
        public string Model => model;

        public abstract decimal GetMemoryCapacity();
        public abstract void CopyData(decimal dataSize);
        public abstract decimal GetFreeMemory();
        public abstract string GetInfo();
    }

}
