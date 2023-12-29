using BookStore.Data;

namespace BookStore.Models
{
    public class Cart
    {
        private readonly BookStoreContext _context;

        public Cart(BookStoreContext context)
        {
            _context = context;
        }

        public string Id { get; set; }

        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(ServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<BookStoreContext>();
            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            session.SetString("Id", cartId);

            return new Cart(context) { Id = cartId };

        }


    }
}
