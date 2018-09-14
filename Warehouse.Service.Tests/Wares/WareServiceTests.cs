using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warehouse.Model.Wares;
using Warehouse.Service.Tests;
using Warehouse.Service.Tests.MemoryStorage;

namespace Warehouse.Service.Tests.Wares
{
	[TestClass()]
	public class WareServiceTests
	{
		/*
		Initial values:
		(1, "Tuna", WareType.SeaFood, DateTime.Today.AddDays(-1))
		(2, "Tuna", WareType.SeaFood, DateTime.Today.AddDays(2))
		(3, "Mussels", WareType.SeaFood, DateTime.Today));
		(4, "Salmon", WareType.SeaFood, DateTime.Today.AddDays(2))
		(5, "Lamb", WareType.Meat, DateTime.Today.AddDays(-7))
		(6, "Beef", WareType.Meat, DateTime.Today.AddDays(14))
		(7, "Potatoes", WareType.Vegetables, DateTime.Today.AddMonths(6))
 	  */

		[TestMethod()]
		public void WareServiceTest()
		{
			//Prepare
			Test.Config();

			//Action

			//Confirm
			Assert.IsNotNull(Test.ServiceLocator.WareService);
		}

		[TestMethod()]
		public void GetWaresTest()
		{
			//Prepare
			Test.Config();

			//Action

			//Confirm
			Assert.IsNotNull(Test.ServiceLocator.WareService.GetWares());
			Assert.IsTrue(Test.ServiceLocator.WareService.GetWares().Any());
		}

		[TestMethod()]
		public void GetWareTest()
		{
			//Prepare
			Test.Config();

			//Action
			var value = Test.ServiceLocator.WareService.GetWare(1);

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(1, value.Id);
			Assert.AreEqual("Tuna", value.Name);
			Assert.AreEqual(WareType.SeaFood, value.Type);
			Assert.AreEqual(DateTime.Today.AddDays(-1), value.ExpirationDate);
		}

		[TestMethod()]
		public void StoreTest()
		{
			//Prepare
			Test.Config();

			//Action
			var valueBefore = new Ware("Carrot", WareType.Vegetables, DateTime.Today.AddMonths(6));
			var countBefore = Test.ServiceLocator.WareService.GetWares().Count();
			Test.ServiceLocator.WareService.Store(valueBefore);
			var valueAfter = Test.ServiceLocator.WareService.GetWares().LastOrDefault();
			var countAfter = Test.ServiceLocator.WareService.GetWares().Count();

			//Confirm
			Assert.IsNotNull(valueAfter);
			Assert.AreEqual("Carrot", valueAfter.Name);
			Assert.AreEqual(WareType.Vegetables, valueAfter.Type);
			Assert.AreEqual(DateTime.Today.AddMonths(6), valueAfter.ExpirationDate);
			Assert.AreEqual(countBefore, countAfter - 1);
		}

		[TestMethod()]
		public void TakeTest()
		{
			//Prepare
			Test.Config();

			//Action
			var countBefore = Test.ServiceLocator.WareService.GetWares().Count();
			var value = Test.ServiceLocator.WareService.Take(5);
			var countAfter = Test.ServiceLocator.WareService.GetWares().Count();

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(5, value.Id);
			Assert.AreEqual("Lamb", value.Name);
			Assert.AreEqual(WareType.Meat, value.Type);
			Assert.AreEqual(DateTime.Today.AddDays(-7), value.ExpirationDate);
			Assert.AreEqual(countBefore, countAfter + 1);
		}

		[TestMethod()]
		public void TakeTest1()
		{
			//Prepare
			Test.Config();

			//Action
			var countBefore = Test.ServiceLocator.WareService.GetWares().Count();
			var value = Test.ServiceLocator.WareService.Take("Tuna");
			var countAfter = Test.ServiceLocator.WareService.GetWares().Count();

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(1, value.Id);
			Assert.AreEqual("Tuna", value.Name);
			Assert.AreEqual(WareType.SeaFood, value.Type);
			Assert.AreEqual(DateTime.Today.AddDays(-1), value.ExpirationDate);
			Assert.AreEqual(countBefore, countAfter + 1);
		}
	}
}