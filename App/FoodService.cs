using Domain;
using Contracts;
using Entity_Framwork;
namespace App
{
    public class FoodService : IFoodService
    {
        //private List<Food> _foodList = new List<Food>();
        private readonly appDBContext _context;

        public FoodService()
        {
            _context = new appDBContext();
        }
        public List<FoodDTO> GetAll()
        {
            IQueryable<FoodDTO> query = _context.foods.Where(f => !f.isDeleted).Select(f => new FoodDTO
            {
                Id = f.Id,
                Name = f.Name,
                Category = f.Category,
                Price = f.Price
            });
            return query.ToList();
        }

        public void Add(FoodDTO f)
        {
            //if (f == null)
            //{
            //    Console.WriteLine("Cannot add: input is null.");
            //    return;
            //}
            //if (_context.foods.Any(o => o.Name.Equals(f.Name, StringComparison.OrdinalIgnoreCase)))
            //{
            //    Console.WriteLine($"food'{f.Name}' is already exist");
            //}
            //else
            //{
            //    Food food = new Food(f.Name, f.Category, f.Price);
            //    _context.Add(food);
            //    Console.WriteLine($"food '{f.Name}' is added ");
            //}

            if (f == null)
            {
                Console.WriteLine("Cannot add: input is null.");
                return;
            }
            IQueryable<Food> existing = _context.foods.Where(x => x.Name.ToLower() == f.Name.ToLower() && !x.isDeleted);
            if (existing.Any())
            {
                Console.WriteLine($"food '{f.Name}' already exists.");
                return;
            }
            var food = new Food(f.Name, f.Category, f.Price);
            _context.foods.Add(food);
            _context.SaveChanges();
            Console.WriteLine($"food '{f.Name}' is added.");
        }

        public void Remove(int id)
        {
            //var food = _foodList.FirstOrDefault(x => x.Id == id);
            //if (food == null)
            //{
            //    Console.WriteLine($"Cannot delete: food with ID {id} not found.");
            //    return;
            //}
            //if (food.isDeleted)
            //{
            //    Console.WriteLine($"Food with ID {id} is already deleted.");
            //    return;
            //}
            //food.isDeleted = true;
            //Console.WriteLine($"Food '{food.Name}' has been deleted.");

            IQueryable<Food> foods = _context.foods.Where(f => f.Id == id);
            Food food = foods.FirstOrDefault();
            if (food == null)
            {
                Console.WriteLine($"Cannot delete: food with ID {id} not found.");
                return;
            }
            if (food.isDeleted)
            {
                Console.WriteLine($"Food with ID {id} is already deleted.");
                return;
            }
            food.isDeleted = true;
            _context.SaveChanges();
            Console.WriteLine($"Food '{food.Name}' has been deleted.");
        }

        public void Update(int id, FoodDTO f)
        {
            //if (f == null)
            //{
            //    Console.WriteLine("Cannot update: updated data is null.");
            //    return;
            //}
            //Food food = _foodList.FirstOrDefault(f => f.Id == id && !f.isDeleted);
            //if (food != null)
            //{
            //    food.Name = f.Name;
            //    food.Price = f.Price;
            //    food.Category = f.Category;
            //    Console.WriteLine($"Food ID {id} ('{food.Name}') has been updated.");
            //}
            //else
            //{
            //    Console.WriteLine($"Food with ID {id} not found or has been deleted.");
            //}

            if (f == null)
            {
                Console.WriteLine("Cannot update: updated data is null.");
                return;
            }
            IQueryable<Food> foods = _context.foods.Where(x => x.Id == id && !x.isDeleted);
            Food food = foods.FirstOrDefault();
            if (food != null)
            {
                food.Name = f.Name;
                food.Category = f.Category;
                food.Price = f.Price;
                _context.SaveChanges();
                Console.WriteLine($"Food ID {id} ('{food.Name}') has been updated.");
            }
            else
            {
                Console.WriteLine($"Food with ID {id} not found or has been deleted.");
            }
        }

    }
}
