using System;
using System.Threading.Tasks;
using association.Model;
using association.Service;

namespace associationConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            WeatherDataService weatherDataService = new WeatherDataService();
            EventService eventService = new EventService();
            
            Console.WriteLine("Souhaitez-vous 1) Consulter la météo pour les 7 prochains jours, ou 2) Créer un événement ? Veuillez saisir 1 ou 2.");
            string choice = Console.ReadLine();

            if(choice == "1")
            {
                Console.Write("Veuillez saisir le lieu : ");
                string lieu = Console.ReadLine();
                await weatherDataService.DisplayWeatherData(lieu);
            }
            else if(choice == "2")
            {
                Console.Write("Veuillez saisir le lieu : ");
                string lieu = Console.ReadLine();
                
                Console.Write("Veuillez saisir le nom de l'événement : ");
                string eventName = Console.ReadLine();

                Console.Write("Veuillez saisir la date de début de l'événement (format : yyyy-MM-dd) : ");
                string inputStartDate = Console.ReadLine();
                DateTime startDate = DateTime.ParseExact(inputStartDate, "yyyy-MM-dd", null);
        
                Console.Write("Veuillez saisir la date de fin de l'événement (format : yyyy-MM-dd) : ");
                string inputEndDate = Console.ReadLine();
                DateTime endDate = DateTime.ParseExact(inputEndDate, "yyyy-MM-dd", null);
        
                Console.Write("Veuillez saisir le nombre de personnes inscrites : ");
                int registeredPeopleCount = Convert.ToInt32(Console.ReadLine());
        
                Console.Write("Veuillez saisir le nombre de 1places disponibles : ");
                int availableSpots = Convert.ToInt32(Console.ReadLine());
        
                Event createdEvent = await eventService.CreateEvent(eventName, startDate, endDate, registeredPeopleCount, availableSpots, lieu);
                
                Console.WriteLine($"Evénement {createdEvent.Name} créé avec succès. L'événement commencera le {createdEvent.StartDate} et se terminera le {createdEvent.EndDate}. " + 
                                  $"Compte des personnes inscrites : {createdEvent.RegisteredPeopleCount}, places disponibles : {createdEvent.AvailableSpots}, et lieu : {createdEvent.Location}.");
                await weatherDataService.DisplayWeatherData(lieu);
            }
            else
            {
                Console.WriteLine("Choix invalide. Veuillez relancer le programme et entrez un choix valide.");
            }
        }
    }
}