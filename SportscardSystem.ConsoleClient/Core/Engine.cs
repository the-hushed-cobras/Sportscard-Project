﻿using Autofac.Core.Registration;
using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Core.Contracts;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor processor;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandProcessor processor)
        {
            Guard.WhenArgument(reader, "Reader").IsNull().Throw();
            Guard.WhenArgument(writer, "Writer").IsNull().Throw();
            Guard.WhenArgument(processor, "Processor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.processor = processor;
        }


        public void Start()
        {
            writer.WriteLine(processor.CommandsHelp());

            while (true)
            {
                try
                {
                    string commandAsString = reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    var executionResult = this.processor.ProcessCommand(commandAsString);
                    writer.WriteLine(executionResult);
                }
                catch (ComponentNotRegisteredException)
                {
                    this.writer.WriteLine($"There is no such command implemented! Please contact Dev team to implement it :)");
                    writer.WriteLine(processor.CommandsHelp());
                }
                catch (Exception ex)
                {
                    var exMessageIndex = ex.Message.IndexOf(": ");
                    var exMessage = ex.Message.Substring(exMessageIndex + 2);

                    if (exMessageIndex == -1)
                    {
                        writer.WriteLine(ex.Message);
                    }
                    else
                    {
                        writer.WriteLine(exMessage);
                    }

                    writer.WriteLine(processor.CommandsHelp());
                }
            }
        }
    }
}
