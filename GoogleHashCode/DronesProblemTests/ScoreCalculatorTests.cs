﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DronesProblem;
using DronesProblem.Commands;
using DronesProblemTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DronesProblemTests
{
	[TestClass]
	public class ScoreCalculatorTests
	{
		[TestMethod]
		public void ReadOutputFileTest()
		{
			var calc = new DronesScoreCalculator();
			var outputData = new StringReader("11\n" +
			                                  "0 L 0 0 1\n" +
			                                  "0 L 0 1 1\n" +
			                                  "0 D 0 0 1\n" +
			                                  "0 L 1 2 1\n" +
			                                  "0 D 0 2 1\n" +
			                                  "1 L 1 2 1\n" +
			                                  "1 D 2 2 1\n" +
			                                  "1 L 0 0 1\n" +
			                                  "1 D 1 0 1\n" +
			                                  "1 W 3\n" +
			                                  "1 U 1 1 1");

			var parser = new DronesParser();
			var input = parser.ParseFromData(Resources.Example);

			var output = calc.GetResultFromReader(input, outputData);

			Assert.AreEqual(11, output.Commands.Count);

			Assert.AreEqual(5, output.Commands.OfType<LoadCommand>().Count());
			Assert.AreEqual(4, output.Commands.OfType<DeliverCommand>().Count());
			Assert.AreEqual(1, output.Commands.OfType<WaitCommand>().Count());
			Assert.AreEqual(1, output.Commands.OfType<UnloadCommand>().Count());

			Assert.AreEqual(5, output.Commands.Count(c => c.Drone.ID == 0));
			Assert.AreEqual(6, output.Commands.Count(c => c.Drone.ID == 1));

			var loadCommand = output.Commands[5] as LoadCommand;
			Assert.AreEqual(1u, loadCommand.Drone.ID);
			Assert.AreEqual(1, loadCommand.Warehouse.ID);
			Assert.AreEqual(2, loadCommand.Product.ID);
			Assert.AreEqual(1, loadCommand.ProductCount);

			var deliverCommand = output.Commands[6] as DeliverCommand;
			Assert.AreEqual(1u, deliverCommand.Drone.ID);
			Assert.AreEqual(2, deliverCommand.Order.ID);
			Assert.AreEqual(2, deliverCommand.Product.ID);
			Assert.AreEqual(1, deliverCommand.ProductCount);

			var waitCommand = output.Commands[9] as WaitCommand;
			Assert.AreEqual(1u, waitCommand.Drone.ID);
			Assert.AreEqual(3, waitCommand.TurnCount);

			var unloadCommand = output.Commands[10] as UnloadCommand;
			Assert.AreEqual(1u, unloadCommand.Drone.ID);
			Assert.AreEqual(1, unloadCommand.Warehouse.ID);
			Assert.AreEqual(1, unloadCommand.Product.ID);
			Assert.AreEqual(1, unloadCommand.ProductCount);
		}
	}
}
