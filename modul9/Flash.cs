using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul9
{
    public class Flash : Storage
    {
        private decimal memoryCapacity;
        private decimal speedUSB3;
        private decimal usedMemory = 0;

        public decimal SpeedUSB3 { get; internal set; }

        public Flash(string name, string model, decimal memoryCapacity, decimal speedUSB3)
            : base(name, model)
        {
            this.memoryCapacity = memoryCapacity;
            this.speedUSB3 = speedUSB3;
        }

        public override decimal GetMemoryCapacity() => memoryCapacity;

        public override void CopyData(decimal dataSize)
        {
            // Реализация метода копирования данных
            // Упрощенно: проверяем, достаточно ли места для копирования
            if (dataSize + usedMemory <= memoryCapacity)
            {
                usedMemory += dataSize;
            }
            else
            {
                throw new Exception("Недостаточно места на Flash-носителе");
            }
        }

        public override decimal GetFreeMemory() => memoryCapacity - usedMemory;

        public override string GetInfo()
        {
            return $"Flash: {Name}, {Model}, Capacity: {memoryCapacity} GB, USB 3.0 Speed: {speedUSB3} MB/s";
        }
    }

}
