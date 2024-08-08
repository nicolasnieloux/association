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
            
            Console.WriteLine("Souhaitez-vous Consulter la météo pour les 7 prochains jours 1 , ou Créer un événement 2 ? Veuillez saisir 1 ou 2.");
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
        
                Console.Write("Veuillez saisir le nombre de places disponibles : ");
                int availableSpots = Convert.ToInt32(Console.ReadLine());
        
                await eventService.CreateEvent(eventName, startDate, endDate, registeredPeopleCount, availableSpots, lieu);
                
                // Console.WriteLine($"Evénement {createdEvent.Name} créé avec succès. L'événement commencera le {createdEvent.StartDate} et se terminera le {createdEvent.EndDate}. " + 
                //                   $"Compte des personnes inscrites : {createdEvent.RegisteredPeopleCount}, places disponibles : {createdEvent.AvailableSpots}, lieu : {createdEvent.Location}.");
                //
                // await weatherDataService.DisplayWeatherData(lieu);
                
                Console.WriteLine("Voulez-vous voir tous les événements ? Entrez oui ou non.");
                choice = Console.ReadLine();

                if(choice.ToLower() == "oui")
                {
                    Console.WriteLine("Liste des événements :");
                    
                    var events = eventService.GetEvents();
                    foreach (var e in events)
                    {
                        Console.WriteLine($"Événement {e.Name}: commence le {e.StartDate}, se termine le {e.EndDate}, lieu : {e.Location}, " + 
                                          $"nombre de personnes inscrites : {e.RegisteredPeopleCount}, places disponibles : {e.AvailableSpots}");
                        
                        await weatherDataService.DisplayWeatherData(e.Location);

                    }
                }
            }
            else
            {
                Console.WriteLine("Choix invalide. Veuillez relancer le programme et entrez un choix valide.");
            }
        }
    }
}