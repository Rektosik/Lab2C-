using Microsoft.AspNetCore.Mvc;

namespace ViewTask.Controllers
{
    public class TasksController : Controller
    {
        private static readonly List<string> SuperMarketList =
            new() { "Silpo", "ATB", "Novus", "Fora" };

        private static Dictionary<string, int> GetShoppingList() => new()
        {
            { "Milk", 2 },
            { "Bread", 1 },
            { "Eggs", 10 },
            { "Apples", 5 }
        };

        public IActionResult SprintTasks() => View();

        public IActionResult Greetings() => View();

        public IActionResult ProductInfo() => View();

        public IActionResult SuperMarkets()
        {
            ViewBag.SuperMarkets = SuperMarketList;
            return View();
        }

        public IActionResult ShoppingList()
        {
            return View(GetShoppingList());
        }

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            FillCartData();
            return View();
        }

        [HttpPost]
        public IActionResult ShoppingCart(string customerName, string address,
            string supermarket, DateTime shipDate, string[] products)
        {
            FillCartData();
            string items = products != null ? string.Join(", ", products) : "nothing";
            ViewBag.Message = $"Dear {customerName}, your order ({items}) from {supermarket} " +
                              $"will be delivered to {address} on {shipDate:dd.MM.yyyy}.";
            return View();
        }

        private void FillCartData()
        {
            ViewBag.SuperMarkets = SuperMarketList;
            ViewBag.Products = GetShoppingList().Keys.ToList();
        }
    }
}