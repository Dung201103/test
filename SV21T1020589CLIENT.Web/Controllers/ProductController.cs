﻿using Microsoft.AspNetCore.Mvc;
using SV21T1020589CLIENT.BusinessLayers;
using SV21T1020589CLIENT.Web.Models;

namespace SV21T1020589CLIENT.Web.Controllers
{
	public class ProductController : Controller
	{
		public const int PAGE_SIZE = 50;
		private const string PRODUCT_SEARCH_CONDITION = "ProductsSearchCondition";

		public IActionResult Index()
		{
			ProductSearchInput? condition = ApplicationContext.GetSessionData<ProductSearchInput>(PRODUCT_SEARCH_CONDITION);
			if (condition == null)
			{
				condition = new ProductSearchInput()
				{
					Page = 1,
					PageSize = PAGE_SIZE,
					SearchValue = "",
					CategoryID = 0,
					SupplierID = 0,

				};
			}
			return View(condition);
		}

		public IActionResult Search(ProductSearchInput condition)
		{
			int rowCount;
			var data = ProductDataService.ListProducts(out rowCount, condition.Page, condition.PageSize, condition.SearchValue ?? "",
				condition.CategoryID, condition.SupplierID);
			ProductSearchResult model = new ProductSearchResult()
			{
				Page = condition.Page,
				PageSize = condition.PageSize,
				SearchValue = condition.SearchValue ?? "",
				RowCount = rowCount,
				CategoryID = condition.CategoryID,
				SupplierID = condition.SupplierID,

				Data = data

			};
			ApplicationContext.SetSessionData(PRODUCT_SEARCH_CONDITION, condition);
			return View(model);
		}


		public IActionResult Detail(int id)
		{
			var data = ProductDataService.GetProduct(id);
			if (data == null) return RedirectToAction("Index");
			return View(data);
		}
	}
}
