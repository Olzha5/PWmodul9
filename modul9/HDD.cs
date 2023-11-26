using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul9
{
    public class HDD : Storage
    {
        private decimal partitionSize;
        private int partitionCount;
        private decimal speedUSB2;
        private decimal usedMemory = 0;

        public decimal SpeedUSB2 { get; internal set; }

        public HDD(string name, string model, decimal partitionSize, int partitionCount, decimal speedUSB2)
            : base(name, model)
        {
            this.partitionSize = partitionSize;
            this.partitionCount = partitionCount;
            this.speedUSB2 = speedUSB2;
        }

        public override decimal GetMemoryCapacity() => partitionSize * partitionCount;

        public override void CopyData(decimal dataSize)
        {
            // Реализация метода копирования данных
            if (dataSize + usedMemory <= GetMemoryCapacity())
            {
                usedMemory += dataSize;
            }
            else
            {
                throw new Exception("Недостаточно места на HDD-носителе");
            }
        }

        public override decimal GetFreeMemory() => GetMemoryCapacity() - usedMemory;

        public override string GetInfo()
        {
            return $"HDD: {Name}, {Model}, Partition Size: {partitionSize} GB, Count: {partitionCount}, USB 2.0 Speed: {speedUSB2} MB/s";
        }
    }

}
