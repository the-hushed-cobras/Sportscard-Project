using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.FileImporters;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ImportJSON
{
    public class ImportSportscardsFromFileCommand : Command, ICommand           // WILL BE COMPLETELY REVISED
    {
        private readonly ICommand addSportscardCommand;
        private readonly JsonReader jsonReader;

        public ImportSportscardsFromFileCommand(ISportscardFactory sportscardFactory, JsonReader jsonReader, ISportscardService sportscardService, 
                                                IClientService clientService, IVisitService visitService) : base(sportscardFactory)
        {
            this.jsonReader = jsonReader;
            this.addSportscardCommand = new AddSportscardCommand(sportscardFactory, sportscardService, clientService, visitService);
        }

        public string Execute(IList<string> parameters)
        {
            var sportscards = jsonReader.ImportSportscards();

            if (sportscards.Count() == 0)
            {
                return $"Sorry, there are no companies in the file.";
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
                        throw new ArgumentNullException("Company in JSON file");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Company in JSON file");
                }

                this.addSportscardCommand.Execute(new List<string>()
                {
                    clientFirstName,
                    clientLastName,
                    companyName
                });

            }

            return $"Sportscards successfully imported";
        }
    }
}