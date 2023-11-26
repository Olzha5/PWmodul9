using modul9;
using System;
using System.Collections.Generic;

class BackupApplication
{
    static void Main(string[] args)
    {
        List<Storage> storages = new List<Storage>
        {
            new Flash("Kingston", "DataTraveler", 32, 100),
            new DVD("Sony", "DVR", 1.32m, DVD.DVDType.SingleSided),
            new HDD("Seagate", "Expansion", 500, 2, 60)
        };

        // Общий объем данных для переноса (в Гб)
        decimal totalDataToCopy = 565;

        // Размер файла (в Гб)
        decimal fileSize = 780m / 1024;

        Console.WriteLine("Общий объем памяти всех устройств:");
        CalculateTotalMemory(storages);

        Console.WriteLine("\nРасчет необходимого времени для копирования:");
        CalculateCopyTime(storages, fileSize);

        Console.WriteLine("\nРасчет необходимого количества носителей:");
        CalculateRequiredStorageDevices(storages, totalDataToCopy, fileSize);
    }

    static void CalculateTotalMemory(List<Storage> storages)
    {
        decimal totalMemory = 0;
        foreach (var storage in storages)
        {
            totalMemory += storage.GetMemoryCapacity();
            Console.WriteLine($"{storage.Name} {storage.Model}: {storage.GetMemoryCapacity()} Гб");
        }
        Console.WriteLine($"Общий объем: {totalMemory} Гб");
    }

    static void CalculateCopyTime(List<Storage> storages, decimal fileSize)
    {
        foreach (var storage in storages)
        {
            decimal time = fileSize / GetSpeed(storage);
            Console.WriteLine($"{storage.Name} {storage.Model}: {time} секунд(а) на файл размером {fileSize} Гб");
        }
    }

    static decimal GetSpeed(Storage storage)
    {
        switch (storage)
        {
            case Flash flash:
                return flash.SpeedUSB3;
            case DVD dvd:
                return dvd.SpeedReadWrite;
            case HDD hdd:
                return hdd.SpeedUSB2;
            default:
                return 0;
        }
    }

    static void CalculateRequiredStorageDevices(List<Storage> storages, decimal totalData, decimal fileSize)
    {
        foreach (var storage in storages)
        {
            decimal totalFiles = totalData / fileSize;
            decimal filesPerDevice = storage.GetMemoryCapacity() / fileSize;
            int devicesNeeded = (int)Math.Ceiling(totalFiles / filesPerDevice);
            Console.WriteLine($"{storage.Name} {storage.Model}: Требуется устройств: {devicesNeeded}");
        }
    }
}
