using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using System.Text;

namespace SportscardSystem.ConsoleClient.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommandParser parser;

        public CommandProcessor(ICommandParser parser)
        {
            Guard.WhenArgument(parser, "Parser");
            this.parser = parser;
        }

        public string ProcessCommand(string commandAsString)
        {
            Guard.WhenArgument(commandAsString, "command").IsNullOrWhiteSpace().Throw();

            var command = parser.ParseCommand(commandAsString);
            var parameters = parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);

            return executionResult;
        }

        public string CommandsHelp()
        {
            var helpSb = new StringBuilder();

            helpSb.AppendLine("Please enter one of the following commands: ");
            helpSb.AppendLine();
            helpSb.AppendLine("AddSport [SportName]");
            helpSb.AppendLine("AddSportshall [SportshallName]");
            helpSb.AppendLine("AddSportToSportshall [SportName] [SportshallName]");
            helpSb.AppendLine("AddCompany [CompanyName]");
            helpSb.AppendLine("AddClient [FirstName] [LastName] [Age]");
            helpSb.AppendLine("AddVisit [FirstName] [LastName] [CompanyName] [SportshallName] [SportName]");
            helpSb.AppendLine("AddSportscard [FirstName] [LastName] [CompanyName]");
            helpSb.AppendLine();
            helpSb.AppendLine("DeleteSport [SportName]");
            helpSb.AppendLine("DeleteSportshall [SportshallName]");
            helpSb.AppendLine("DeleteSportFromSportshall [SportName] [SportshallName]");
            helpSb.AppendLine("DeleteCompany [CompanyName]");
            helpSb.AppendLine("DeleteClient [FirstName] [LastName] [Age]");
            helpSb.AppendLine("DeleteVisit [VisitId]");
            helpSb.AppendLine("DeleteSportscard [FirstName] [LastName] [CompanyName]");
            helpSb.AppendLine();
            helpSb.AppendLine("GetMostPlayedSport");
            helpSb.AppendLine("GetMostVisitedSportshall");
            helpSb.AppendLine("GetMostActiveCompany");
            helpSb.AppendLine("GetMostActiveClient");
            helpSb.AppendLine();
            helpSb.AppendLine("GetVisitsBySport [SportName]");
            helpSb.AppendLine("GetVisitsBySportshall [SportshallName]");
            helpSb.AppendLine("GetVisitsByClient [FirstName] [LastName]");
            helpSb.AppendLine("GetVisitsByDate [yyyy-mm-dd]");
            helpSb.AppendLine();
            helpSb.AppendLine("GetSportshallVisitsFrom [SportshallName] [yyyy-mm-dd]");
            helpSb.AppendLine("GetSportshallVisitsTo [SportshallName] [yyyy-mm-dd]");
            helpSb.AppendLine("GetSportshallVisitsFromTo [SportshallName] [yyyy-mm-dd] [yyyy-mm-dd]");
            helpSb.AppendLine("GetSportVisitsFrom [SportName] [yyyy-mm-dd]");
            helpSb.AppendLine("GetSportVisitsTo [SportName] [yyyy-mm-dd]");
            helpSb.AppendLine("GetSportVisitsFromTo [SportName] [yyyy-mm-dd] [yyyy-mm-dd]");
            helpSb.AppendLine();
            helpSb.AppendLine("ListAllSports");
            helpSb.AppendLine("ListAllSportshalls");
            helpSb.AppendLine("ListAllCompanies");
            helpSb.AppendLine("ListAllClients");
            helpSb.AppendLine("ListAllVisits");
            helpSb.AppendLine("ListAllSportscards");
            helpSb.AppendLine();
            helpSb.AppendLine("ImportSportscardsFromFile");
            helpSb.AppendLine("ExportSportscardsTable");
            helpSb.AppendLine("ExportSportshallsTable");

            return helpSb.ToString();
        }
    }
}
