using Microsoft.VisualBasic.FileIO;
using PetShopApp.Core.ApplicationServices;
using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using PetShopApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplication
{

    public class Printer : IPrinter
    {
   

    #region Repository area
    private IPetService _petService;
        #endregion
        public Printer(IPetService petService)
        {
            _petService = petService;
            Datainitializer.InitData();
        }

    #region StartUI
    public void StartUI()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("|                   |");
            Console.WriteLine("|  Pet Shop Boys    |");
            Console.WriteLine("|                   |");
            Console.WriteLine("--------------------\n");

            string[] menuItems =
      {
            "Cheapest Pets",
            "Add a Pet",
            "Delete a Pet",
            "Edit a Pet",
            "List of all pets",
            "Search",
            "Close App"
        };

            int selection = ShowMenu(menuItems);
            while (selection != 7)
            {
                switch (selection)
                {
                    case 1:
                        ShowCheapesPets();
                        break;
                    case 2:
                        AddANewPet();
                        break;
                    case 3:
                        var idForDelete = PrintFindPetId();
                        _petService.DeletePet(idForDelete);
                        break;
                    case 4:
                        EditPet();
                        break;
                    case 5:
                        ReadAllPets();
                        break;
                    case 6:
                        SearchByType();
                        break;
                    default:
                        break;

                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();


            int ShowMenu(string[] menuItems)
            {
                Console.WriteLine("Select What you want to do:\n");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
                }
                int selection;
                while (!int.TryParse(Console.ReadLine(), out selection)
                    || selection < 1
                    || selection > 7)
                {
                    Console.WriteLine("Please select a number between 1-5");
                }

                return selection;
            }

            void AddANewPet()
            {
                var petName = AskQuestion("Petname: ");
                var petType = AskQuestion("What animal?: ");
                var color = AskQuestion("What color is it?: ");
                DateTime birthDay = DateTime.Parse(AskQuestion("B-day? "));
                var previousOwner = AskQuestion("Who owned it? :");
                var price = Double.Parse(AskQuestion("How Much?"));
                var pets = _petService.NewPet(petName,
                                              petType,
                                              birthDay,
                                              color,
                                              previousOwner,
                                              price);
                _petService.CreatePet(pets);
            }

            void EditPet()
            {
                var idForEdit = PrintFindPetId();
                var petToEdit = _petService.FindPetById(idForEdit);
                Console.WriteLine("Updating " + petToEdit.PetName + " " + petToEdit.PetType);
                var newPetName = AskQuestion("PetName: ");
                var newPetType = AskQuestion("PetType: ");
                var newColor = AskQuestion("Color: ");
                var newPreviousOwner = AskQuestion("Previous owner:");
                DateTime newBirthday = DateTime.Parse(AskQuestion("New Birthday?"));
                double newPrice = Double.Parse(AskQuestion("New Price?"));
                _petService.EditPet(new Pet()
                {
                    PetId = idForEdit,
                    PetName = newPetName,
                    PetType = newPetType,
                    Color = newColor,
                    PreviousOwner = newPreviousOwner,
                    BirthDay = newBirthday,
                    Price = newPrice
                });
            }

            int PrintFindPetId()
            {
                Console.WriteLine("Insert PetId: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Please insert a number");
                }
                return id;
            }

            string AskQuestion(string question)
            {
                Console.WriteLine(question);
                return Console.ReadLine();
            }
            void SearchByType()
            {
                Console.Clear();
                Console.WriteLine("Please type the type of pet you are searching for:");
                Console.WriteLine("");
                var searchString = Console.ReadLine().ToLower();

                if (_petService.FindPetsByType(searchString).Count <= 0)
                {
                    Console.WriteLine("No Type of that pet: " + searchString);

                }
                else
                {
                    foreach (var Pet in _petService.FindPetsByType(searchString))
                    {
                        Console.WriteLine(Pet);
                    }
                }
            }
            #endregion
        }

        void ReadAllPets()
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in _petService.GetAllPets())
            {
                Console.WriteLine($"Id: {pet.PetId} Name: {pet.PetName} Type: {pet.PetType} Color:  {pet.Color} " +
                          $"Previous Owner: {pet.PreviousOwner} Price: {pet.Price}");
            }
        }

            void ShowCheapesPets()
            {
                var list = _petService.Get3CheapestPets();
                foreach (var pet in list )
                {
                    Console.WriteLine("Pet Name: {0} Price: {1:N}", pet.PetName, pet.Price);
                }
            }
        }
    }





