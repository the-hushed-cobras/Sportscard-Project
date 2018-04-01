using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.FileImporters;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ImportJSON
{
    public class ImportSportscardsFromFileCommand : Command, ICommand
    {
        private readonly ISportscardService sportscardService;
        private readonly IJsonReader jsonReader;

        public ImportSportscardsFromFileCommand(ISportscardFactory sportscardFactory, 
                                                IJsonReader jsonReader, 
                                                ISportscardService sportscardService) 
            : base(sportscardFactory)
        {
            this.jsonReader = jsonReader;
            this.sportscardService = sportscardService;
        }

        public string Execute(IList<string> parameters)
        {
            var sportscards = jsonReader.ImportSportscards();

            if (sportscards.Count() == 0)
            {
                return $"Sorry, there are no sportscards in the file.";
            }

            foreach (var sportscard in sportscards)
            {
                string clientFirstName;
                string clientLastName;
                int? clientAge;
                string companyName;

                if (sportscard.Client != null)
                {
                    clientFirstName = sportscard.Client.FirstName;
                    clientLastName = sportscard.Client.LastName;
                    clientAge = sportscard.Client.Age;
                    if (sportscard.Client.Company != null)
                    {
                        companyName = sportscard.Client.Company.Name;
                    }
                    else
                    {
                        throw new ArgumentNullException("Sportscard's company in JSON file");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Sportscard's client in JSON file");
                }

                this.sportscardService.AddSportscard(sportscard);

            }

            return $"Sportscards successfully imported";
        }
    }
}