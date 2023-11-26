using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul9
{
    public class DVD : Storage
    {
        public enum DVDType { SingleSided = 4_700, DoubleSided = 9_000 }
        private decimal speedReadWrite;
        private DVDType type;
        private decimal usedMemory = 0;

        public decimal SpeedReadWrite { get; internal set; }

        public DVD(string name, string model, decimal speedReadWrite, DVDType type)
            : base(name, model)
        {
            this.speedReadWrite = speedReadWrite;
            this.type = type;
        }

        public override decimal GetMemoryCapacity() => (decimal)type;

        public override void CopyData(decimal dataSize)
        {
            // Реализация метода копирования данных
            if (dataSize + usedMemory <= (decimal)type)
            {
                usedMemory += dataSize;
            }
            else
            {
                throw new Exception("Недостаточно места на DVD-носителе");
            }
        }

        public override decimal GetFreeMemory() => (decimal)type - usedMemory;

        public override string GetInfo()
        {
            return $"DVD: {Name}, {Model}, Type: {type}, Speed: {speedReadWrite}x";
        }
    }

}
