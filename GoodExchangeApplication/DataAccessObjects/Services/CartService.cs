using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.CartDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class CartService : IAddToCartService
    {
        List<CartDTOs> carts = new List<CartDTOs>();
        List<ItemDTOS> items = new List<ItemDTOS>();
        private static CartService instance = null;
        private static object instanceLock = new object();

        public CartService() { }
        private int cartID;
        private int? cartIdToBuyCont = 0;
        public static CartService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CartService();
                    }
                    return instance;
                }
            }
        }
        public List<CartDTOs> getAllCart() => carts.OrderByDescending(c => c.Id).ToList();
        public List<ItemDTOS> getItemByCartId(int cartID) => carts.SelectMany(cart => cart.Items)
                .Where(item => item.cartId == cartID)
                .ToList();
        public int GetCartIdNew()
        {
            if (carts.Any())
            {
                var id = carts.Max(x => x.Id);
                return id + 1;
            }
            else
            {
                return 1;
            }
        }
        public int GetItemIdNew(int cartID)
        {
            var itemsInCart = carts.Where(cart => cart.Id == cartID)
                           .SelectMany(cart => cart.Items)
                           .ToList();
            if (itemsInCart.Any())
            {
                var maxId = itemsInCart.Max(item => item.Id);
                return maxId + 1;
            }
            else
            {
                return 1;
            }
        }
        public CartDTOs getCartByID(int id)
        {
            CartDTOs? c = carts.SingleOrDefault(project => project.Id == id);
            return c;
        }
        public ItemDTOS getItemByID(int id)
        {
            ItemDTOS? c = items.SingleOrDefault(project => project.Id == id);
            return c;
        }
        public void AddToCart(CartDTOs cart)
        {
            if (cartIdToBuyCont == 0 || cartIdToBuyCont == null)
            {
                carts.Add(cart);
            }
            else
            {
                carts.Add(cart);
            }
           

        }
        public void DeleteCartAll()
        {
            carts.Clear();
        }
        public void DeleteItemInCart(int cartid, int itemid)
        {
            var cart = getCartByID(cartid);
            if (cart != null)
            {
                var itemToRemove = cart.Items.FirstOrDefault(x => x.Id == itemid);
                if (itemToRemove != null)
                {
                    cart.Items.Remove(itemToRemove);
                }
            }
        }
        public void UpdateCartItems(List<ItemDTOS> updatedItems)
        {
            foreach (var updatedItem in updatedItems)
            {
                var existingItem = items.FirstOrDefault(i => i.Id == updatedItem.Id);

                if (existingItem != null)
                {
                    existingItem.productId = updatedItem.productId;
                    existingItem.cartId = updatedItem.cartId;
                    existingItem.quanity = updatedItem.quanity;
                }
            }
        }

        public void UpdateCartItem(ItemDTOS updatedItem)
        {
            var existingItem = items.FirstOrDefault(i => i.Id == updatedItem.Id);

            if (existingItem != null)
            {
                existingItem.productId = updatedItem.productId;
                existingItem.cartId = updatedItem.cartId;
                existingItem.quanity = updatedItem.quanity;
            }
        }

    }
}
