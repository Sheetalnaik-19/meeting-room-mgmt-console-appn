// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

class Room
{
    public string Name;
    public string Type;
    public int Capacity;
    public string IsAvailable;
    public string[] Participants;

    public Room(string name, string type, int capacity)
    {
        Name = name;
        Type = type;
        Capacity = capacity;
        IsAvailable = "Yes";
        Participants = new string[capacity];
    }
}

class Program
{
    static Room[] rooms = new Room[15];
    static int roomCount = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMeeting Room Manager");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. Show Rooms");
            Console.WriteLine("3. Room Details");
            Console.WriteLine("4. Toggle Availability");
            Console.WriteLine("5. Remove Room");
            Console.WriteLine("6. Find Room");
            Console.WriteLine("7. Add Participant");
            Console.WriteLine("8. Show Participants");
            Console.WriteLine("9. Exit");
            Console.Write("Enter choice: ");
            
            int choice = int.Parse(Console.ReadLine());
            if (choice == 9) break;
            
            if (choice == 1) AddRoom();
            else if (choice == 2) ShowRooms();
            else if (choice == 3) RoomDetails();
            else if (choice == 4) ToggleAvailability();
            else if (choice == 5) RemoveRoom();
            else if (choice == 6) FindRoom();
            else if (choice == 7) AddParticipant();
            else if (choice == 8) ShowParticipants();
            else Console.WriteLine("Invalid option.");
        }
    }

    static void AddRoom()
    {
        if (roomCount >= rooms.Length) { Console.WriteLine("No space for new rooms."); return; }

        Console.Write("Room Name: ");
        string name = Console.ReadLine();
        Console.Write("Room Type(meeting/training): ");
        string type = Console.ReadLine();
        Console.Write("Capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        rooms[roomCount++] = new Room(name, type, capacity);
        Console.WriteLine("Room added.");
    }

    static void ShowRooms()
    {
        for (int i = 0; i < roomCount; i++)
            Console.WriteLine($"{i + 1}. {rooms[i].Name} ({rooms[i].Type}) - {rooms[i].Capacity} seats - Available: {rooms[i].IsAvailable}");
    }

    static void RoomDetails()
    {
        Console.Write("Room Number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < roomCount)
            Console.WriteLine($"{rooms[index].Name} - {rooms[index].Type} - {rooms[index].Capacity} seats - Available: {rooms[index].IsAvailable}");
        else
            Console.WriteLine("Invalid room.");
    }

    static void ToggleAvailability()
    {
        Console.Write("Room Number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < roomCount)
        {
            rooms[index].IsAvailable = (rooms[index].IsAvailable == "Yes") ? "No" : "Yes";
            Console.WriteLine("Availability updated.");
        }
        else
            Console.WriteLine("Invalid room.");
    }

    static void RemoveRoom()
    {
        Console.Write("Room Number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < roomCount)
        {
            for (int i = index; i < roomCount - 1; i++)
                rooms[i] = rooms[i + 1];
            roomCount--;
            Console.WriteLine("Room removed.");
        }
        else
            Console.WriteLine("Invalid room.");
    }

    static void FindRoom()
    {
        Console.Write("Minimum Capacity: ");
        int minCapacity = int.Parse(Console.ReadLine());

        for (int i = 0; i < roomCount; i++)
            if (rooms[i].Capacity >= minCapacity && rooms[i].IsAvailable == "Yes")
                Console.WriteLine($"{rooms[i].Name} - {rooms[i].Capacity} seats - Available: {rooms[i].IsAvailable}");
    }

    static void AddParticipant()
    {
        Console.Write("Room Number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= roomCount) { Console.WriteLine("Invalid room."); return; }
        
        Console.Write("Participant Name: ");
        string participant = Console.ReadLine();
        
        for (int i = 0; i < rooms[index].Capacity; i++)
        {
            if (rooms[index].Participants[i] == null)
            {
                rooms[index].Participants[i] = participant;
                Console.WriteLine("Participant added.");
                return;
            }
        }
        Console.WriteLine("Room is full.");
    }

    static void ShowParticipants()
    {
        Console.Write("Room Number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= roomCount) { Console.WriteLine("Invalid room."); return; }

        Console.WriteLine("Participants:");
        for (int i = 0; i < rooms[index].Capacity; i++)
            if (!string.IsNullOrEmpty(rooms[index].Participants[i]))
                Console.WriteLine(rooms[index].Participants[i]);
    }
}
